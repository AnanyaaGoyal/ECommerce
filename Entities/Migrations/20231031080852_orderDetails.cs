using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AP.Entities.Migrations
{
    /// <inheritdoc />
    public partial class orderDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    DetaiId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.DetaiId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Orders",
                        principalColumn: "SessionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "BirthDate", "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 10, 31, 13, 38, 52, 327, DateTimeKind.Local).AddTicks(3327), new DateTime(2023, 10, 31, 13, 38, 52, 327, DateTimeKind.Local).AddTicks(3353), "$2a$11$gGDJG8ZWqJjTJ.Ho2Q5utuHsjxqM6LwXMqQH4egcMCAyo1IJCOWjO" });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_SessionId",
                table: "OrderDetails",
                column: "SessionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "BirthDate", "CreatedAt", "Password" },
                values: new object[] { new DateTime(2023, 10, 31, 11, 30, 42, 330, DateTimeKind.Local).AddTicks(4469), new DateTime(2023, 10, 31, 11, 30, 42, 330, DateTimeKind.Local).AddTicks(4488), "$2a$11$7O3mip80ZoUoHtHsv7RvU.tCWjIqc5gJdn7z7xsNe75lTpfwCeJe." });
        }
    }
}
