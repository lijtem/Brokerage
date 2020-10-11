using Microsoft.EntityFrameworkCore.Migrations;

namespace Brokerage.Data.Migrations
{
    public partial class RemarksFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Remarks_VehicleId",
                table: "Remarks",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Remarks_Vehicles_VehicleId",
                table: "Remarks",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Remarks_Vehicles_VehicleId",
                table: "Remarks");

            migrationBuilder.DropIndex(
                name: "IX_Remarks_VehicleId",
                table: "Remarks");
        }
    }
}
