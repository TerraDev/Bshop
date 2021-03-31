using Microsoft.EntityFrameworkCore.Migrations;

namespace BShop.Infrastructure.Migrations
{
    public partial class fixingPKRels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_shoppingCarts_CartID",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_CartID",
                table: "Transactions");

            migrationBuilder.AlterColumn<int>(
                name: "CartID",
                table: "Transactions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CartID",
                table: "Transactions",
                column: "CartID",
                unique: true,
                filter: "[CartID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_shoppingCarts_CartID",
                table: "Transactions",
                column: "CartID",
                principalTable: "shoppingCarts",
                principalColumn: "CartID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_shoppingCarts_CartID",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_CartID",
                table: "Transactions");

            migrationBuilder.AlterColumn<int>(
                name: "CartID",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CartID",
                table: "Transactions",
                column: "CartID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_shoppingCarts_CartID",
                table: "Transactions",
                column: "CartID",
                principalTable: "shoppingCarts",
                principalColumn: "CartID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
