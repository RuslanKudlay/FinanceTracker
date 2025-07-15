using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class NullableCodeFamilyGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0422a38d-ffb7-41e7-aa9e-cd735c4fd2df"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2164b3c0-472d-4d1b-9033-79554bd28db0"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("336cb732-14bf-4a99-95d5-6d0019002b50"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("34217df6-a259-4846-8fb6-e9fd09df9f85"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9800d227-8f05-4440-a573-2939f29900b2"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9c8b63bd-7f87-4856-bd98-d9dde4b45daa"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a04ef17c-05fe-4c9c-82f7-e7f170d2d824"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("dbc2eb13-bd69-469b-b72a-e503aff811f5"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f0869212-d701-4566-9e61-139c76c894a2"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("fba26bb5-a04f-42cd-a23c-c4d67e0e1182"));

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "FamilyGroups",
                type: "text",
                nullable: true,
                comment: "Код групи",
                oldClrType: typeof(string),
                oldType: "text");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "FamilyGroups",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true,
                oldComment: "Код групи");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "DateCreate", "DateUpdate", "Description", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("0422a38d-ffb7-41e7-aa9e-cd735c4fd2df"), new DateTime(2025, 7, 15, 14, 59, 24, 448, DateTimeKind.Local).AddTicks(4530), new DateTime(2025, 7, 15, 14, 59, 24, 448, DateTimeKind.Local).AddTicks(4533), "Оплата за одяг, або інші речі (КОМФІ, ТА-ДА, АВРОРА)", false, "Шопінг" },
                    { new Guid("2164b3c0-472d-4d1b-9033-79554bd28db0"), new DateTime(2025, 7, 15, 14, 59, 24, 448, DateTimeKind.Local).AddTicks(4572), new DateTime(2025, 7, 15, 14, 59, 24, 448, DateTimeKind.Local).AddTicks(4574), "Лікарні, аптеки", false, "Здоров'я" },
                    { new Guid("336cb732-14bf-4a99-95d5-6d0019002b50"), new DateTime(2025, 7, 15, 14, 59, 24, 446, DateTimeKind.Local).AddTicks(4279), new DateTime(2025, 7, 15, 14, 59, 24, 448, DateTimeKind.Local).AddTicks(3060), "Сплата громадського транспорту, таксі", false, "Транспорт" },
                    { new Guid("34217df6-a259-4846-8fb6-e9fd09df9f85"), new DateTime(2025, 7, 15, 14, 59, 24, 448, DateTimeKind.Local).AddTicks(4446), new DateTime(2025, 7, 15, 14, 59, 24, 448, DateTimeKind.Local).AddTicks(4460), "Сплата оренди за квартиру власнику", false, "Оренда квартири" },
                    { new Guid("9800d227-8f05-4440-a573-2939f29900b2"), new DateTime(2025, 7, 15, 14, 59, 24, 448, DateTimeKind.Local).AddTicks(4579), new DateTime(2025, 7, 15, 14, 59, 24, 448, DateTimeKind.Local).AddTicks(4581), "Покупки для підвищення комфорту в житлі", false, "Житло" },
                    { new Guid("9c8b63bd-7f87-4856-bd98-d9dde4b45daa"), new DateTime(2025, 7, 15, 14, 59, 24, 448, DateTimeKind.Local).AddTicks(4566), new DateTime(2025, 7, 15, 14, 59, 24, 448, DateTimeKind.Local).AddTicks(4568), "", false, "Краса та гігієна" },
                    { new Guid("a04ef17c-05fe-4c9c-82f7-e7f170d2d824"), new DateTime(2025, 7, 15, 14, 59, 24, 448, DateTimeKind.Local).AddTicks(4466), new DateTime(2025, 7, 15, 14, 59, 24, 448, DateTimeKind.Local).AddTicks(4467), "Електроенергія, тепло, ОСББ/ЖЕК, дофомон, ліфт, вода...", false, "Комунальні платежі" },
                    { new Guid("dbc2eb13-bd69-469b-b72a-e503aff811f5"), new DateTime(2025, 7, 15, 14, 59, 24, 448, DateTimeKind.Local).AddTicks(4561), new DateTime(2025, 7, 15, 14, 59, 24, 448, DateTimeKind.Local).AddTicks(4563), "Оплата тільки за одяг", false, "Одяг" },
                    { new Guid("f0869212-d701-4566-9e61-139c76c894a2"), new DateTime(2025, 7, 15, 14, 59, 24, 448, DateTimeKind.Local).AddTicks(4555), new DateTime(2025, 7, 15, 14, 59, 24, 448, DateTimeKind.Local).AddTicks(4557), "Ремонт, ТО, заправка...", false, "Автомобіль" },
                    { new Guid("fba26bb5-a04f-42cd-a23c-c4d67e0e1182"), new DateTime(2025, 7, 15, 14, 59, 24, 448, DateTimeKind.Local).AddTicks(4471), new DateTime(2025, 7, 15, 14, 59, 24, 448, DateTimeKind.Local).AddTicks(4473), "Оплата за товари для харчування", false, "Харчування" }
                });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("441f3b9e-c955-4ca8-b6c5-59a31d2893f9"),
                column: "DateCreate",
                value: new DateTime(2025, 7, 15, 14, 59, 24, 454, DateTimeKind.Local).AddTicks(7568));
        }
    }
}
