using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AP.Entities.Migrations
{
    /// <inheritdoc />
    public partial class cartUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CartId",
                table: "Orders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "BirthDate", "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 10, 31, 17, 7, 23, 518, DateTimeKind.Local).AddTicks(5236), new DateTime(2023, 10, 31, 17, 7, 23, 518, DateTimeKind.Local).AddTicks(5266), "$2a$11$Pon8vPahS9OiGgSFMDQW2OUPCcW880fUBO6EjXLUR0fJPS14NCgOS" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "BirthDate", "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 10, 31, 16, 52, 52, 510, DateTimeKind.Local).AddTicks(6519), new DateTime(2023, 10, 31, 16, 52, 52, 510, DateTimeKind.Local).AddTicks(6551), "$2a$11$V7.V03nhlco7WvbLkOr/ae9hrFknNvXl.hNRwZsAe6rhKrblccufW" });
        }
    }
}
