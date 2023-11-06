using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AP.Entities.Migrations
{
    /// <inheritdoc />
    public partial class statusAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "BirthDate", "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 11, 1, 15, 58, 12, 982, DateTimeKind.Local).AddTicks(1318), new DateTime(2023, 11, 1, 15, 58, 12, 982, DateTimeKind.Local).AddTicks(1347), "$2a$11$2Y4WIyVZLEPVjHfw5IzAdOpdGVWiHFdBhXSSXaZG9dRrmi4L6IFTC" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "BirthDate", "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 10, 31, 17, 7, 23, 518, DateTimeKind.Local).AddTicks(5236), new DateTime(2023, 10, 31, 17, 7, 23, 518, DateTimeKind.Local).AddTicks(5266), "$2a$11$Pon8vPahS9OiGgSFMDQW2OUPCcW880fUBO6EjXLUR0fJPS14NCgOS" });
        }
    }
}
