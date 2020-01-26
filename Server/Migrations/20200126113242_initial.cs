using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DBDiscounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Percent = table.Column<int>(nullable: false),
                    Property = table.Column<int>(nullable: false),
                    PropertyValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBDiscounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbPersons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonStoreID = table.Column<long>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Birthdate = table.Column<DateTime>(nullable: true),
                    Adress = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    TotalSpent = table.Column<double>(nullable: true),
                    Position = table.Column<int>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbPersons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SellerId = table.Column<int>(nullable: true),
                    BuyerId = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbTransactions_DbPersons_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "DbPersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DbTransactions_DbPersons_SellerId",
                        column: x => x.SellerId,
                        principalTable: "DbPersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DBItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemCode = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Stock = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Edition = table.Column<int>(nullable: true),
                    Discount = table.Column<int>(nullable: false),
                    FinalPrice = table.Column<double>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    TransactionId = table.Column<int>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    Genre = table.Column<int>(nullable: true),
                    YearPublished = table.Column<int>(nullable: true),
                    Pages = table.Column<int>(nullable: true),
                    ISBN = table.Column<long>(nullable: true),
                    Journal_Genre = table.Column<int>(nullable: true),
                    PrintDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DBItems_DbTransactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "DbTransactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
               name: "DbTransactionItems",
               columns: table => new
               {
                   Id = table.Column<int>(nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   TransactionID = table.Column<int>(nullable: false),
                   ItemID = table.Column<int>(nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_DbTransactionItems", x => x.Id);
                   table.ForeignKey(
                      name: "FK_DbTransactionItems_DbTransactions_Id",
                      column: x => x.TransactionID,
                      principalTable: "DbTransactions",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
                   table.ForeignKey(
                       name: "FK_DbTransactionItems_DBItems_Id",
                       column: x => x.ItemID,
                       principalTable: "DBItems",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.Restrict);
               });

            migrationBuilder.CreateIndex(
                name: "IX_DBItems_TransactionId",
                table: "DBItems",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_DbTransactions_BuyerId",
                table: "DbTransactions",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_DbTransactions_SellerId",
                table: "DbTransactions",
                column: "SellerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DBDiscounts");

            migrationBuilder.DropTable(
                name: "DBItems");

            migrationBuilder.DropTable(
                name: "DbTransactionItems");

            migrationBuilder.DropTable(
                name: "DbTransactions");

            migrationBuilder.DropTable(
                name: "DbPersons");
        }
    }
}
