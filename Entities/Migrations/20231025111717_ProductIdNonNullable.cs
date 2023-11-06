using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AP.Entities.Migrations
{
    /// <inheritdoc />
    public partial class ProductIdNonNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "Cart",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "BirthDate", "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 10, 25, 16, 47, 17, 95, DateTimeKind.Local).AddTicks(9560), new DateTime(2023, 10, 25, 16, 47, 17, 95, DateTimeKind.Local).AddTicks(9575), "$2a$11$pGafWVzkv/7shRauvWJxdu0CdFN7hr8cZI.9C4jA1/8.3oVSPL.wi" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "Cart",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "BirthDate", "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 10, 25, 15, 56, 47, 861, DateTimeKind.Local).AddTicks(1705), new DateTime(2023, 10, 25, 15, 56, 47, 861, DateTimeKind.Local).AddTicks(1749), "$2a$11$dUVBX64aDY/Z57qL23BlL..V0Tnf5bMtu40bQ5L3RuWgdo/Ir7uVK" });
        }
    }
}
