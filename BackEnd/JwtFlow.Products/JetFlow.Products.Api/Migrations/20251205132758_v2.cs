using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JetFlow.Products.Api.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FlightDate_DateStart",
                table: "Flights",
                newName: "DateStart");

            migrationBuilder.RenameColumn(
                name: "FlightCity_CityStart",
                table: "Flights",
                newName: "CityStart");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateStart",
                table: "Flights",
                newName: "FlightDate_DateStart");

            migrationBuilder.RenameColumn(
                name: "CityStart",
                table: "Flights",
                newName: "FlightCity_CityStart");
        }
    }
}
