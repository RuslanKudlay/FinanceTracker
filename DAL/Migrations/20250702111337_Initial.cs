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
                name: "FamilyGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Первинний ключ"),
                    Name = table.Column<string>(type: "text", nullable: false, comment: "Назва групи"),
                    DateCreate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, comment: "Дата створення"),
                    DateUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, comment: "Дата оновлення"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: true, comment: "Прапор видалення")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Первинний ключ"),
                    Key = table.Column<string>(type: "text", nullable: false, comment: "Ключ налаштування"),
                    Value = table.Column<string>(type: "text", nullable: false, comment: "Значення налаштування"),
                    Description = table.Column<string>(type: "text", nullable: false, comment: "Опис"),
                    Type = table.Column<string>(type: "text", nullable: false, comment: "Тип даних налаштування"),
                    DateCreate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, comment: "Дата створення"),
                    DateUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, comment: "Дата оновлення"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: true, comment: "Прапор видалення")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Первинний ключ"),
                    FullName = table.Column<string>(type: "text", nullable: true, comment: "Повне ім'я"),
                    Email = table.Column<string>(type: "text", nullable: false, comment: "Email"),
                    PasswordHash = table.Column<string>(type: "text", nullable: false, comment: "Хеш паролю"),
                    IsVisibleInGroup = table.Column<bool>(type: "boolean", nullable: false, comment: "Чи показувати в групі для спільного балансу"),
                    FamilyGroupId = table.Column<Guid>(type: "uuid", nullable: true),
                    DateCreate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, comment: "Дата створення"),
                    DateUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, comment: "Дата оновлення"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: true, comment: "Прапор видалення")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_FamilyGroups_FamilyGroupId",
                        column: x => x.FamilyGroupId,
                        principalTable: "FamilyGroups",
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
                name: "UserSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Первинний ключ"),
                    Key = table.Column<string>(type: "text", nullable: false, comment: "Ключ налаштування"),
                    Value = table.Column<string>(type: "text", nullable: false, comment: "Значення налаштування"),
                    Description = table.Column<string>(type: "text", nullable: false, comment: "Опис"),
                    Type = table.Column<string>(type: "text", nullable: false, comment: "Тип даних налаштування"),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true, comment: "Ключ користвача"),
                    SettingId = table.Column<Guid>(type: "uuid", nullable: true, comment: "Ключ налаштування"),
                    DateCreate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, comment: "Дата створення"),
                    DateUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, comment: "Дата оновлення"),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: true, comment: "Прапор видалення")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSettings_Settings_SettingId",
                        column: x => x.SettingId,
                        principalTable: "Settings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserSettings_Users_UserId",
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
                name: "mm_users_groups",
                schema: "many_to_many",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    FamilyGroupId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mm_users_groups", x => new { x.UserId, x.FamilyGroupId });
                    table.ForeignKey(
                        name: "FK_mm_users_groups_FamilyGroups_FamilyGroupId",
                        column: x => x.FamilyGroupId,
                        principalTable: "FamilyGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mm_users_groups_Users_UserId",
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
                    MonoAccountId = table.Column<string>(type: "text", nullable: false, comment: "Account id для транзакцій"),
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
                    { new Guid("03a9ea38-0fbf-48b8-84ec-99dfe374b177"), new DateTime(2025, 7, 2, 14, 13, 36, 322, DateTimeKind.Local).AddTicks(5977), new DateTime(2025, 7, 2, 14, 13, 36, 322, DateTimeKind.Local).AddTicks(5979), "Електроенергія, тепло, ОСББ/ЖЕК, дофомон, ліфт, вода...", false, "Комунальні платежі" },
                    { new Guid("0e5fb646-bd11-4599-8101-1954e4cd6262"), new DateTime(2025, 7, 2, 14, 13, 36, 322, DateTimeKind.Local).AddTicks(6000), new DateTime(2025, 7, 2, 14, 13, 36, 322, DateTimeKind.Local).AddTicks(6002), "Оплата за одяг, або інші речі (КОМФІ, ТА-ДА, АВРОРА)", false, "Шопінг" },
                    { new Guid("205d8d6c-6626-4926-83db-7311180bffb1"), new DateTime(2025, 7, 2, 14, 13, 36, 320, DateTimeKind.Local).AddTicks(858), new DateTime(2025, 7, 2, 14, 13, 36, 322, DateTimeKind.Local).AddTicks(4498), "Сплата громадського транспорту, таксі", false, "Транспорт" },
                    { new Guid("209f62a8-629b-4ec5-a1fd-5c4dd350c811"), new DateTime(2025, 7, 2, 14, 13, 36, 322, DateTimeKind.Local).AddTicks(6015), new DateTime(2025, 7, 2, 14, 13, 36, 322, DateTimeKind.Local).AddTicks(6017), "Ремонт, ТО, заправка...", false, "Автомобіль" },
                    { new Guid("23a87473-8a8d-45b0-b7c0-4a464b12701b"), new DateTime(2025, 7, 2, 14, 13, 36, 322, DateTimeKind.Local).AddTicks(6026), new DateTime(2025, 7, 2, 14, 13, 36, 322, DateTimeKind.Local).AddTicks(6028), "", false, "Краса та гігієна" },
                    { new Guid("357af260-56f7-4fd0-aa50-f0c64d08d863"), new DateTime(2025, 7, 2, 14, 13, 36, 322, DateTimeKind.Local).AddTicks(5959), new DateTime(2025, 7, 2, 14, 13, 36, 322, DateTimeKind.Local).AddTicks(5972), "Сплата оренди за квартиру власнику", false, "Оренда квартири" },
                    { new Guid("74ce8132-e7cf-46b8-afc0-ad628956efee"), new DateTime(2025, 7, 2, 14, 13, 36, 322, DateTimeKind.Local).AddTicks(6021), new DateTime(2025, 7, 2, 14, 13, 36, 322, DateTimeKind.Local).AddTicks(6022), "Оплата тільки за одяг", false, "Одяг" },
                    { new Guid("a4562db5-0230-4c4a-bdb2-e23c992d4714"), new DateTime(2025, 7, 2, 14, 13, 36, 322, DateTimeKind.Local).AddTicks(6039), new DateTime(2025, 7, 2, 14, 13, 36, 322, DateTimeKind.Local).AddTicks(6041), "Покупки для підвищення комфорту в житлі", false, "Житло" },
                    { new Guid("a6cf6e0e-13f3-4c5d-aadd-29f3f4ad177e"), new DateTime(2025, 7, 2, 14, 13, 36, 322, DateTimeKind.Local).AddTicks(5983), new DateTime(2025, 7, 2, 14, 13, 36, 322, DateTimeKind.Local).AddTicks(5985), "Оплата за товари для харчування", false, "Харчування" },
                    { new Guid("edf5fee5-8ce9-4538-be11-2427a9691286"), new DateTime(2025, 7, 2, 14, 13, 36, 322, DateTimeKind.Local).AddTicks(6032), new DateTime(2025, 7, 2, 14, 13, 36, 322, DateTimeKind.Local).AddTicks(6033), "Лікарні, аптеки", false, "Здоров'я" }
                });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "Type", "DateCreate", "DateUpdate", "Description", "IsDeleted", "Key", "Value" },
                values: new object[] { new Guid("441f3b9e-c955-4ca8-b6c5-59a31d2893f9"), "String", new DateTime(2025, 7, 2, 14, 13, 36, 329, DateTimeKind.Local).AddTicks(3159), null, "Токен для інтеграції з монобанк", false, "MonoToken", "DefaultValue" });

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
                name: "IX_Transactions_UserId",
                table: "Transactions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSettings_SettingId",
                table: "UserSettings",
                column: "SettingId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSettings_UserId",
                table: "UserSettings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_FamilyGroupId",
                table: "Users",
                column: "FamilyGroupId");

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

            migrationBuilder.CreateIndex(
                name: "IX_mm_users_groups_FamilyGroupId",
                schema: "many_to_many",
                table: "mm_users_groups",
                column: "FamilyGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_mm_users_groups_UserId_FamilyGroupId",
                schema: "many_to_many",
                table: "mm_users_groups",
                columns: new[] { "UserId", "FamilyGroupId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardMaskedPan");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "UserSettings");

            migrationBuilder.DropTable(
                name: "mm_users_categories",
                schema: "many_to_many");

            migrationBuilder.DropTable(
                name: "mm_users_groups",
                schema: "many_to_many");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "FamilyGroups");
        }
    }
}
