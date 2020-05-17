using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PokeApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pokemon",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Height = table.Column<double>(nullable: false),
                    Weight = table.Column<double>(nullable: false),
                    Candy = table.Column<string>(nullable: true),
                    CandyCount = table.Column<int>(nullable: false),
                    Egg = table.Column<string>(nullable: true),
                    SpawnChance = table.Column<double>(nullable: false),
                    AvgSpawns = table.Column<double>(nullable: false),
                    SpawnTime = table.Column<string>(nullable: true),
                    PokemonId = table.Column<int>(nullable: true),
                    PokemonId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pokemon_Pokemon_PokemonId",
                        column: x => x.PokemonId,
                        principalTable: "Pokemon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pokemon_Pokemon_PokemonId1",
                        column: x => x.PokemonId1,
                        principalTable: "Pokemon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TypeElement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(nullable: true),
                    PokemonId = table.Column<int>(nullable: true),
                    PokemonId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeElement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TypeElement_Pokemon_PokemonId",
                        column: x => x.PokemonId,
                        principalTable: "Pokemon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TypeElement_Pokemon_PokemonId1",
                        column: x => x.PokemonId1,
                        principalTable: "Pokemon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pokemon_PokemonId",
                table: "Pokemon",
                column: "PokemonId");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemon_PokemonId1",
                table: "Pokemon",
                column: "PokemonId1");

            migrationBuilder.CreateIndex(
                name: "IX_TypeElement_PokemonId",
                table: "TypeElement",
                column: "PokemonId");

            migrationBuilder.CreateIndex(
                name: "IX_TypeElement_PokemonId1",
                table: "TypeElement",
                column: "PokemonId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TypeElement");

            migrationBuilder.DropTable(
                name: "Pokemon");
        }
    }
}
