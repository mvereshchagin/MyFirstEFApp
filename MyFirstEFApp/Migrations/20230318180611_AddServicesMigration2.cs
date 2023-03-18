using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyFirstEFApp.Migrations
{
    /// <inheritdoc />
    public partial class AddServicesMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientService_Service_ServicesId",
                table: "ClientService");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Service",
                table: "Service");

            migrationBuilder.RenameTable(
                name: "Service",
                newName: "Services");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Services",
                table: "Services",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientService_Services_ServicesId",
                table: "ClientService",
                column: "ServicesId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientService_Services_ServicesId",
                table: "ClientService");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Services",
                table: "Services");

            migrationBuilder.RenameTable(
                name: "Services",
                newName: "Service");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Service",
                table: "Service",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientService_Service_ServicesId",
                table: "ClientService",
                column: "ServicesId",
                principalTable: "Service",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
