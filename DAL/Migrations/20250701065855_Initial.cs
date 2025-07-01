using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Первинний ключ"),
                    FullName = table.Column<string>(type: "text", nullable: true, comment: "Повне ім'я"),
                    Email = table.Column<string>(type: "text", nullable: false, comment: "Email"),
                    PasswordHash = table.Column<string>(type: "text", nullable: false, comment: "Хеш паролю"),
                    DateCreate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, comment: "Дата створення"),
                    DateUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, comment: "Дата оновлення"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: true, comment: "Прапор видалення")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Первинний ключ"),
                    Name = table.Column<string>(type: "text", nullable: false, comment: "Назва категорії"),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    DateCreate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, comment: "Дата створення"),
                    DateUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, comment: "Дата оновлення"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: true, comment: "Прапор видалення")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Первинний ключ"),
                    Name = table.Column<string>(type: "text", nullable: false, comment: "Name"),
                    WebHookUrl = table.Column<string>(type: "text", nullable: false, comment: "WebHookUrl"),
                    Permissions = table.Column<string>(type: "text", nullable: false, comment: "Permissions"),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false, comment: "UserId"),
                    DateCreate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, comment: "Дата створення"),
                    DateUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, comment: "Дата оновлення"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: true, comment: "Прапор видалення")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Первинний ключ"),
                    TransactionDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, comment: "Дата транзакції"),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false, comment: "Сума транзакції"),
                    Note = table.Column<string>(type: "text", nullable: true, comment: "Коментар до транзакції"),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true, comment: "Тип транзакції"),
                    Source = table.Column<string>(type: "text", nullable: true, comment: "Джерело транзакції"),
                    DateCreate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, comment: "Дата створення"),
                    DateUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, comment: "Дата оновлення"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: true, comment: "Прапор видалення")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Первинний ключ"),
                    CurrencyCode = table.Column<int>(type: "integer", nullable: false, comment: "Код валюти"),
                    CashbackType = table.Column<string>(type: "text", nullable: true, comment: "UAH, DOL, EURO..."),
                    Balance = table.Column<int>(type: "integer", nullable: false, comment: "Баланс"),
                    CreditLimit = table.Column<int>(type: "integer", nullable: false, comment: "Кредитний ліміт"),
                    MaskedPan = table.Column<string>(type: "text", nullable: false, comment: "Масковані номери карт"),
                    Type = table.Column<string>(type: "text", nullable: false, comment: "Тип карти"),
                    Iban = table.Column<string>(type: "text", nullable: false, comment: "Номер IBAN"),
                    ClientId = table.Column<Guid>(type: "uuid", nullable: false),
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_ClientId",
                table: "Accounts",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_UserId",
                table: "Categories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_UserId",
                table: "Clients",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Settings_UserId",
                table: "Settings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_UserId",
                table: "Transactions",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
