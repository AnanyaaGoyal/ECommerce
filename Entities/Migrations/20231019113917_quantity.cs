using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AP.Entities.Migrations
{
    /// <inheritdoc />
    public partial class quantity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quanity",
                table: "Products",
                newName: "Quantity");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "BirthDate", "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 10, 19, 17, 9, 17, 788, DateTimeKind.Local).AddTicks(8152), new DateTime(2023, 10, 19, 17, 9, 17, 788, DateTimeKind.Local).AddTicks(8172), "$2a$11$4GJlQtjmRAWyUGd.24Ah5.mlBdWy7MmLUdr.qnHecXYJU4WVpnSYK" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Products",
                newName: "Quanity");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "BirthDate", "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 10, 19, 16, 30, 42, 438, DateTimeKind.Local).AddTicks(1009), new DateTime(2023, 10, 19, 16, 30, 42, 438, DateTimeKind.Local).AddTicks(1039), "$2a$11$MRn50synyHJKFxuG4mV3VuzUvbh.uYOUdcPut.hDXN/R8jGeKgql2" });
        }
    }
}
