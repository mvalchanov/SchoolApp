using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolApp.Data.Migrations
{
    public partial class UserModelEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserGroup");

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserGroup",
                nullable: false,
                defaultValue: 0);
        }
    }
}
