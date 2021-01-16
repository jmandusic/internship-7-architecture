﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PointOfSale.Data.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BillType = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PurchasedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isCancelled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOfCategory = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeeklyWorkingHours = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfferType = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfferType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OfferId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfferCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    OfferId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfferCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfferCategories_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartOfRent = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndOfRent = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PricePerHour = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OfferId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rents_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceBills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfferId = table.Column<int>(type: "int", nullable: false),
                    BillId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceBills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceBills_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceBills_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceBills_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScheduledOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PricePerHour = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OfferId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionBills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfferId = table.Column<int>(type: "int", nullable: false),
                    BillId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionBills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubscriptionBills_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubscriptionBills_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubscriptionBills_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TraditionalBills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfferId = table.Column<int>(type: "int", nullable: false),
                    BillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TraditionalBills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TraditionalBills_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TraditionalBills_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "Id", "BillType", "PurchasedOn", "TotalPrice", "isCancelled" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(2021, 1, 16, 16, 58, 24, 985, DateTimeKind.Local).AddTicks(8354), 25m, false },
                    { 2, 0, new DateTime(2021, 1, 7, 12, 45, 0, 0, DateTimeKind.Unspecified), 1500m, false },
                    { 3, 0, new DateTime(2021, 1, 3, 9, 35, 0, 0, DateTimeKind.Unspecified), 5m, false },
                    { 4, 2, new DateTime(2021, 1, 9, 15, 0, 0, 0, DateTimeKind.Unspecified), 1000m, false },
                    { 5, 2, new DateTime(2020, 12, 28, 17, 30, 0, 0, DateTimeKind.Unspecified), 180m, false },
                    { 6, 2, new DateTime(2021, 1, 16, 16, 58, 24, 988, DateTimeKind.Local).AddTicks(8827), 710m, false },
                    { 7, 1, new DateTime(2021, 1, 2, 17, 45, 0, 0, DateTimeKind.Unspecified), 200m, false },
                    { 8, 1, new DateTime(2021, 1, 5, 13, 25, 0, 0, DateTimeKind.Unspecified), 67.5m, false },
                    { 9, 1, new DateTime(2021, 1, 18, 12, 45, 0, 0, DateTimeKind.Unspecified), 62.5m, false }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "NameOfCategory" },
                values: new object[,]
                {
                    { 1, "food" },
                    { 2, "hygiene" },
                    { 3, "electronics" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CustomerID", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "62783190283", "Ante", "Antić" },
                    { 2, "092836784921", "Josip", "Josipić" },
                    { 3, "98368109372", "Marko", "Markić" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "EmployeeID", "FirstName", "LastName", "WeeklyWorkingHours" },
                values: new object[,]
                {
                    { 3, "90367890251", "Duje", "Dujić", 45m },
                    { 1, "28903610827", "Mate", "Matić", 50m },
                    { 2, "10927489362", "Ivan", "Ivanić", 25m }
                });

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "Id", "Name", "OfferType", "Quantity" },
                values: new object[,]
                {
                    { 1, "cake", 0, 20 },
                    { 2, "TV", 0, 12 },
                    { 3, "laptop", 0, 10 },
                    { 4, "shampoo", 0, 50 }
                });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "OfferType" },
                values: new object[,]
                {
                    { 8, 2 },
                    { 1, 0 },
                    { 2, 0 },
                    { 3, 0 },
                    { 4, 1 },
                    { 5, 1 },
                    { 6, 1 },
                    { 7, 2 },
                    { 9, 2 }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Name", "OfferId", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, "cake", 1, 25m, 1 },
                    { 2, "TV", 2, 25m, 1 },
                    { 3, "shampoo", 3, 25m, 1 }
                });

            migrationBuilder.InsertData(
                table: "OfferCategories",
                columns: new[] { "Id", "CategoryId", "OfferId" },
                values: new object[,]
                {
                    { 8, 3, 6 },
                    { 5, 2, 5 },
                    { 2, 1, 4 },
                    { 3, 1, 7 },
                    { 6, 2, 8 },
                    { 4, 2, 2 },
                    { 9, 3, 9 },
                    { 1, 1, 1 },
                    { 7, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Rents",
                columns: new[] { "Id", "EndOfRent", "Name", "OfferId", "PricePerHour", "StartOfRent" },
                values: new object[,]
                {
                    { 2, new DateTime(2021, 1, 28, 23, 45, 0, 0, DateTimeKind.Unspecified), "Rent washing machine", 8, 30m, new DateTime(2021, 1, 28, 21, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 1, new DateTime(2021, 1, 3, 14, 0, 0, 0, DateTimeKind.Unspecified), "Rent professional kitchen", 7, 80m, new DateTime(2021, 1, 3, 11, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2021, 2, 10, 16, 0, 0, 0, DateTimeKind.Unspecified), "Rent computer", 9, 25m, new DateTime(2021, 2, 10, 13, 30, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "ServiceBills",
                columns: new[] { "Id", "BillId", "EmployeeId", "OfferId" },
                values: new object[,]
                {
                    { 1, 4, 1, 4 },
                    { 2, 5, 2, 5 },
                    { 3, 6, 1, 6 }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Name", "OfferId", "PricePerHour", "ScheduledOn" },
                values: new object[,]
                {
                    { 2, "Cleaning toilets", 5, 120m, new DateTime(2021, 1, 1, 13, 20, 0, 0, DateTimeKind.Unspecified) },
                    { 1, "Dinner by professional chef", 4, 500m, new DateTime(2021, 1, 10, 20, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Fixing laptop", 6, 355m, new DateTime(2021, 1, 30, 15, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "SubscriptionBills",
                columns: new[] { "Id", "BillId", "CustomerId", "OfferId" },
                values: new object[,]
                {
                    { 1, 7, 1, 7 },
                    { 2, 8, 2, 8 },
                    { 3, 9, 1, 9 }
                });

            migrationBuilder.InsertData(
                table: "TraditionalBills",
                columns: new[] { "Id", "BillId", "OfferId" },
                values: new object[,]
                {
                    { 3, 3, 3 },
                    { 2, 2, 2 },
                    { 1, 1, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_OfferId",
                table: "Items",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferCategories_CategoryId",
                table: "OfferCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferCategories_OfferId",
                table: "OfferCategories",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_OfferId",
                table: "Rents",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceBills_BillId",
                table: "ServiceBills",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceBills_EmployeeId",
                table: "ServiceBills",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceBills_OfferId",
                table: "ServiceBills",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_OfferId",
                table: "Services",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionBills_BillId",
                table: "SubscriptionBills",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionBills_CustomerId",
                table: "SubscriptionBills",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionBills_OfferId",
                table: "SubscriptionBills",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_TraditionalBills_BillId",
                table: "TraditionalBills",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_TraditionalBills_OfferId",
                table: "TraditionalBills",
                column: "OfferId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "OfferCategories");

            migrationBuilder.DropTable(
                name: "Rents");

            migrationBuilder.DropTable(
                name: "ServiceBills");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "SubscriptionBills");

            migrationBuilder.DropTable(
                name: "TraditionalBills");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "Offers");
        }
    }
}
