using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BShop.Infrastructure.Migrations
{
    public partial class fixingIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "shoppingCarts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "shoppingCarts",
                columns: table => new
                {
                    CartID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalCost = table.Column<float>(type: "real", nullable: false),
                    TransID = table.Column<int>(type: "int", nullable: false)
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
                    ShoppingCartID = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => new { x.BShopItemID, x.ShoppingCartID });
                    table.ForeignKey(
                        name: "FK_CartItems_BShopItems_BShopItemID",
                        column: x => x.BShopItemID,
                        principalTable: "BShopItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_shoppingCarts_ShoppingCartID",
                        column: x => x.ShoppingCartID,
                        principalTable: "shoppingCarts",
                        principalColumn: "CartID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuyerID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CartID = table.Column<int>(type: "int", nullable: false),
                    CreditNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransID);
                    table.ForeignKey(
                        name: "FK_Transactions_AspNetUsers_BuyerID",
                        column: x => x.BuyerID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_shoppingCarts_CartID",
                        column: x => x.CartID,
                        principalTable: "shoppingCarts",
                        principalColumn: "CartID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ShoppingCartID",
                table: "CartItems",
                column: "ShoppingCartID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_BuyerID",
                table: "Transactions",
                column: "BuyerID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CartID",
                table: "Transactions",
                column: "CartID",
                unique: true);
        }
    }
}
