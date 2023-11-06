using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AP.Entities.Migrations
{
    /// <inheritdoc />
    public partial class UserToUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "BirthDate", "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 10, 25, 15, 56, 47, 861, DateTimeKind.Local).AddTicks(1705), new DateTime(2023, 10, 25, 15, 56, 47, 861, DateTimeKind.Local).AddTicks(1749), "$2a$11$dUVBX64aDY/Z57qL23BlL..V0Tnf5bMtu40bQ5L3RuWgdo/Ir7uVK" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "BirthDate", "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 10, 19, 18, 2, 35, 15, DateTimeKind.Local).AddTicks(5599), new DateTime(2023, 10, 19, 18, 2, 35, 15, DateTimeKind.Local).AddTicks(5628), "$2a$11$6EwLp6UloK1FLp8ZOojDHeKfiUtpeVzmNYvahVDINJafq7Cwo471e" });
        }
    }
}
