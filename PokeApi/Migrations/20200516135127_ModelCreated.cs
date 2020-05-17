using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PokeApi.Migrations
{
    public partial class ModelCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pokemon_Pokemon_PokemonId",
                table: "Pokemon");

            migrationBuilder.DropForeignKey(
                name: "FK_Pokemon_Pokemon_PokemonId1",
                table: "Pokemon");

            migrationBuilder.DropForeignKey(
                name: "FK_TypeElement_Pokemon_PokemonId",
                table: "TypeElement");

            migrationBuilder.DropForeignKey(
                name: "FK_TypeElement_Pokemon_PokemonId1",
                table: "TypeElement");

            migrationBuilder.DropIndex(
                name: "IX_TypeElement_PokemonId",
                table: "TypeElement");

            migrationBuilder.DropIndex(
                name: "IX_TypeElement_PokemonId1",
                table: "TypeElement");

            migrationBuilder.DropIndex(
                name: "IX_Pokemon_PokemonId",
                table: "Pokemon");

            migrationBuilder.DropIndex(
                name: "IX_Pokemon_PokemonId1",
                table: "Pokemon");

            migrationBuilder.DropColumn(
                name: "PokemonId",
                table: "TypeElement");

            migrationBuilder.DropColumn(
                name: "PokemonId1",
                table: "TypeElement");

            migrationBuilder.DropColumn(
                name: "PokemonId",
                table: "Pokemon");

            migrationBuilder.DropColumn(
                name: "PokemonId1",
                table: "Pokemon");

            migrationBuilder.CreateTable(
                name: "PokemonNextEvolution",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PokemonId = table.Column<int>(nullable: false),
                    NextPokemonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonNextEvolution", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PokemonNextEvolution_Pokemon_NextPokemonId",
                        column: x => x.NextPokemonId,
                        principalTable: "Pokemon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokemonNextEvolution_Pokemon_PokemonId",
                        column: x => x.PokemonId,
                        principalTable: "Pokemon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PokemonPrevEvolution",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PokemonId = table.Column<int>(nullable: false),
                    PrevPokemonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonPrevEvolution", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PokemonPrevEvolution_Pokemon_PokemonId",
                        column: x => x.PokemonId,
                        principalTable: "Pokemon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokemonPrevEvolution_Pokemon_PrevPokemonId",
                        column: x => x.PrevPokemonId,
                        principalTable: "Pokemon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PokemonTypeElement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PokemonId = table.Column<int>(nullable: false),
                    TypeElementId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonTypeElement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PokemonTypeElement_Pokemon_PokemonId",
                        column: x => x.PokemonId,
                        principalTable: "Pokemon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokemonTypeElement_TypeElement_TypeElementId",
                        column: x => x.TypeElementId,
                        principalTable: "TypeElement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PokemonWeakness",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PokemonId = table.Column<int>(nullable: false),
                    TypeElementId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonWeakness", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PokemonWeakness_Pokemon_PokemonId",
                        column: x => x.PokemonId,
                        principalTable: "Pokemon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokemonWeakness_TypeElement_TypeElementId",
                        column: x => x.TypeElementId,
                        principalTable: "TypeElement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PokemonNextEvolution_NextPokemonId",
                table: "PokemonNextEvolution",
                column: "NextPokemonId");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonNextEvolution_PokemonId",
                table: "PokemonNextEvolution",
                column: "PokemonId");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonPrevEvolution_PokemonId",
                table: "PokemonPrevEvolution",
                column: "PokemonId");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonPrevEvolution_PrevPokemonId",
                table: "PokemonPrevEvolution",
                column: "PrevPokemonId");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonTypeElement_PokemonId",
                table: "PokemonTypeElement",
                column: "PokemonId");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonTypeElement_TypeElementId",
                table: "PokemonTypeElement",
                column: "TypeElementId");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonWeakness_PokemonId",
                table: "PokemonWeakness",
                column: "PokemonId");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonWeakness_TypeElementId",
                table: "PokemonWeakness",
                column: "TypeElementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PokemonNextEvolution");

            migrationBuilder.DropTable(
                name: "PokemonPrevEvolution");

            migrationBuilder.DropTable(
                name: "PokemonTypeElement");

            migrationBuilder.DropTable(
                name: "PokemonWeakness");

            migrationBuilder.AddColumn<int>(
                name: "PokemonId",
                table: "TypeElement",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PokemonId1",
                table: "TypeElement",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PokemonId",
                table: "Pokemon",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PokemonId1",
                table: "Pokemon",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TypeElement_PokemonId",
                table: "TypeElement",
                column: "PokemonId");

            migrationBuilder.CreateIndex(
                name: "IX_TypeElement_PokemonId1",
                table: "TypeElement",
                column: "PokemonId1");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemon_PokemonId",
                table: "Pokemon",
                column: "PokemonId");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemon_PokemonId1",
                table: "Pokemon",
                column: "PokemonId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemon_Pokemon_PokemonId",
                table: "Pokemon",
                column: "PokemonId",
                principalTable: "Pokemon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemon_Pokemon_PokemonId1",
                table: "Pokemon",
                column: "PokemonId1",
                principalTable: "Pokemon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TypeElement_Pokemon_PokemonId",
                table: "TypeElement",
                column: "PokemonId",
                principalTable: "Pokemon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TypeElement_Pokemon_PokemonId1",
                table: "TypeElement",
                column: "PokemonId1",
                principalTable: "Pokemon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
