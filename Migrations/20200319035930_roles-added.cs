using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class rolesadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "ApplicationUsers");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "ApplicationUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsers_RoleId",
                table: "ApplicationUsers",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUsers_Roles_RoleId",
                table: "ApplicationUsers",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUsers_Roles_RoleId",
                table: "ApplicationUsers");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationUsers_RoleId",
                table: "ApplicationUsers");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "ApplicationUsers");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "ApplicationUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
