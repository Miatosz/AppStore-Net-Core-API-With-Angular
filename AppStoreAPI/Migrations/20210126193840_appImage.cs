using Microsoft.EntityFrameworkCore.Migrations;

namespace AppStoreAPI.Migrations
{
    public partial class appImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppImagePath",
                table: "Apps",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppImagePath",
                table: "Apps");
        }
    }
}
