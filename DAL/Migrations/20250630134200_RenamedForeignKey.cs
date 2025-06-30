using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class RenamedForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Clients_ClientId",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Accounts",
                newName: "ClientGuidId");

            migrationBuilder.RenameIndex(
                name: "IX_Accounts_ClientId",
                table: "Accounts",
                newName: "IX_Accounts_ClientGuidId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Clients_ClientGuidId",
                table: "Accounts",
                column: "ClientGuidId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Clients_ClientGuidId",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "ClientGuidId",
                table: "Accounts",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Accounts_ClientGuidId",
                table: "Accounts",
                newName: "IX_Accounts_ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Clients_ClientId",
                table: "Accounts",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
