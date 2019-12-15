using Microsoft.EntityFrameworkCore.Migrations;

namespace WowAutoApp.Data.Migrations
{
    public partial class Improve_Buisness_Address : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Buisnesses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Buisnesses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Buisnesses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StreetAddress",
                table: "Buisnesses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StreetAddressLine",
                table: "Buisnesses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Buisnesses");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Buisnesses");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Buisnesses");

            migrationBuilder.DropColumn(
                name: "StreetAddress",
                table: "Buisnesses");

            migrationBuilder.DropColumn(
                name: "StreetAddressLine",
                table: "Buisnesses");
        }
    }
}
