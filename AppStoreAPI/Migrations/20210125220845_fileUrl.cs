using Microsoft.EntityFrameworkCore.Migrations;

namespace AppStoreAPI.Migrations
{
    public partial class fileUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppFileUrl",
                table: "Apps",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppFileUrl",
                table: "Apps");
        }
    }
}
