using Microsoft.EntityFrameworkCore.Migrations;

namespace Archive.CDManagement.Api.Migrations
{
    public partial class RequirementsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "CDs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Barcode",
                table: "CDs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "CDs",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "OnLoan",
                table: "CDs",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Section",
                table: "CDs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "X",
                table: "CDs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Y",
                table: "CDs",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "CDs");

            migrationBuilder.DropColumn(
                name: "Barcode",
                table: "CDs");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "CDs");

            migrationBuilder.DropColumn(
                name: "OnLoan",
                table: "CDs");

            migrationBuilder.DropColumn(
                name: "Section",
                table: "CDs");

            migrationBuilder.DropColumn(
                name: "X",
                table: "CDs");

            migrationBuilder.DropColumn(
                name: "Y",
                table: "CDs");
        }
    }
}