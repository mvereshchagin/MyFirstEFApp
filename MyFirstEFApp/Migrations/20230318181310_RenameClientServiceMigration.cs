using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyFirstEFApp.Migrations
{
    /// <inheritdoc />
    public partial class RenameClientServiceMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientService_Clients_ClientsId",
                table: "ClientService");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientService_Services_ServicesId",
                table: "ClientService");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientService",
                table: "ClientService");

            migrationBuilder.RenameTable(
                name: "ClientService",
                newName: "clientservices");

            migrationBuilder.RenameIndex(
                name: "IX_ClientService_ServicesId",
                table: "clientservices",
                newName: "IX_clientservices_ServicesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_clientservices",
                table: "clientservices",
                columns: new[] { "ClientsId", "ServicesId" });

            migrationBuilder.AddForeignKey(
                name: "FK_clientservices_Clients_ClientsId",
                table: "clientservices",
                column: "ClientsId",
                principalTable: "Clients",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_clientservices_Services_ServicesId",
                table: "clientservices",
                column: "ServicesId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_clientservices_Clients_ClientsId",
                table: "clientservices");

            migrationBuilder.DropForeignKey(
                name: "FK_clientservices_Services_ServicesId",
                table: "clientservices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_clientservices",
                table: "clientservices");

            migrationBuilder.RenameTable(
                name: "clientservices",
                newName: "ClientService");

            migrationBuilder.RenameIndex(
                name: "IX_clientservices_ServicesId",
                table: "ClientService",
                newName: "IX_ClientService_ServicesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientService",
                table: "ClientService",
                columns: new[] { "ClientsId", "ServicesId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ClientService_Clients_ClientsId",
                table: "ClientService",
                column: "ClientsId",
                principalTable: "Clients",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientService_Services_ServicesId",
                table: "ClientService",
                column: "ServicesId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
