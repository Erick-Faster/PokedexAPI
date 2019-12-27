using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Pokedex.API.Extensions;
using Pokedex.API.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.API.Config
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefautConnection")));

            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>() //Modificar o comportamento do Identity
                .AddEntityFrameworkStores<ApplicationDbContext>() //Add DB
                .AddErrorDescriber<IdentityTranslater>() //Traduzir customizado
                .AddDefaultTokenProviders(); //Gerar Tokens - ID para identificar usuario

            // JWT

            var appSettingsSection = configuration.GetSection("AppSettings"); //Pegar AppSettings
            services.Configure<AppSettings>(appSettingsSection); // Configurar em qualquer classe

            var appSettings = appSettingsSection.Get<AppSettings>(); //Pegar os dados que configurei
            var key = Encoding.ASCII.GetBytes(appSettings.Secret); //Dou encoding em ASCII do segredo

            //Configuracao da autenticacao
            services.AddAuthentication(x =>
           {
               x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
               x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
           }).AddJwtBearer(x =>
           {
               x.RequireHttpsMetadata = true; //Garantir que o usuario vem de Https
               x.SaveToken = true; //Token deve ser guardado para ser validado depois
               x.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuerSigningKey = true, //Validar, quem emite (issuer) eh o mesmo de quem recebe Token, baseado na chave
                   IssuerSigningKey = new SymmetricSecurityKey(key), //Configuracao da chave
                   ValidateIssuer = true, //valida conforme nome
                   ValidateAudience = true, //onde eh validado
                   ValidAudience = appSettings.ValidoEm, //qual eh a audiencia
                   ValidIssuer = appSettings.Emissor // qual eh o emissor
               };
           });

            return services;
        }
    }
}
