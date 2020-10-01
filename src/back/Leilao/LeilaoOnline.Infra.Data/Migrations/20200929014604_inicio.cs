using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LeilaoOnline.Infra.Data.Migrations
{
    public partial class inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(maxLength: 80, nullable: true),
                    Senha = table.Column<string>(maxLength: 80, nullable: true),
                    Nome = table.Column<string>(maxLength: 80, nullable: true),
                    Ativo = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Leilao",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 80, nullable: true),
                    ValorInicial = table.Column<decimal>(nullable: false),
                    Usado = table.Column<bool>(nullable: false),
                    UsuarioResponsavelId = table.Column<Guid>(nullable: false),
                    DataAbertura = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 9, 28, 22, 46, 3, 642, DateTimeKind.Local).AddTicks(5195)),
                    DataFinalizacao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leilao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leilao_Usuario_UsuarioResponsavelId",
                        column: x => x.UsuarioResponsavelId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Ativo", "Email", "Nome", "Senha" },
                values: new object[] { new Guid("a7353f28-e5fb-4d51-888b-0564d67bcf2b"), true, "teste@teste.com.br", "Usuario de Teste", "202cb962ac59075b964b07152d234b70" });

            migrationBuilder.InsertData(
                table: "Leilao",
                columns: new[] { "Id", "DataAbertura", "DataFinalizacao", "Nome", "Usado", "UsuarioResponsavelId", "ValorInicial" },
                values: new object[] { new Guid("68f5c8be-d738-472d-b685-98a4cf6ea83f"), new DateTime(2020, 9, 28, 22, 46, 3, 654, DateTimeKind.Local).AddTicks(7312), new DateTime(2020, 9, 28, 22, 46, 3, 654, DateTimeKind.Local).AddTicks(7804), "Leilão do Audi TT", false, new Guid("a7353f28-e5fb-4d51-888b-0564d67bcf2b"), 246000m });

            migrationBuilder.InsertData(
                table: "Leilao",
                columns: new[] { "Id", "DataAbertura", "DataFinalizacao", "Nome", "Usado", "UsuarioResponsavelId", "ValorInicial" },
                values: new object[] { new Guid("2699ed87-163e-48b3-ba3c-c8093d2d10a3"), new DateTime(2020, 9, 28, 22, 46, 3, 655, DateTimeKind.Local).AddTicks(154), new DateTime(2020, 9, 28, 22, 46, 3, 655, DateTimeKind.Local).AddTicks(166), "Leilão da BMW 320i", true, new Guid("a7353f28-e5fb-4d51-888b-0564d67bcf2b"), 83500m });

            migrationBuilder.CreateIndex(
                name: "IX_Leilao_UsuarioResponsavelId",
                table: "Leilao",
                column: "UsuarioResponsavelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Leilao");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
