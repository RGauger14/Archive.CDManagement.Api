using Microsoft.EntityFrameworkCore.Migrations;

namespace Archive.CDManagement.Api.Migrations
{
    public partial class CdThumbnail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ThumbnailFileName",
                table: "CDs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThumbnailFilePath",
                table: "CDs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThumbnailFileName",
                table: "CDs");

            migrationBuilder.DropColumn(
                name: "ThumbnailFilePath",
                table: "CDs");
        }
    }
}
