using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "many_to_many");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Первинний ключ"),
                    Name = table.Column<string>(type: "text", nullable: false, comment: "Назва категорії"),
                    Description = table.Column<string>(type: "text", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, comment: "Дата створення"),
                    DateUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, comment: "Дата оновлення"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: true, comment: "Прапор видалення")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

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
                name: "mm_users_categories",
                schema: "many_to_many",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mm_users_categories", x => new { x.UserId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_mm_users_categories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mm_users_categories_Users_UserId",
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
                    CurrencyCode = table.Column<int>(type: "integer", nullable: false, comment: "Код валюти"),
                    CashbackType = table.Column<string>(type: "text", nullable: true, comment: "UAH, DOL, EURO..."),
                    Balance = table.Column<int>(type: "integer", nullable: false, comment: "Баланс"),
                    CreditLimit = table.Column<int>(type: "integer", nullable: false, comment: "Кредитний ліміт"),
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

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "DateCreate", "DateUpdate", "Description", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("1db85ff8-9cc8-4a2b-9000-8776ea3f6559"), new DateTime(2025, 7, 1, 13, 47, 19, 633, DateTimeKind.Local).AddTicks(957), new DateTime(2025, 7, 1, 13, 47, 19, 633, DateTimeKind.Local).AddTicks(959), "Ремонт, ТО, заправка...", false, "Автомобіль" },
                    { new Guid("21c5fa0a-7ad0-4916-8857-cfc3ca91a5a3"), new DateTime(2025, 7, 1, 13, 47, 19, 633, DateTimeKind.Local).AddTicks(970), new DateTime(2025, 7, 1, 13, 47, 19, 633, DateTimeKind.Local).AddTicks(971), "", false, "Краса та гігієна" },
                    { new Guid("2f5ac876-e8db-4059-b753-3025563614b7"), new DateTime(2025, 7, 1, 13, 47, 19, 633, DateTimeKind.Local).AddTicks(920), new DateTime(2025, 7, 1, 13, 47, 19, 633, DateTimeKind.Local).AddTicks(922), "Електроенергія, тепло, ОСББ/ЖЕК, дофомон, ліфт, вода...", false, "Комунальні платежі" },
                    { new Guid("45fc02b8-a372-47c7-b005-e56952455105"), new DateTime(2025, 7, 1, 13, 47, 19, 633, DateTimeKind.Local).AddTicks(944), new DateTime(2025, 7, 1, 13, 47, 19, 633, DateTimeKind.Local).AddTicks(947), "Оплата за одяг, або інші речі (КОМФІ, ТА-ДА, АВРОРА)", false, "Шопінг" },
                    { new Guid("66a5e0a2-02cc-4551-bb08-56f2367d5da8"), new DateTime(2025, 7, 1, 13, 47, 19, 631, DateTimeKind.Local).AddTicks(99), new DateTime(2025, 7, 1, 13, 47, 19, 632, DateTimeKind.Local).AddTicks(9559), "Сплата громадського транспорту, таксі", false, "Транспорт" },
                    { new Guid("6fb35072-8199-4481-a721-5624954f1640"), new DateTime(2025, 7, 1, 13, 47, 19, 633, DateTimeKind.Local).AddTicks(902), new DateTime(2025, 7, 1, 13, 47, 19, 633, DateTimeKind.Local).AddTicks(915), "Сплата оренди за квартиру власнику", false, "Оренда квартири" },
                    { new Guid("8e9706b5-07c5-46f8-a3e4-fadcd563c012"), new DateTime(2025, 7, 1, 13, 47, 19, 633, DateTimeKind.Local).AddTicks(975), new DateTime(2025, 7, 1, 13, 47, 19, 633, DateTimeKind.Local).AddTicks(977), "Лікарні, аптеки", false, "Здоров'я" },
                    { new Guid("96c3900c-ff5a-4d77-9061-03f745c191ba"), new DateTime(2025, 7, 1, 13, 47, 19, 633, DateTimeKind.Local).AddTicks(938), new DateTime(2025, 7, 1, 13, 47, 19, 633, DateTimeKind.Local).AddTicks(940), "Оплата за товари для харчування", false, "Харчування" },
                    { new Guid("ae2e559f-4c75-4ba1-8bb8-030dd78af3ca"), new DateTime(2025, 7, 1, 13, 47, 19, 633, DateTimeKind.Local).AddTicks(982), new DateTime(2025, 7, 1, 13, 47, 19, 633, DateTimeKind.Local).AddTicks(984), "Покупки для підвищення комфорту в житлі", false, "Житло" },
                    { new Guid("fb0d0a4f-6ba8-4e85-a520-a1825e78a65a"), new DateTime(2025, 7, 1, 13, 47, 19, 633, DateTimeKind.Local).AddTicks(963), new DateTime(2025, 7, 1, 13, 47, 19, 633, DateTimeKind.Local).AddTicks(965), "Оплата тільки за одяг", false, "Одяг" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_ClientId",
                table: "Accounts",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_CardMaskedPan_AccountId",
                table: "CardMaskedPan",
                column: "AccountId");

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

            migrationBuilder.CreateIndex(
                name: "IX_mm_users_categories_CategoryId",
                schema: "many_to_many",
                table: "mm_users_categories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_mm_users_categories_UserId_CategoryId",
                schema: "many_to_many",
                table: "mm_users_categories",
                columns: new[] { "UserId", "CategoryId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardMaskedPan");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "mm_users_categories",
                schema: "many_to_many");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
