using Microsoft.EntityFrameworkCore.Migrations;

namespace EStore.Migrations
{
    public partial class CartMod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Carts",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isChecked",
                table: "Carts",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "isChecked",
                table: "Carts");
        }
    }
}
