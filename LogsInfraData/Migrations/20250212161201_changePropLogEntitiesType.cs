using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogsInfraData.Migrations
{
    /// <inheritdoc />
    public partial class changePropLogEntitiesType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumeroContaDestino",
                table: "LogBase");

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorTransacao",
                table: "LogTransacaoInternas",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "NumeroContaDestino",
                table: "LogTransacaoInternas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorBoleto",
                table: "LogPagamentoBoletos",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumeroContaDestino",
                table: "LogTransacaoInternas");

            migrationBuilder.AlterColumn<int>(
                name: "ValorTransacao",
                table: "LogTransacaoInternas",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "ValorBoleto",
                table: "LogPagamentoBoletos",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "NumeroContaDestino",
                table: "LogBase",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
