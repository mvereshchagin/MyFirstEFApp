using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyFirstEFApp.Migrations
{
    /// <inheritdoc />
    public partial class AddClientServiceEntity5Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_ClientServices_ClientServiceId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_ClientServiceId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ClientServiceId",
                table: "Clients");

            migrationBuilder.CreateIndex(
                name: "IX_ClientServices_ClientId",
                table: "ClientServices",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientServices_ServiceId",
                table: "ClientServices",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientServices_Clients_ClientId",
                table: "ClientServices",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientServices_Services_ServiceId",
                table: "ClientServices",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientServices_Clients_ClientId",
                table: "ClientServices");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientServices_Services_ServiceId",
                table: "ClientServices");

            migrationBuilder.DropIndex(
                name: "IX_ClientServices_ClientId",
                table: "ClientServices");

            migrationBuilder.DropIndex(
                name: "IX_ClientServices_ServiceId",
                table: "ClientServices");

            migrationBuilder.AddColumn<int>(
                name: "ClientServiceId",
                table: "Clients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ClientServiceId",
                table: "Clients",
                column: "ClientServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_ClientServices_ClientServiceId",
                table: "Clients",
                column: "ClientServiceId",
                principalTable: "ClientServices",
                principalColumn: "Id");
        }
    }
}
