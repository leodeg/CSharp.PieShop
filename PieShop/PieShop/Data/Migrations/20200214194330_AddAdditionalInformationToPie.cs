using Microsoft.EntityFrameworkCore.Migrations;

namespace PieShop.Data.Migrations
{
    public partial class AddAdditionalInformationToPie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AllergyInformation",
                table: "Pies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageThumbnailUrl",
                table: "Pies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Pies",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "InStock",
                table: "Pies",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPieOfWeek",
                table: "Pies",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LongDescription",
                table: "Pies",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllergyInformation",
                table: "Pies");

            migrationBuilder.DropColumn(
                name: "ImageThumbnailUrl",
                table: "Pies");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Pies");

            migrationBuilder.DropColumn(
                name: "InStock",
                table: "Pies");

            migrationBuilder.DropColumn(
                name: "IsPieOfWeek",
                table: "Pies");

            migrationBuilder.DropColumn(
                name: "LongDescription",
                table: "Pies");
        }
    }
}
