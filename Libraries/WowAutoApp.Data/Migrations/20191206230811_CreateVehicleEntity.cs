using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WowAutoApp.Data.Migrations
{
    public partial class CreateVehicleEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Profile",
                newName: "ZipCode");

            migrationBuilder.AddColumn<string>(
                name: "AvatarUrl",
                table: "Profile",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Profile",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Profile",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Profile",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmploymentStatus",
                table: "Profile",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HouseFlatNumber",
                table: "Profile",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsEmailVerified",
                table: "Profile",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "MobileNumber",
                table: "Profile",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MonthlyRent",
                table: "Profile",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Profile",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SocialSecurityNumber",
                table: "Profile",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Profile",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StreetAddress",
                table: "Profile",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DownPayment = table.Column<int>(nullable: false),
                    TotalAmount = table.Column<int>(nullable: false),
                    OtherInfo = table.Column<string>(nullable: true),
                    DriverLicensePhotoId = table.Column<int>(nullable: false),
                    VehicleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicle_Picture_DriverLicensePhotoId",
                        column: x => x.DriverLicensePhotoId,
                        principalTable: "Picture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicle_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_DriverLicensePhotoId",
                table: "Vehicle",
                column: "DriverLicensePhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_VehicleId",
                table: "Vehicle",
                column: "VehicleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropColumn(
                name: "AvatarUrl",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "EmploymentStatus",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "HouseFlatNumber",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "IsEmailVerified",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "MobileNumber",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "MonthlyRent",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "SocialSecurityNumber",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "StreetAddress",
                table: "Profile");

            migrationBuilder.RenameColumn(
                name: "ZipCode",
                table: "Profile",
                newName: "ImageUrl");
        }
    }
}
