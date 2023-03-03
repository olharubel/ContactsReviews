using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactsReviews.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTablesColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Incidents_IncidentId",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "IncidentId",
                table: "Accounts",
                newName: "IncidentName");

            migrationBuilder.RenameIndex(
                name: "IX_Accounts_IncidentId",
                table: "Accounts",
                newName: "IX_Accounts_IncidentName");

            migrationBuilder.AddColumn<Guid>(
                name: "IncidentId",
                table: "Incidents",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IncidentIdentifier",
                table: "Accounts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Incidents_IncidentName",
                table: "Accounts",
                column: "IncidentName",
                principalTable: "Incidents",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Incidents_IncidentName",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "IncidentId",
                table: "Incidents");

            migrationBuilder.DropColumn(
                name: "IncidentIdentifier",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "IncidentName",
                table: "Accounts",
                newName: "IncidentId");

            migrationBuilder.RenameIndex(
                name: "IX_Accounts_IncidentName",
                table: "Accounts",
                newName: "IX_Accounts_IncidentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Incidents_IncidentId",
                table: "Accounts",
                column: "IncidentId",
                principalTable: "Incidents",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
