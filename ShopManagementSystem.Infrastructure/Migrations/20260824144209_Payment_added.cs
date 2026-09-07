using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopManagementSystem.Infrastructure.Migrations;

/// <inheritdoc />
public partial class Payment_added : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Payment_Orders_OrderId",
            table: "Payment");

        migrationBuilder.DropPrimaryKey(
            name: "PK_Payment",
            table: "Payment");

        migrationBuilder.RenameTable(
            name: "Payment",
            newName: "Payments");

        migrationBuilder.RenameIndex(
            name: "IX_Payment_OrderId",
            table: "Payments",
            newName: "IX_Payments_OrderId");

        migrationBuilder.AddColumn<string>(
            name: "ReferenceId",
            table: "Payments",
            type: "nvarchar(max)",
            nullable: true);

        migrationBuilder.AddPrimaryKey(
            name: "PK_Payments",
            table: "Payments",
            column: "Id");

        migrationBuilder.AddForeignKey(
            name: "FK_Payments_Orders_OrderId",
            table: "Payments",
            column: "OrderId",
            principalTable: "Orders",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Payments_Orders_OrderId",
            table: "Payments");

        migrationBuilder.DropPrimaryKey(
            name: "PK_Payments",
            table: "Payments");

        migrationBuilder.DropColumn(
            name: "ReferenceId",
            table: "Payments");

        migrationBuilder.RenameTable(
            name: "Payments",
            newName: "Payment");

        migrationBuilder.RenameIndex(
            name: "IX_Payments_OrderId",
            table: "Payment",
            newName: "IX_Payment_OrderId");

        migrationBuilder.AddPrimaryKey(
            name: "PK_Payment",
            table: "Payment",
            column: "Id");

        migrationBuilder.AddForeignKey(
            name: "FK_Payment_Orders_OrderId",
            table: "Payment",
            column: "OrderId",
            principalTable: "Orders",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }
}
