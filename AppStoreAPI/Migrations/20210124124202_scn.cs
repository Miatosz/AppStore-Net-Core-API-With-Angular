using Microsoft.EntityFrameworkCore.Migrations;

namespace AppStoreAPI.Migrations
{
    public partial class scn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apps_AgeClassifications_AgeClassificationId",
                table: "Apps");

            migrationBuilder.DropForeignKey(
                name: "FK_Apps_Developers_DeveloperId",
                table: "Apps");

            migrationBuilder.DropForeignKey(
                name: "FK_Apps_Platforms_PlatformId",
                table: "Apps");

            migrationBuilder.AlterColumn<int>(
                name: "PlatformId",
                table: "Apps",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DeveloperId",
                table: "Apps",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AgeClassificationId",
                table: "Apps",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Apps_AgeClassifications_AgeClassificationId",
                table: "Apps",
                column: "AgeClassificationId",
                principalTable: "AgeClassifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Apps_Developers_DeveloperId",
                table: "Apps",
                column: "DeveloperId",
                principalTable: "Developers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Apps_Platforms_PlatformId",
                table: "Apps",
                column: "PlatformId",
                principalTable: "Platforms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apps_AgeClassifications_AgeClassificationId",
                table: "Apps");

            migrationBuilder.DropForeignKey(
                name: "FK_Apps_Developers_DeveloperId",
                table: "Apps");

            migrationBuilder.DropForeignKey(
                name: "FK_Apps_Platforms_PlatformId",
                table: "Apps");

            migrationBuilder.AlterColumn<int>(
                name: "PlatformId",
                table: "Apps",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DeveloperId",
                table: "Apps",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AgeClassificationId",
                table: "Apps",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Apps_AgeClassifications_AgeClassificationId",
                table: "Apps",
                column: "AgeClassificationId",
                principalTable: "AgeClassifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Apps_Developers_DeveloperId",
                table: "Apps",
                column: "DeveloperId",
                principalTable: "Developers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Apps_Platforms_PlatformId",
                table: "Apps",
                column: "PlatformId",
                principalTable: "Platforms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
