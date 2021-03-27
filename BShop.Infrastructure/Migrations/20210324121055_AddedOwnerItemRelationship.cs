using Microsoft.EntityFrameworkCore.Migrations;

namespace BShop.Infrastructure.Migrations
{
    public partial class AddedOwnerItemRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerID",
                table: "BShopItems",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BShopItems_OwnerID",
                table: "BShopItems",
                column: "OwnerID");

            migrationBuilder.AddForeignKey(
                name: "FK_BShopItems_AspNetUsers_OwnerID",
                table: "BShopItems",
                column: "OwnerID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BShopItems_AspNetUsers_OwnerID",
                table: "BShopItems");

            migrationBuilder.DropIndex(
                name: "IX_BShopItems_OwnerID",
                table: "BShopItems");

            migrationBuilder.DropColumn(
                name: "OwnerID",
                table: "BShopItems");
        }
    }
}
