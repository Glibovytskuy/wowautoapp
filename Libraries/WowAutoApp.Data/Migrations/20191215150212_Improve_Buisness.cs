using Microsoft.EntityFrameworkCore.Migrations;

namespace WowAutoApp.Data.Migrations
{
    public partial class Improve_Buisness : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BankId",
                table: "Buisnesses",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buisnesses_Banks_BankId",
                table: "Buisnesses");

            migrationBuilder.DropIndex(
                name: "IX_Buisnesses_BankId",
                table: "Buisnesses");

            migrationBuilder.DropColumn(
                name: "BankId",
                table: "Buisnesses");
        }
    }
}
