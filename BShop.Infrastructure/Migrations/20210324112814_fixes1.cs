using Microsoft.EntityFrameworkCore.Migrations;

namespace BShop.Infrastructure.Migrations
{
    public partial class fixes1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpyWareItems_Transactions_TransID",
                table: "SpyWareItems");

            migrationBuilder.RenameColumn(
                name: "TransID",
                table: "SpyWareItems",
                newName: "CartID");

            migrationBuilder.RenameIndex(
                name: "IX_SpyWareItems_TransID",
                table: "SpyWareItems",
                newName: "IX_SpyWareItems_CartID");

            migrationBuilder.AddColumn<string>(
                name: "BuyerID",
                table: "Transactions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CartID",
                table: "Transactions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "Amount",
                table: "SpyWareItems",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.CreateTable(
                name: "shoppingCarts",
                columns: table => new
                {
                    CartID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TransID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalCost = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shoppingCarts", x => x.CartID);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    BShopItemID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ShoppingCartID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Amount = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => new { x.BShopItemID, x.ShoppingCartID });
                    table.ForeignKey(
                        name: "FK_CartItems_shoppingCarts_ShoppingCartID",
                        column: x => x.ShoppingCartID,
                        principalTable: "shoppingCarts",
                        principalColumn: "CartID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_SpyWareItems_BShopItemID",
                        column: x => x.BShopItemID,
                        principalTable: "SpyWareItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_BuyerID",
                table: "Transactions",
                column: "BuyerID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CartID",
                table: "Transactions",
                column: "CartID",
                unique: true,
                filter: "[CartID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ShoppingCartID",
                table: "CartItems",
                column: "ShoppingCartID");

            migrationBuilder.AddForeignKey(
                name: "FK_SpyWareItems_shoppingCarts_CartID",
                table: "SpyWareItems",
                column: "CartID",
                principalTable: "shoppingCarts",
                principalColumn: "CartID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_AspNetUsers_BuyerID",
                table: "Transactions",
                column: "BuyerID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_SpyWareItems_shoppingCarts_CartID",
                table: "SpyWareItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_AspNetUsers_BuyerID",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_shoppingCarts_CartID",
                table: "Transactions");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "shoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_BuyerID",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_CartID",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "BuyerID",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "CartID",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "SpyWareItems");

            migrationBuilder.RenameColumn(
                name: "CartID",
                table: "SpyWareItems",
                newName: "TransID");

            migrationBuilder.RenameIndex(
                name: "IX_SpyWareItems_CartID",
                table: "SpyWareItems",
                newName: "IX_SpyWareItems_TransID");

            migrationBuilder.AddForeignKey(
                name: "FK_SpyWareItems_Transactions_TransID",
                table: "SpyWareItems",
                column: "TransID",
                principalTable: "Transactions",
                principalColumn: "TransID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
