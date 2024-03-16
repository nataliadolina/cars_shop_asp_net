using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Migrations
{
    /// <inheritdoc />
    public partial class newMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderDetail_orderDetail_OrderDetailId",
                table: "orderDetail");

            migrationBuilder.DropIndex(
                name: "IX_orderDetail_OrderDetailId",
                table: "orderDetail");

            migrationBuilder.DropColumn(
                name: "OrderDetailId",
                table: "orderDetail");

            migrationBuilder.DropColumn(
                name: "OrderTime",
                table: "orderDetail");

            migrationBuilder.AddColumn<long>(
                name: "Price",
                table: "orderDetail",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "orderDetail");

            migrationBuilder.AddColumn<int>(
                name: "OrderDetailId",
                table: "orderDetail",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderTime",
                table: "orderDetail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_orderDetail_OrderDetailId",
                table: "orderDetail",
                column: "OrderDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_orderDetail_orderDetail_OrderDetailId",
                table: "orderDetail",
                column: "OrderDetailId",
                principalTable: "orderDetail",
                principalColumn: "Id");
        }
    }
}
