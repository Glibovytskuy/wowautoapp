using Microsoft.EntityFrameworkCore.Migrations;

namespace WowAutoApp.Data.Migrations
{
    public partial class Add_Buisness : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Picture_DriverLicensePhotoId",
                table: "Vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_AspNetUsers_OwnerLicenseId",
                table: "Vehicle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicle",
                table: "Vehicle");

            migrationBuilder.RenameTable(
                name: "Vehicle",
                newName: "Vehicles");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicle_OwnerLicenseId",
                table: "Vehicles",
                newName: "IX_Vehicles_OwnerLicenseId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicle_DriverLicensePhotoId",
                table: "Vehicles",
                newName: "IX_Vehicles_DriverLicensePhotoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Picture_DriverLicensePhotoId",
                table: "Vehicles",
                column: "DriverLicensePhotoId",
                principalTable: "Picture",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_AspNetUsers_OwnerLicenseId",
                table: "Vehicles",
                column: "OwnerLicenseId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Picture_DriverLicensePhotoId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_AspNetUsers_OwnerLicenseId",
                table: "Vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles");

            migrationBuilder.RenameTable(
                name: "Vehicles",
                newName: "Vehicle");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_OwnerLicenseId",
                table: "Vehicle",
                newName: "IX_Vehicle_OwnerLicenseId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_DriverLicensePhotoId",
                table: "Vehicle",
                newName: "IX_Vehicle_DriverLicensePhotoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicle",
                table: "Vehicle",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Picture_DriverLicensePhotoId",
                table: "Vehicle",
                column: "DriverLicensePhotoId",
                principalTable: "Picture",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_AspNetUsers_OwnerLicenseId",
                table: "Vehicle",
                column: "OwnerLicenseId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
