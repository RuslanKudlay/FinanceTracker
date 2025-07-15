using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedIsEnabledGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3f10c83e-db6d-4f92-959b-50bf20555cb6"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4dece3eb-9dfa-4b05-8cec-241fb4c09a3e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5d5a012c-84e4-47bf-8847-6388c4aab226"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("83ca0182-6d2c-43ad-9e3a-ec5241108260"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("92f5aa1a-16c5-4137-a87f-231ad6e4430a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c1f4396c-bc63-4757-ad49-6357a794d757"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c39df8ae-68a3-48a8-9803-988aa84b5e13"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("cc5489b1-a320-4cac-9f45-37ec30275588"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d201e74e-ed9b-45ce-967d-6fb69acdfd12"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f1216c1a-5e1e-4c9d-9a6f-41c5d0ac0faf"));

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabledGroup",
                table: "FamilyGroups",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                comment: "Чи ввімкнена група");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "DateCreate", "DateUpdate", "Description", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("0ecca6dd-a4a1-4284-92bd-9d0d14947060"), new DateTime(2025, 7, 15, 15, 43, 36, 872, DateTimeKind.Local).AddTicks(2583), new DateTime(2025, 7, 15, 15, 43, 36, 872, DateTimeKind.Local).AddTicks(2596), "Сплата оренди за квартиру власнику", false, "Оренда квартири" },
                    { new Guid("33e59bbf-aec7-4fca-af13-dc8385bca6dd"), new DateTime(2025, 7, 15, 15, 43, 36, 872, DateTimeKind.Local).AddTicks(2635), new DateTime(2025, 7, 15, 15, 43, 36, 872, DateTimeKind.Local).AddTicks(2637), "Оплата тільки за одяг", false, "Одяг" },
                    { new Guid("42689a96-7952-49eb-a1d6-a8fe28119001"), new DateTime(2025, 7, 15, 15, 43, 36, 870, DateTimeKind.Local).AddTicks(2260), new DateTime(2025, 7, 15, 15, 43, 36, 872, DateTimeKind.Local).AddTicks(1217), "Сплата громадського транспорту, таксі", false, "Транспорт" },
                    { new Guid("4690f202-b21f-4022-a1b2-4c714a6e1b4a"), new DateTime(2025, 7, 15, 15, 43, 36, 872, DateTimeKind.Local).AddTicks(2602), new DateTime(2025, 7, 15, 15, 43, 36, 872, DateTimeKind.Local).AddTicks(2604), "Електроенергія, тепло, ОСББ/ЖЕК, дофомон, ліфт, вода...", false, "Комунальні платежі" },
                    { new Guid("50cbdd76-f103-4e08-9777-3017eb888dbe"), new DateTime(2025, 7, 15, 15, 43, 36, 872, DateTimeKind.Local).AddTicks(2629), new DateTime(2025, 7, 15, 15, 43, 36, 872, DateTimeKind.Local).AddTicks(2631), "Ремонт, ТО, заправка...", false, "Автомобіль" },
                    { new Guid("62ec285e-403e-4d7f-9185-7ccc0644c492"), new DateTime(2025, 7, 15, 15, 43, 36, 872, DateTimeKind.Local).AddTicks(2607), new DateTime(2025, 7, 15, 15, 43, 36, 872, DateTimeKind.Local).AddTicks(2609), "Оплата за товари для харчування", false, "Харчування" },
                    { new Guid("6aed0586-07e0-4b34-b99c-5a6a90471ddd"), new DateTime(2025, 7, 15, 15, 43, 36, 872, DateTimeKind.Local).AddTicks(2613), new DateTime(2025, 7, 15, 15, 43, 36, 872, DateTimeKind.Local).AddTicks(2615), "Оплата за одяг, або інші речі (КОМФІ, ТА-ДА, АВРОРА)", false, "Шопінг" },
                    { new Guid("b2166ae0-1bbd-49a7-b33f-6a2ec1db3e22"), new DateTime(2025, 7, 15, 15, 43, 36, 872, DateTimeKind.Local).AddTicks(2646), new DateTime(2025, 7, 15, 15, 43, 36, 872, DateTimeKind.Local).AddTicks(2648), "Лікарні, аптеки", false, "Здоров'я" },
                    { new Guid("bd721e49-4198-4688-850f-79fa6120760d"), new DateTime(2025, 7, 15, 15, 43, 36, 872, DateTimeKind.Local).AddTicks(2640), new DateTime(2025, 7, 15, 15, 43, 36, 872, DateTimeKind.Local).AddTicks(2642), "", false, "Краса та гігієна" },
                    { new Guid("c94858f3-da61-465f-90fb-d2592dc9e36c"), new DateTime(2025, 7, 15, 15, 43, 36, 872, DateTimeKind.Local).AddTicks(2657), new DateTime(2025, 7, 15, 15, 43, 36, 872, DateTimeKind.Local).AddTicks(2659), "Покупки для підвищення комфорту в житлі", false, "Житло" }
                });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("441f3b9e-c955-4ca8-b6c5-59a31d2893f9"),
                column: "DateCreate",
                value: new DateTime(2025, 7, 15, 15, 43, 36, 878, DateTimeKind.Local).AddTicks(5698));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0ecca6dd-a4a1-4284-92bd-9d0d14947060"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("33e59bbf-aec7-4fca-af13-dc8385bca6dd"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("42689a96-7952-49eb-a1d6-a8fe28119001"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4690f202-b21f-4022-a1b2-4c714a6e1b4a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("50cbdd76-f103-4e08-9777-3017eb888dbe"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("62ec285e-403e-4d7f-9185-7ccc0644c492"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6aed0586-07e0-4b34-b99c-5a6a90471ddd"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b2166ae0-1bbd-49a7-b33f-6a2ec1db3e22"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bd721e49-4198-4688-850f-79fa6120760d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c94858f3-da61-465f-90fb-d2592dc9e36c"));

            migrationBuilder.DropColumn(
                name: "IsEnabledGroup",
                table: "FamilyGroups");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "DateCreate", "DateUpdate", "Description", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("3f10c83e-db6d-4f92-959b-50bf20555cb6"), new DateTime(2025, 7, 15, 15, 15, 49, 444, DateTimeKind.Local).AddTicks(6849), new DateTime(2025, 7, 15, 15, 15, 49, 444, DateTimeKind.Local).AddTicks(6851), "", false, "Краса та гігієна" },
                    { new Guid("4dece3eb-9dfa-4b05-8cec-241fb4c09a3e"), new DateTime(2025, 7, 15, 15, 15, 49, 444, DateTimeKind.Local).AddTicks(6800), new DateTime(2025, 7, 15, 15, 15, 49, 444, DateTimeKind.Local).AddTicks(6802), "Електроенергія, тепло, ОСББ/ЖЕК, дофомон, ліфт, вода...", false, "Комунальні платежі" },
                    { new Guid("5d5a012c-84e4-47bf-8847-6388c4aab226"), new DateTime(2025, 7, 15, 15, 15, 49, 444, DateTimeKind.Local).AddTicks(6855), new DateTime(2025, 7, 15, 15, 15, 49, 444, DateTimeKind.Local).AddTicks(6856), "Лікарні, аптеки", false, "Здоров'я" },
                    { new Guid("83ca0182-6d2c-43ad-9e3a-ec5241108260"), new DateTime(2025, 7, 15, 15, 15, 49, 444, DateTimeKind.Local).AddTicks(6827), new DateTime(2025, 7, 15, 15, 15, 49, 444, DateTimeKind.Local).AddTicks(6829), "Ремонт, ТО, заправка...", false, "Автомобіль" },
                    { new Guid("92f5aa1a-16c5-4137-a87f-231ad6e4430a"), new DateTime(2025, 7, 15, 15, 15, 49, 444, DateTimeKind.Local).AddTicks(6833), new DateTime(2025, 7, 15, 15, 15, 49, 444, DateTimeKind.Local).AddTicks(6834), "Оплата тільки за одяг", false, "Одяг" },
                    { new Guid("c1f4396c-bc63-4757-ad49-6357a794d757"), new DateTime(2025, 7, 15, 15, 15, 49, 444, DateTimeKind.Local).AddTicks(6861), new DateTime(2025, 7, 15, 15, 15, 49, 444, DateTimeKind.Local).AddTicks(6863), "Покупки для підвищення комфорту в житлі", false, "Житло" },
                    { new Guid("c39df8ae-68a3-48a8-9803-988aa84b5e13"), new DateTime(2025, 7, 15, 15, 15, 49, 444, DateTimeKind.Local).AddTicks(6781), new DateTime(2025, 7, 15, 15, 15, 49, 444, DateTimeKind.Local).AddTicks(6795), "Сплата оренди за квартиру власнику", false, "Оренда квартири" },
                    { new Guid("cc5489b1-a320-4cac-9f45-37ec30275588"), new DateTime(2025, 7, 15, 15, 15, 49, 441, DateTimeKind.Local).AddTicks(7476), new DateTime(2025, 7, 15, 15, 15, 49, 444, DateTimeKind.Local).AddTicks(5432), "Сплата громадського транспорту, таксі", false, "Транспорт" },
                    { new Guid("d201e74e-ed9b-45ce-967d-6fb69acdfd12"), new DateTime(2025, 7, 15, 15, 15, 49, 444, DateTimeKind.Local).AddTicks(6805), new DateTime(2025, 7, 15, 15, 15, 49, 444, DateTimeKind.Local).AddTicks(6807), "Оплата за товари для харчування", false, "Харчування" },
                    { new Guid("f1216c1a-5e1e-4c9d-9a6f-41c5d0ac0faf"), new DateTime(2025, 7, 15, 15, 15, 49, 444, DateTimeKind.Local).AddTicks(6811), new DateTime(2025, 7, 15, 15, 15, 49, 444, DateTimeKind.Local).AddTicks(6813), "Оплата за одяг, або інші речі (КОМФІ, ТА-ДА, АВРОРА)", false, "Шопінг" }
                });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("441f3b9e-c955-4ca8-b6c5-59a31d2893f9"),
                column: "DateCreate",
                value: new DateTime(2025, 7, 15, 15, 15, 49, 453, DateTimeKind.Local).AddTicks(2446));
        }
    }
}
