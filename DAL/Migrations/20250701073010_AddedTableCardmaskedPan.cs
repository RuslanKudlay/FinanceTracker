using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedTableCardmaskedPan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaskedPan",
                table: "Accounts");

            migrationBuilder.CreateTable(
                name: "CardMaskedPan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaskedPan = table.Column<string>(type: "text", nullable: false),
                    AccountId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DateUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardMaskedPan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardMaskedPan_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardMaskedPan_AccountId",
                table: "CardMaskedPan",
                column: "AccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardMaskedPan");

            migrationBuilder.AddColumn<string>(
                name: "MaskedPan",
                table: "Accounts",
                type: "text",
                nullable: false,
                defaultValue: "",
                comment: "Масковані номери карт");
        }
    }
}
