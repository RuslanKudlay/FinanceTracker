using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedSettingAndMonoEntitys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdate",
                table: "Users",
                type: "timestamp without time zone",
                nullable: true,
                comment: "Дата оновлення",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldComment: "Дата оновлення");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Users",
                type: "timestamp without time zone",
                nullable: true,
                comment: "Дата створення",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldComment: "Дата створення");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDate",
                table: "Transactions",
                type: "timestamp without time zone",
                nullable: false,
                comment: "Дата транзакції",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldComment: "Дата транзакції");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdate",
                table: "Transactions",
                type: "timestamp without time zone",
                nullable: true,
                comment: "Дата оновлення",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldComment: "Дата оновлення");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Transactions",
                type: "timestamp without time zone",
                nullable: true,
                comment: "Дата створення",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldComment: "Дата створення");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdate",
                table: "Categories",
                type: "timestamp without time zone",
                nullable: true,
                comment: "Дата оновлення",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldComment: "Дата оновлення");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Categories",
                type: "timestamp without time zone",
                nullable: true,
                comment: "Дата створення",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldComment: "Дата створення");

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Первинний ключ"),
                    ClientId = table.Column<string>(type: "text", nullable: false, comment: "ClientId"),
                    Name = table.Column<string>(type: "text", nullable: false, comment: "Name"),
                    WebHookUrl = table.Column<string>(type: "text", nullable: false, comment: "WebHookUrl"),
                    Permissions = table.Column<string>(type: "text", nullable: false, comment: "Permissions"),
                    DateCreate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, comment: "Дата створення"),
                    DateUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, comment: "Дата оновлення"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: true, comment: "Прапор видалення")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.UniqueConstraint("AK_Clients_ClientId", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Первинний ключ"),
                    Key = table.Column<string>(type: "text", nullable: false, comment: "Ключ налаштування"),
                    Value = table.Column<string>(type: "text", nullable: false, comment: "Значення налаштування"),
                    Description = table.Column<string>(type: "text", nullable: false, comment: "Опис"),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false, comment: "Зовнішній ключ користувача"),
                    Type = table.Column<string>(type: "text", nullable: false, comment: "Тип даних налаштування"),
                    DateCreate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, comment: "Дата створення"),
                    DateUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, comment: "Дата оновлення"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: true, comment: "Прапор видалення")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Settings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Первинний ключ"),
                    MonoId = table.Column<string>(type: "text", nullable: false, comment: "Id акаунту в mono"),
                    SendId = table.Column<string>(type: "text", nullable: false, comment: "SendId"),
                    CurrencyCode = table.Column<int>(type: "integer", nullable: false, comment: "Код валюти"),
                    CashbackType = table.Column<string>(type: "text", nullable: false, comment: "UAH, DOL, EURO..."),
                    Balance = table.Column<int>(type: "integer", nullable: false, comment: "Баланс"),
                    CreditLimit = table.Column<int>(type: "integer", nullable: false, comment: "Кредитний ліміт"),
                    MaskedPan = table.Column<string>(type: "text", nullable: false, comment: "Масковані номери карт"),
                    Type = table.Column<string>(type: "text", nullable: false, comment: "Тип карти"),
                    Iban = table.Column<string>(type: "text", nullable: false, comment: "Номер IBAN"),
                    ClientId = table.Column<string>(type: "text", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, comment: "Дата створення"),
                    DateUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, comment: "Дата оновлення"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: true, comment: "Прапор видалення")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_ClientId",
                table: "Accounts",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Settings_UserId",
                table: "Settings",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdate",
                table: "Users",
                type: "timestamp with time zone",
                nullable: true,
                comment: "Дата оновлення",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldComment: "Дата оновлення");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Users",
                type: "timestamp with time zone",
                nullable: true,
                comment: "Дата створення",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldComment: "Дата створення");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TransactionDate",
                table: "Transactions",
                type: "timestamp with time zone",
                nullable: false,
                comment: "Дата транзакції",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldComment: "Дата транзакції");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdate",
                table: "Transactions",
                type: "timestamp with time zone",
                nullable: true,
                comment: "Дата оновлення",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldComment: "Дата оновлення");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Transactions",
                type: "timestamp with time zone",
                nullable: true,
                comment: "Дата створення",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldComment: "Дата створення");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdate",
                table: "Categories",
                type: "timestamp with time zone",
                nullable: true,
                comment: "Дата оновлення",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldComment: "Дата оновлення");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "Categories",
                type: "timestamp with time zone",
                nullable: true,
                comment: "Дата створення",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldComment: "Дата створення");
        }
    }
}
