using Microsoft.EntityFrameworkCore;
using Pokedex.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<PokedexInfo> PokedexInfos { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
      
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Trainer>().ToTable("TRAINER");
            builder.Entity<Trainer>().HasKey(p => p.Id);
            builder.Entity<Trainer>().Property(p => p.Id).IsRequired();
            builder.Entity<Trainer>().Property(p => p.Nome).IsRequired().HasMaxLength(30);
            //builder.Entity<Trainer>().Property(p => p.Sexo).IsRequired();
            builder.Entity<Trainer>().Property(p => p.Email).IsRequired().HasMaxLength(30);
            builder.Entity<Trainer>().Property(p => p.Liga).HasMaxLength(20);
            builder.Entity<Trainer>().HasMany(p => p.Enderecos).WithOne(p => p.Trainer).HasForeignKey(p => p.Id_Trainer);
            builder.Entity<Trainer>().HasMany(p => p.Pokemons).WithOne(p => p.Trainer).HasForeignKey(p => p.Id_Trainer);


            builder.Entity<Endereco>().ToTable("ENDERECO");
            builder.Entity<Endereco>().HasKey(p => p.Id);
            builder.Entity<Endereco>().Property(p => p.Bairro).HasMaxLength(50);
            builder.Entity<Endereco>().Property(p => p.Estado).HasMaxLength(2);
            builder.Entity<Endereco>().Property(p => p.Pais).HasMaxLength(20);

            builder.Entity<Pokemon>().ToTable("POKEMON");
            builder.Entity<Pokemon>().HasKey(p => p.Id);
            builder.Entity<Pokemon>().Property(p => p.Name_Custom);
            builder.Entity<Pokemon>().Property(p => p.Nivel);

            builder.Entity<PokedexInfo>().ToTable("POKEDEXINFO");
            builder.Entity<PokedexInfo>().HasKey(p => p.Id);
            builder.Entity<PokedexInfo>().Property(p => p.Id).IsRequired();
            builder.Entity<PokedexInfo>().Property(p => p.Numero);
            builder.Entity<PokedexInfo>().Property(p => p.Name);
            builder.Entity<PokedexInfo>().Property(p => p.Type_1);
            builder.Entity<PokedexInfo>().Property(p => p.Type_2);
            builder.Entity<PokedexInfo>().Property(p => p.Total);
            builder.Entity<PokedexInfo>().Property(p => p.HP);
            builder.Entity<PokedexInfo>().Property(p => p.Attack);
            builder.Entity<PokedexInfo>().Property(p => p.Defense);
            builder.Entity<PokedexInfo>().Property(p => p.SP_Atk);
            builder.Entity<PokedexInfo>().Property(p => p.SP_Def);
            builder.Entity<PokedexInfo>().Property(p => p.Speed);
            builder.Entity<PokedexInfo>().Property(p => p.Generation);
            builder.Entity<PokedexInfo>().Property(p => p.Legendary);
            builder.Entity<PokedexInfo>().HasMany(p => p.Pokemons).WithOne(p => p.PokedexInfo).HasForeignKey(p => p.Id_Pokedex);
        }
    }
}
