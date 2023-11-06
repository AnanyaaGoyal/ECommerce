using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AP.Entities.Migrations
{
    /// <inheritdoc />
    public partial class orderDetailsUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "BirthDate", "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 10, 31, 13, 39, 59, 371, DateTimeKind.Local).AddTicks(5799), new DateTime(2023, 10, 31, 13, 39, 59, 371, DateTimeKind.Local).AddTicks(5823), "$2a$11$V8JR4oUREDwtlXtMClJTpeJOT58fVKj5bIDrBn7eKM89fJkCw3vkC" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "BirthDate", "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 10, 31, 13, 38, 52, 327, DateTimeKind.Local).AddTicks(3327), new DateTime(2023, 10, 31, 13, 38, 52, 327, DateTimeKind.Local).AddTicks(3353), "$2a$11$gGDJG8ZWqJjTJ.Ho2Q5utuHsjxqM6LwXMqQH4egcMCAyo1IJCOWjO" });
        }
    }
}
