using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JetFlow.Products.Api.Migrations
{
    /// <inheritdoc />
    public partial class v210 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Flights");

            migrationBuilder.RenameColumn(
                name: "FlightDate_DateOut",
                table: "Flights",
                newName: "DateOut");

            migrationBuilder.RenameColumn(
                name: "FlightCity_CityOut",
                table: "Flights",
                newName: "CityOut");

            migrationBuilder.AlterColumn<string>(
                name: "CityOut",
                table: "Flights",
                type: "NVARCHAR(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateOut",
                table: "Flights",
                newName: "FlightDate_DateOut");

            migrationBuilder.RenameColumn(
                name: "CityOut",
                table: "Flights",
                newName: "FlightCity_CityOut");

            migrationBuilder.AlterColumn<string>(
                name: "FlightCity_CityOut",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(150)",
                oldMaxLength: 150);

            migrationBuilder.AddColumn<string>(
                name: "UsersId",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
