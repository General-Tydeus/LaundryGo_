using Microsoft.EntityFrameworkCore.Migrations;

namespace LaundryGo.Data.Migrations
{
    public partial class UpdateShopTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Shop",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OfficeHours",
                table: "Shop",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Shop");

            migrationBuilder.DropColumn(
                name: "OfficeHours",
                table: "Shop");
        }
    }
}
