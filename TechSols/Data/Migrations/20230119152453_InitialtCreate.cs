using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechSols.Data.Migrations
{
    public partial class InitialtCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserCategory",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_UserCategory_UserId",
                table: "UserCategory",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCategory_AspNetUsers_UserId",
                table: "UserCategory",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCategory_AspNetUsers_UserId",
                table: "UserCategory");

            migrationBuilder.DropIndex(
                name: "IX_UserCategory_UserId",
                table: "UserCategory");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserCategory",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
