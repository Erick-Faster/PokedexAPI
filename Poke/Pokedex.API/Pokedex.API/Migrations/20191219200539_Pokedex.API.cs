using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pokedex.API.Migrations
{
    public partial class PokedexAPI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "POKEDEXINFO",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Numero = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Type_1 = table.Column<string>(nullable: true),
                    Type_2 = table.Column<string>(nullable: true),
                    Total = table.Column<int>(nullable: false),
                    HP = table.Column<int>(nullable: false),
                    Attack = table.Column<int>(nullable: false),
                    Defense = table.Column<int>(nullable: false),
                    SP_Atk = table.Column<int>(nullable: false),
                    SP_Def = table.Column<int>(nullable: false),
                    Speed = table.Column<int>(nullable: false),
                    Generation = table.Column<int>(nullable: false),
                    Legendary = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_POKEDEXINFO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TRAINER",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 30, nullable: false),
                    Email = table.Column<string>(maxLength: 30, nullable: false),
                    Liga = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRAINER", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ENDERECO",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Bairro = table.Column<string>(maxLength: 50, nullable: true),
                    Estado = table.Column<string>(maxLength: 2, nullable: true),
                    Pais = table.Column<string>(maxLength: 20, nullable: true),
                    Id_Trainer = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENDERECO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ENDERECO_TRAINER_Id_Trainer",
                        column: x => x.Id_Trainer,
                        principalTable: "TRAINER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "POKEMON",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name_Custom = table.Column<string>(nullable: true),
                    Nivel = table.Column<int>(nullable: false),
                    Id_Trainer = table.Column<Guid>(nullable: false),
                    Id_Pokedex = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_POKEMON", x => x.Id);
                    table.ForeignKey(
                        name: "FK_POKEMON_POKEDEXINFO_Id_Pokedex",
                        column: x => x.Id_Pokedex,
                        principalTable: "POKEDEXINFO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_POKEMON_TRAINER_Id_Trainer",
                        column: x => x.Id_Trainer,
                        principalTable: "TRAINER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ENDERECO_Id_Trainer",
                table: "ENDERECO",
                column: "Id_Trainer");

            migrationBuilder.CreateIndex(
                name: "IX_POKEMON_Id_Pokedex",
                table: "POKEMON",
                column: "Id_Pokedex");

            migrationBuilder.CreateIndex(
                name: "IX_POKEMON_Id_Trainer",
                table: "POKEMON",
                column: "Id_Trainer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ENDERECO");

            migrationBuilder.DropTable(
                name: "POKEMON");

            migrationBuilder.DropTable(
                name: "POKEDEXINFO");

            migrationBuilder.DropTable(
                name: "TRAINER");
        }
    }
}
