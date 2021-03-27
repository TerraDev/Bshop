using Microsoft.EntityFrameworkCore.Migrations;

namespace BShop.Infrastructure.Migrations
{
    public partial class RelationshipFixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_SpyWareItems_BShopItemID",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_SpyWareItems_shoppingCarts_CartID",
                table: "SpyWareItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpyWareItems",
                table: "SpyWareItems");

            migrationBuilder.DropIndex(
                name: "IX_SpyWareItems_CartID",
                table: "SpyWareItems");

            migrationBuilder.DropColumn(
                name: "CartID",
                table: "SpyWareItems");

            migrationBuilder.RenameTable(
                name: "SpyWareItems",
                newName: "BShopItems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BShopItems",
                table: "BShopItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_BShopItems_BShopItemID",
                table: "CartItems",
                column: "BShopItemID",
                principalTable: "BShopItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_BShopItems_BShopItemID",
                table: "CartItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BShopItems",
                table: "BShopItems");

            migrationBuilder.RenameTable(
                name: "BShopItems",
                newName: "SpyWareItems");

            migrationBuilder.AddColumn<string>(
                name: "CartID",
                table: "SpyWareItems",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpyWareItems",
                table: "SpyWareItems",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SpyWareItems_CartID",
                table: "SpyWareItems",
                column: "CartID");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_SpyWareItems_BShopItemID",
                table: "CartItems",
                column: "BShopItemID",
                principalTable: "SpyWareItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpyWareItems_shoppingCarts_CartID",
                table: "SpyWareItems",
                column: "CartID",
                principalTable: "shoppingCarts",
                principalColumn: "CartID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
