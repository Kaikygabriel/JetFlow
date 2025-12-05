using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JetFlow.Products.Api.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(120)", maxLength: 120, nullable: false),
                    FlightDate_DateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FlightDate_DateOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FlightCity_CityStart = table.Column<string>(type: "NVARCHAR(150)", maxLength: 150, nullable: false),
                    FlightCity_CityOut = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "MONEY", nullable: false),
                    UsersId = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flights");
        }
    }
}
