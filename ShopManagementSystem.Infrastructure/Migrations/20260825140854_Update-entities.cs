using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopManagementSystem.Infrastructure.Migrations;

/// <inheritdoc />
public partial class Updateentities : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Orders_Users_UserId",
            table: "Orders");

        migrationBuilder.DropIndex(
            name: "IX_Payments_OrderId",
            table: "Payments");

        migrationBuilder.DropIndex(
            name: "IX_CartItems_ProductId",
            table: "CartItems");

        migrationBuilder.CreateIndex(
            name: "IX_Payments_OrderId",
            table: "Payments",
            column: "OrderId");

        migrationBuilder.CreateIndex(
            name: "IX_CartItems_ProductId_CartId",
            table: "CartItems",
            columns: new[] { "ProductId", "CartId" },
            unique: true);

        migrationBuilder.AddForeignKey(
            name: "FK_Orders_Users_UserId",
            table: "Orders",
            column: "UserId",
            principalTable: "Users",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Orders_Users_UserId",
            table: "Orders");

        migrationBuilder.DropIndex(
            name: "IX_Payments_OrderId",
            table: "Payments");

        migrationBuilder.DropIndex(
            name: "IX_CartItems_ProductId_CartId",
            table: "CartItems");

        migrationBuilder.CreateIndex(
            name: "IX_Payments_OrderId",
            table: "Payments",
            column: "OrderId",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_CartItems_ProductId",
            table: "CartItems",
            column: "ProductId");

        migrationBuilder.AddForeignKey(
            name: "FK_Orders_Users_UserId",
            table: "Orders",
            column: "UserId",
            principalTable: "Users",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }
}
