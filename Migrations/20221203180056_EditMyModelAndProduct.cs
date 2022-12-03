using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdventureLabNew.Migrations
{
    public partial class EditMyModelAndProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "MyModels");

            migrationBuilder.AddColumn<int>(
                name: "MyModelId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_MyModelId",
                table: "Products",
                column: "MyModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_MyModels_MyModelId",
                table: "Products",
                column: "MyModelId",
                principalTable: "MyModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_MyModels_MyModelId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_MyModelId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MyModelId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "MyModels",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
