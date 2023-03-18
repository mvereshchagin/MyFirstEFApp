using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyFirstEFApp.Migrations
{
    /// <inheritdoc />
    public partial class AddClientServiceEntityMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_clientservices_ServicesId",
                table: "clientservices");

            migrationBuilder.RenameTable(
                name: "clientservices",
                newName: "ClientServices");

            migrationBuilder.RenameColumn(
                name: "ServicesId",
                table: "ClientServices",
                newName: "ServiceId");

            migrationBuilder.RenameColumn(
                name: "ClientsId",
                table: "ClientServices",
                newName: "ClientId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ClientServices",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<DateOnly>(
                name: "ExpireDate",
                table: "ClientServices",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<int>(
                name: "ClientServiceId",
                table: "Clients",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientServices",
                table: "ClientServices",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ClientService",
                columns: table => new
                {
                    ClientsId = table.Column<int>(type: "int", nullable: false),
                    ServicesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientService", x => new { x.ClientsId, x.ServicesId });
                    table.ForeignKey(
                        name: "FK_ClientService_Clients_ClientsId",
                        column: x => x.ClientsId,
                        principalTable: "Clients",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientService_Services_ServicesId",
                        column: x => x.ServicesId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ClientServiceId",
                table: "Clients",
                column: "ClientServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientService_ServicesId",
                table: "ClientService",
                column: "ServicesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_ClientServices_ClientServiceId",
                table: "Clients",
                column: "ClientServiceId",
                principalTable: "ClientServices",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_ClientServices_ClientServiceId",
                table: "Clients");

            migrationBuilder.DropTable(
                name: "ClientService");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientServices",
                table: "ClientServices");

            migrationBuilder.DropIndex(
                name: "IX_Clients_ClientServiceId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ClientServices");

            migrationBuilder.DropColumn(
                name: "ExpireDate",
                table: "ClientServices");

            migrationBuilder.DropColumn(
                name: "ClientServiceId",
                table: "Clients");

            migrationBuilder.RenameTable(
                name: "ClientServices",
                newName: "clientservices");

            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "clientservices",
                newName: "ServicesId");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "clientservices",
                newName: "ClientsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_clientservices",
                table: "clientservices",
                columns: new[] { "ClientsId", "ServicesId" });

            migrationBuilder.CreateIndex(
                name: "IX_clientservices_ServicesId",
                table: "clientservices",
                column: "ServicesId");

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
    }
}
