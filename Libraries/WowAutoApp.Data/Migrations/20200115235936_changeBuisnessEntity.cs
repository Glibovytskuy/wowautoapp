using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WowAutoApp.Data.Migrations
{
    public partial class changeBuisnessEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buisnesses_Banks_BankId",
                table: "Buisnesses");

            migrationBuilder.DropIndex(
                name: "IX_Buisnesses_BankId",
                table: "Buisnesses");

            migrationBuilder.RenameColumn(
                name: "StreetAddressLine",
                table: "Buisnesses",
                newName: "StreetAddressLine2");

            migrationBuilder.RenameColumn(
                name: "GrossAnnualIncome",
                table: "Buisnesses",
                newName: "YearsAtAddress");

            migrationBuilder.RenameColumn(
                name: "BankId",
                table: "Buisnesses",
                newName: "SocialSecurityNumber");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Buisnesses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AnnualIncome",
                table: "Buisnesses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Buisnesses",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Buisnesses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Buisnesses",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LengthOfTimeAtAddress",
                table: "Buisnesses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "Buisnesses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OccupancyType",
                table: "Buisnesses",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PrimaryPhoneNumber",
                table: "Buisnesses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RelationshipToCompany",
                table: "Buisnesses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RentMonthlyPayment",
                table: "Buisnesses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RentMonthlyPaymentPersonalInfo",
                table: "Buisnesses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Buisnesses_AddressId",
                table: "Buisnesses",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Buisnesses_Addresses_AddressId",
                table: "Buisnesses",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buisnesses_Addresses_AddressId",
                table: "Buisnesses");

            migrationBuilder.DropIndex(
                name: "IX_Buisnesses_AddressId",
                table: "Buisnesses");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Buisnesses");

            migrationBuilder.DropColumn(
                name: "AnnualIncome",
                table: "Buisnesses");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Buisnesses");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Buisnesses");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Buisnesses");

            migrationBuilder.DropColumn(
                name: "LengthOfTimeAtAddress",
                table: "Buisnesses");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "Buisnesses");

            migrationBuilder.DropColumn(
                name: "OccupancyType",
                table: "Buisnesses");

            migrationBuilder.DropColumn(
                name: "PrimaryPhoneNumber",
                table: "Buisnesses");

            migrationBuilder.DropColumn(
                name: "RelationshipToCompany",
                table: "Buisnesses");

            migrationBuilder.DropColumn(
                name: "RentMonthlyPayment",
                table: "Buisnesses");

            migrationBuilder.DropColumn(
                name: "RentMonthlyPaymentPersonalInfo",
                table: "Buisnesses");

            migrationBuilder.RenameColumn(
                name: "YearsAtAddress",
                table: "Buisnesses",
                newName: "GrossAnnualIncome");

            migrationBuilder.RenameColumn(
                name: "StreetAddressLine2",
                table: "Buisnesses",
                newName: "StreetAddressLine");

            migrationBuilder.RenameColumn(
                name: "SocialSecurityNumber",
                table: "Buisnesses",
                newName: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Buisnesses_BankId",
                table: "Buisnesses",
                column: "BankId");

            migrationBuilder.AddForeignKey(
                name: "FK_Buisnesses_Banks_BankId",
                table: "Buisnesses",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
