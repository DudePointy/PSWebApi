using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "ApplicationUsers");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "ApplicationUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "ApplicationUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "ApplicationUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "ApplicationUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "ApplicationUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "ApplicationUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "ApplicationUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "ApplicationUsers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "ApplicationUsers");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "ApplicationUsers");

            migrationBuilder.DropColumn(
                name: "Token",
                table: "ApplicationUsers");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "ApplicationUsers");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ApplicationUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
