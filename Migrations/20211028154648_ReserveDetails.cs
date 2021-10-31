using Microsoft.EntityFrameworkCore.Migrations;

namespace EStore.Migrations
{
    public partial class ReserveDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservationDeatails_Products_ProductId",
                table: "ReservationDeatails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReservationDeatails",
                table: "ReservationDeatails");

            migrationBuilder.RenameTable(
                name: "ReservationDeatails",
                newName: "ReservationDetails");

            migrationBuilder.RenameIndex(
                name: "IX_ReservationDeatails_ProductId",
                table: "ReservationDetails",
                newName: "IX_ReservationDetails_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReservationDetails",
                table: "ReservationDetails",
                column: "ReservationDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationDetails_Products_ProductId",
                table: "ReservationDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservationDetails_Products_ProductId",
                table: "ReservationDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReservationDetails",
                table: "ReservationDetails");

            migrationBuilder.RenameTable(
                name: "ReservationDetails",
                newName: "ReservationDeatails");

            migrationBuilder.RenameIndex(
                name: "IX_ReservationDetails_ProductId",
                table: "ReservationDeatails",
                newName: "IX_ReservationDeatails_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReservationDeatails",
                table: "ReservationDeatails",
                column: "ReservationDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationDeatails_Products_ProductId",
                table: "ReservationDeatails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
