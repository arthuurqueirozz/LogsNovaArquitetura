using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogsInfraData.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LogBase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataLog = table.Column<string>(type: "varchar(100)", nullable: false),
                    Agencia = table.Column<int>(type: "int", nullable: false),
                    Estornado = table.Column<bool>(type: "bit", nullable: false),
                    NumeroContaDestino = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogBase", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogPagamentoBoletos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CodigoBarrasBoleto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContaDestino = table.Column<int>(type: "int", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorBoleto = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogPagamentoBoletos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogPagamentoBoletos_LogBase_Id",
                        column: x => x.Id,
                        principalTable: "LogBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LogTransacaoInternas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    NumeroContaInicio = table.Column<int>(type: "int", nullable: false),
                    ValorTransacao = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogTransacaoInternas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogTransacaoInternas_LogBase_Id",
                        column: x => x.Id,
                        principalTable: "LogBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogPagamentoBoletos");

            migrationBuilder.DropTable(
                name: "LogTransacaoInternas");

            migrationBuilder.DropTable(
                name: "LogBase");
        }
    }
}
