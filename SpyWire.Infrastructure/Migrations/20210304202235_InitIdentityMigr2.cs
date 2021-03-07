using Microsoft.EntityFrameworkCore.Migrations;

namespace SpyWire.Infrastructure.Migrations
{
    public partial class InitIdentityMigr2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpyWareItems_User_OwnerID",
                table: "SpyWareItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_User_BuyerID",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_User_SellerID",
                table: "Transactions");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_BuyerID",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_SellerID",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_SpyWareItems_OwnerID",
                table: "SpyWareItems");

            migrationBuilder.DropColumn(
                name: "BuyerID",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "SellerID",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "OwnerID",
                table: "SpyWareItems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BuyerID",
                table: "Transactions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SellerID",
                table: "Transactions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerID",
                table: "SpyWareItems",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateCreated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_BuyerID",
                table: "Transactions",
                column: "BuyerID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_SellerID",
                table: "Transactions",
                column: "SellerID");

            migrationBuilder.CreateIndex(
                name: "IX_SpyWareItems_OwnerID",
                table: "SpyWareItems",
                column: "OwnerID");

            migrationBuilder.AddForeignKey(
                name: "FK_SpyWareItems_User_OwnerID",
                table: "SpyWareItems",
                column: "OwnerID",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_User_BuyerID",
                table: "Transactions",
                column: "BuyerID",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_User_SellerID",
                table: "Transactions",
                column: "SellerID",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
