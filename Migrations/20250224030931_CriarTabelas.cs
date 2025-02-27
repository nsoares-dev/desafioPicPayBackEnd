using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Desafio_PicPay.Migrations
{
    /// <inheritdoc />
    public partial class CriarTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carteiras",
                columns: table => new
                {
                    CarteiraId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCompleto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPFCNPJ = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SaldoConta = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TipoUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carteiras", x => x.CarteiraId);
                });

            migrationBuilder.CreateTable(
                name: "Transferencias",
                columns: table => new
                {
                    TransferenciaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RemetenteId = table.Column<int>(type: "int", nullable: false),
                    RecebedorId = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transferencias", x => x.TransferenciaId);
                    table.ForeignKey(
                        name: "FK_Transaction_Recebedor",
                        column: x => x.RecebedorId,
                        principalTable: "Carteiras",
                        principalColumn: "CarteiraId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transaction_Remetente",
                        column: x => x.RemetenteId,
                        principalTable: "Carteiras",
                        principalColumn: "CarteiraId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carteiras_CPFCNPJ_Email",
                table: "Carteiras",
                columns: new[] { "CPFCNPJ", "Email" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transferencias_RecebedorId",
                table: "Transferencias",
                column: "RecebedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Transferencias_RemetenteId",
                table: "Transferencias",
                column: "RemetenteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transferencias");

            migrationBuilder.DropTable(
                name: "Carteiras");
        }
    }
}
