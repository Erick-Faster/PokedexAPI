using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Pokedex.Api.Extensions;
using Pokedex.API.Domain.Repositories;
using Pokedex.API.Domain.Services;
using Pokedex.API.Persistence.Repositories;
using Pokedex.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Config
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ITrainerRepository, TrainerRepository>();
            services.AddScoped<ITrainerService, TrainerService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IEnderecoService, EnderecoService>();

            services.AddScoped<IPokemonRepository, PokemonRepository>();
            services.AddScoped<IPokemonService, PokemonService>();

            services.AddScoped<IPokedexInfoRepository, PokedexInfoRepository>();
            services.AddScoped<IPokedexInfoService, PokedexInfoService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();

            return services;
        }
    }
}
