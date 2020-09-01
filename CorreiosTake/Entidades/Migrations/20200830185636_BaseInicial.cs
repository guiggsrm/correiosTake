using Microsoft.EntityFrameworkCore.Migrations;

namespace Entidades.Migrations
{
    public partial class BaseInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeEstado = table.Column<string>(nullable: false),
                    Sigla = table.Column<string>(maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cidade",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCidade = table.Column<string>(nullable: false),
                    Sigla = table.Column<string>(maxLength: 2, nullable: false),
                    IdEstado = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cidade_Estado_IdEstado",
                        column: x => x.IdEstado,
                        principalTable: "Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trexo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCidadePartida = table.Column<int>(nullable: false),
                    IdCidadeDestino = table.Column<int>(nullable: false),
                    NumDiasTrexo = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trexo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trexo_Cidade_IdCidadeDestino",
                        column: x => x.IdCidadeDestino,
                        principalTable: "Cidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trexo_Cidade_IdCidadePartida",
                        column: x => x.IdCidadePartida,
                        principalTable: "Cidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cidade_IdEstado",
                table: "Cidade",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IXCidade_Sigla",
                table: "Cidade",
                column: "Sigla");

            migrationBuilder.CreateIndex(
                name: "IXCidade_Sigla_Estado",
                table: "Cidade",
                columns: new[] { "Sigla", "IdEstado" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trexo_IdCidadeDestino",
                table: "Trexo",
                column: "IdCidadeDestino");

            migrationBuilder.CreateIndex(
                name: "IX_Trexo_IdCidadePartida",
                table: "Trexo",
                column: "IdCidadePartida");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trexo");

            migrationBuilder.DropTable(
                name: "Cidade");

            migrationBuilder.DropTable(
                name: "Estado");
        }
    }
}
