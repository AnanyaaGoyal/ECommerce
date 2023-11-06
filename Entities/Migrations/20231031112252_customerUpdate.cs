using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AP.Entities.Migrations
{
    /// <inheritdoc />
    public partial class customerUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerPhone",
                table: "Customers");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "BirthDate", "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 10, 31, 16, 52, 52, 510, DateTimeKind.Local).AddTicks(6519), new DateTime(2023, 10, 31, 16, 52, 52, 510, DateTimeKind.Local).AddTicks(6551), "$2a$11$V7.V03nhlco7WvbLkOr/ae9hrFknNvXl.hNRwZsAe6rhKrblccufW" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerPhone",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "BirthDate", "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 10, 31, 13, 41, 37, 705, DateTimeKind.Local).AddTicks(4159), new DateTime(2023, 10, 31, 13, 41, 37, 705, DateTimeKind.Local).AddTicks(4211), "$2a$11$CYyxsuy2UwVwjoVX2iVnCuBCQxlOLkzTufUZgGYn1.8zld3vcYDlW" });
        }
    }
}
