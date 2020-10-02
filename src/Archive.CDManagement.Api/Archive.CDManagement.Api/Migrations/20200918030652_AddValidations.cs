using Microsoft.EntityFrameworkCore.Migrations;

namespace Archive.CDManagement.Api.Migrations
{
    public partial class AddValidations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentalItemModel_CDs_CDId",
                table: "RentalItemModel");

            migrationBuilder.DropForeignKey(
                name: "FK_RentalItemModel_Rentals_RentalId",
                table: "RentalItemModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RentalItemModel",
                table: "RentalItemModel");

            migrationBuilder.RenameTable(
                name: "RentalItemModel",
                newName: "RentalItems");

            migrationBuilder.RenameIndex(
                name: "IX_RentalItemModel_RentalId",
                table: "RentalItems",
                newName: "IX_RentalItems_RentalId");

            migrationBuilder.RenameIndex(
                name: "IX_RentalItemModel_CDId",
                table: "RentalItems",
                newName: "IX_RentalItems_CDId");

            migrationBuilder.AlterColumn<string>(
                name: "MobileNumber",
                table: "Staff",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Staff",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Staff",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Staff",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Staff",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "CDs",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Section",
                table: "CDs",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "CDs",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Barcode",
                table: "CDs",
                maxLength: 13,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Author",
                table: "CDs",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RentalItems",
                table: "RentalItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RentalItems_CDs_CDId",
                table: "RentalItems",
                column: "CDId",
                principalTable: "CDs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RentalItems_Rentals_RentalId",
                table: "RentalItems",
                column: "RentalId",
                principalTable: "Rentals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentalItems_CDs_CDId",
                table: "RentalItems");

            migrationBuilder.DropForeignKey(
                name: "FK_RentalItems_Rentals_RentalId",
                table: "RentalItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RentalItems",
                table: "RentalItems");

            migrationBuilder.RenameTable(
                name: "RentalItems",
                newName: "RentalItemModel");

            migrationBuilder.RenameIndex(
                name: "IX_RentalItems_RentalId",
                table: "RentalItemModel",
                newName: "IX_RentalItemModel_RentalId");

            migrationBuilder.RenameIndex(
                name: "IX_RentalItems_CDId",
                table: "RentalItemModel",
                newName: "IX_RentalItemModel_CDId");

            migrationBuilder.AlterColumn<string>(
                name: "MobileNumber",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "CDs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "Section",
                table: "CDs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "CDs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<int>(
                name: "Barcode",
                table: "CDs",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 13);

            migrationBuilder.AlterColumn<string>(
                name: "Author",
                table: "CDs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 25);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RentalItemModel",
                table: "RentalItemModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RentalItemModel_CDs_CDId",
                table: "RentalItemModel",
                column: "CDId",
                principalTable: "CDs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RentalItemModel_Rentals_RentalId",
                table: "RentalItemModel",
                column: "RentalId",
                principalTable: "Rentals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
