using Microsoft.EntityFrameworkCore.Migrations;

namespace FreeDocs.Migrations
{
    public partial class addmigrationDocumensadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgURL",
                table: "Documents",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Documents",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgURL",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Documents");
        }
    }
}
