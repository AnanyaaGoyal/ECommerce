using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AP.Entities.Migrations
{
    /// <inheritdoc />
    public partial class invoicePdf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InvoicePdf",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "BirthDate", "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 11, 6, 9, 28, 41, 300, DateTimeKind.Local).AddTicks(7947), new DateTime(2023, 11, 6, 9, 28, 41, 300, DateTimeKind.Local).AddTicks(7972), "$2a$11$PtUelxhcfsXvyunIBvbvx.J57pb3NnHJEp/zRuI9q8EyCE8CT81k6" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoicePdf",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "BirthDate", "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 11, 1, 16, 10, 27, 322, DateTimeKind.Local).AddTicks(9079), new DateTime(2023, 11, 1, 16, 10, 27, 322, DateTimeKind.Local).AddTicks(9106), "$2a$11$yv18RbW4ez185Zbs7uj0Xe5UxdoVW4lIZqB/sd62pC0IkSanXL/aC" });
        }
    }
}
