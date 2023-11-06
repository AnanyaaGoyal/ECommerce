using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AP.Entities.Migrations
{
    /// <inheritdoc />
    public partial class orderUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "BirthDate", "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 10, 31, 13, 41, 37, 705, DateTimeKind.Local).AddTicks(4159), new DateTime(2023, 10, 31, 13, 41, 37, 705, DateTimeKind.Local).AddTicks(4211), "$2a$11$CYyxsuy2UwVwjoVX2iVnCuBCQxlOLkzTufUZgGYn1.8zld3vcYDlW" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "BirthDate", "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 10, 31, 13, 39, 59, 371, DateTimeKind.Local).AddTicks(5799), new DateTime(2023, 10, 31, 13, 39, 59, 371, DateTimeKind.Local).AddTicks(5823), "$2a$11$V8JR4oUREDwtlXtMClJTpeJOT58fVKj5bIDrBn7eKM89fJkCw3vkC" });
        }
    }
}
