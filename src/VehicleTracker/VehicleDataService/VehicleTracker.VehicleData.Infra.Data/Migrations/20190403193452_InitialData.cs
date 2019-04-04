using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleTracker.VehicleData.Infra.Data.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    VehicleId = table.Column<string>(nullable: true),
                    RegNumber = table.Column<string>(nullable: true),
                    CustomerId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[] { new Guid("10000a0b-ddd6-44c0-8f19-963e5ca783dd"), "Cementvägen 8, 111 11 Södertälje", "Kalles Grustransporter AB" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[] { new Guid("20000a0b-ddd6-44c0-8f19-963e5ca783dd"), "Balkvägen 12, 222 22 Stockholm ", "Johans Bulk AB  " });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[] { new Guid("30000a0b-ddd6-44c0-8f19-963e5ca783dd"), "Budgetvägen 1, 333 33 Uppsala", "Haralds Värdetransporter AB" });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CustomerId", "RegNumber", "VehicleId" },
                values: new object[,]
                {
                    { new Guid("40000a0b-ddd6-44c0-8f19-963e5ca783dd"), new Guid("10000a0b-ddd6-44c0-8f19-963e5ca783dd"), "ABC123", "YS2R4X20005399401" },
                    { new Guid("50000a0b-ddd6-44c0-8f19-963e5ca783dd"), new Guid("10000a0b-ddd6-44c0-8f19-963e5ca783dd"), "DEF456", "VLUR4X20009093588" },
                    { new Guid("60000a0b-ddd6-44c0-8f19-963e5ca783dd"), new Guid("10000a0b-ddd6-44c0-8f19-963e5ca783dd"), "GHI789", "VLUR4X20009048066" },
                    { new Guid("70000a0b-ddd6-44c0-8f19-963e5ca783dd"), new Guid("20000a0b-ddd6-44c0-8f19-963e5ca783dd"), "JKL012", "YS2R4X20005388011" },
                    { new Guid("80000a0b-ddd6-44c0-8f19-963e5ca783dd"), new Guid("20000a0b-ddd6-44c0-8f19-963e5ca783dd"), "MNO345", "YS2R4X20005387949" },
                    { new Guid("90000a0b-ddd6-44c0-8f19-963e5ca783dd"), new Guid("30000a0b-ddd6-44c0-8f19-963e5ca783dd"), "PQR678", "VLUR4X20009048066" },
                    { new Guid("01000a0b-ddd6-44c0-8f19-963e5ca783dd"), new Guid("30000a0b-ddd6-44c0-8f19-963e5ca783dd"), "STU901", "YS2R4X20005387055" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_CustomerId",
                table: "Vehicles",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
