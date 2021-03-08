using Microsoft.EntityFrameworkCore.Migrations;

namespace BShop.Infrastructure.Migrations
{
    public partial class Migr2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreditNum",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fee",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "SpyWareItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Price",
                table: "SpyWareItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "SpyWareItems",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreditNum",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Fee",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "SpyWareItems");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "SpyWareItems");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "SpyWareItems");
        }
    }
}
