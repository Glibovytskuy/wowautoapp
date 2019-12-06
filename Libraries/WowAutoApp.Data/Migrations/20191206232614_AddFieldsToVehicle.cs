using Microsoft.EntityFrameworkCore.Migrations;

namespace WowAutoApp.Data.Migrations
{
    public partial class AddFieldsToVehicle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Vehicle_VehicleId",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_VehicleId",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "Vehicle");

            migrationBuilder.AddColumn<string>(
                name: "OwnerLicenseId",
                table: "Vehicle",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_OwnerLicenseId",
                table: "Vehicle",
                column: "OwnerLicenseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_AspNetUsers_OwnerLicenseId",
                table: "Vehicle",
                column: "OwnerLicenseId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_AspNetUsers_OwnerLicenseId",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_OwnerLicenseId",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "OwnerLicenseId",
                table: "Vehicle");

            migrationBuilder.AddColumn<int>(
                name: "VehicleId",
                table: "Vehicle",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_VehicleId",
                table: "Vehicle",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Vehicle_VehicleId",
                table: "Vehicle",
                column: "VehicleId",
                principalTable: "Vehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
