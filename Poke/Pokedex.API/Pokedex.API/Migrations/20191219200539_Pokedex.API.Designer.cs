﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pokedex.API.Persistence.Contexts;

namespace Pokedex.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20191219200539_Pokedex.API")]
    partial class PokedexAPI
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Pokedex.API.Domain.Models.Endereco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bairro")
                        .HasMaxLength(50);

                    b.Property<string>("Estado")
                        .HasMaxLength(2);

                    b.Property<Guid>("Id_Trainer");

                    b.Property<string>("Pais")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("Id_Trainer");

                    b.ToTable("ENDERECO");
                });

            modelBuilder.Entity("Pokedex.API.Domain.Models.PokedexInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Attack");

                    b.Property<int>("Defense");

                    b.Property<int>("Generation");

                    b.Property<int>("HP");

                    b.Property<string>("Legendary");

                    b.Property<string>("Name");

                    b.Property<int>("Numero");

                    b.Property<int>("SP_Atk");

                    b.Property<int>("SP_Def");

                    b.Property<int>("Speed");

                    b.Property<int>("Total");

                    b.Property<string>("Type_1");

                    b.Property<string>("Type_2");

                    b.HasKey("Id");

                    b.ToTable("POKEDEXINFO");
                });

            modelBuilder.Entity("Pokedex.API.Domain.Models.Pokemon", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("Id_Pokedex");

                    b.Property<Guid>("Id_Trainer");

                    b.Property<string>("Name_Custom");

                    b.Property<int>("Nivel");

                    b.HasKey("Id");

                    b.HasIndex("Id_Pokedex");

                    b.HasIndex("Id_Trainer");

                    b.ToTable("POKEMON");
                });

            modelBuilder.Entity("Pokedex.API.Domain.Models.Trainer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Liga")
                        .HasMaxLength(20);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("TRAINER");
                });

            modelBuilder.Entity("Pokedex.API.Domain.Models.Endereco", b =>
                {
                    b.HasOne("Pokedex.API.Domain.Models.Trainer", "Trainer")
                        .WithMany("Enderecos")
                        .HasForeignKey("Id_Trainer")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Pokedex.API.Domain.Models.Pokemon", b =>
                {
                    b.HasOne("Pokedex.API.Domain.Models.PokedexInfo", "PokedexInfo")
                        .WithMany("Pokemons")
                        .HasForeignKey("Id_Pokedex")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Pokedex.API.Domain.Models.Trainer", "Trainer")
                        .WithMany("Pokemons")
                        .HasForeignKey("Id_Trainer")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
