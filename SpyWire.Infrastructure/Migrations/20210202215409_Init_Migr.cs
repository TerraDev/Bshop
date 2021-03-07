using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SpyWire.Infrastructure.Migrations
{
    public partial class Init_Migr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BuyerID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SellerID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TransactionTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransID);
                    table.ForeignKey(
                        name: "FK_Transactions_Users_BuyerID",
                        column: x => x.BuyerID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_Users_SellerID",
                        column: x => x.SellerID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpyWareItems",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TransID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpyWareItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpyWareItems_Transactions_TransID",
                        column: x => x.TransID,
                        principalTable: "Transactions",
                        principalColumn: "TransID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpyWareItems_Users_OwnerID",
                        column: x => x.OwnerID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpyWareItems_OwnerID",
                table: "SpyWareItems",
                column: "OwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_SpyWareItems_TransID",
                table: "SpyWareItems",
                column: "TransID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_BuyerID",
                table: "Transactions",
                column: "BuyerID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_SellerID",
                table: "Transactions",
                column: "SellerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpyWareItems");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
