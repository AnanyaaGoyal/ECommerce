using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AP.Entities.Migrations
{
    /// <inheritdoc />
    public partial class productForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "BirthDate", "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 11, 1, 16, 10, 27, 322, DateTimeKind.Local).AddTicks(9079), new DateTime(2023, 11, 1, 16, 10, 27, 322, DateTimeKind.Local).AddTicks(9106), "$2a$11$yv18RbW4ez185Zbs7uj0Xe5UxdoVW4lIZqB/sd62pC0IkSanXL/aC" });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Products_ProductId",
                table: "OrderDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Products_ProductId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "BirthDate", "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 11, 1, 15, 58, 12, 982, DateTimeKind.Local).AddTicks(1318), new DateTime(2023, 11, 1, 15, 58, 12, 982, DateTimeKind.Local).AddTicks(1347), "$2a$11$2Y4WIyVZLEPVjHfw5IzAdOpdGVWiHFdBhXSSXaZG9dRrmi4L6IFTC" });
        }
    }
}
