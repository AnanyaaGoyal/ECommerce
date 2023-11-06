using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AP.Entities.Migrations
{
    /// <inheritdoc />
    public partial class usercart_removed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserCarts");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "BirthDate", "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 10, 19, 18, 2, 35, 15, DateTimeKind.Local).AddTicks(5599), new DateTime(2023, 10, 19, 18, 2, 35, 15, DateTimeKind.Local).AddTicks(5628), "$2a$11$6EwLp6UloK1FLp8ZOojDHeKfiUtpeVzmNYvahVDINJafq7Cwo471e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserCarts",
                columns: table => new
                {
                    UserCartId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCarts", x => x.UserCartId);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "BirthDate", "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 10, 19, 17, 9, 17, 788, DateTimeKind.Local).AddTicks(8152), new DateTime(2023, 10, 19, 17, 9, 17, 788, DateTimeKind.Local).AddTicks(8172), "$2a$11$4GJlQtjmRAWyUGd.24Ah5.mlBdWy7MmLUdr.qnHecXYJU4WVpnSYK" });
        }
    }
}
