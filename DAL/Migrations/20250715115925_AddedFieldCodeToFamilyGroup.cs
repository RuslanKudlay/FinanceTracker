using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedFieldCodeToFamilyGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("00b7cf27-0a47-489a-b3f4-8018d6b6838e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("18521460-644e-4736-8ac8-dff85f47b11c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("19c1e9b1-b48a-49df-8028-8122d70e35b9"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("24e4daa5-d257-4b22-81df-561059127442"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2a4ccd69-bc95-4f31-9a9c-f93fb24e8def"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4214a29a-07a6-4e6e-807b-27cb1bdf9aaa"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("86c9e6e1-dde0-474c-a080-10731bb21f4d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c285cb99-cc9d-497f-bf61-5b5ae8c533c6"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ec6fa397-1122-48e6-9dd1-69649c8dde73"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("fc31050a-d65b-4f54-aaa7-67d49652d5ff"));

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "FamilyGroups",
                type: "text",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Code",
                table: "FamilyGroups");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "DateCreate", "DateUpdate", "Description", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("00b7cf27-0a47-489a-b3f4-8018d6b6838e"), new DateTime(2025, 7, 15, 14, 50, 13, 301, DateTimeKind.Local).AddTicks(3996), new DateTime(2025, 7, 15, 14, 50, 13, 301, DateTimeKind.Local).AddTicks(4008), "Сплата оренди за квартиру власнику", false, "Оренда квартири" },
                    { new Guid("18521460-644e-4736-8ac8-dff85f47b11c"), new DateTime(2025, 7, 15, 14, 50, 13, 301, DateTimeKind.Local).AddTicks(4071), new DateTime(2025, 7, 15, 14, 50, 13, 301, DateTimeKind.Local).AddTicks(4073), "Лікарні, аптеки", false, "Здоров'я" },
                    { new Guid("19c1e9b1-b48a-49df-8028-8122d70e35b9"), new DateTime(2025, 7, 15, 14, 50, 13, 301, DateTimeKind.Local).AddTicks(4065), new DateTime(2025, 7, 15, 14, 50, 13, 301, DateTimeKind.Local).AddTicks(4067), "", false, "Краса та гігієна" },
                    { new Guid("24e4daa5-d257-4b22-81df-561059127442"), new DateTime(2025, 7, 15, 14, 50, 13, 301, DateTimeKind.Local).AddTicks(4014), new DateTime(2025, 7, 15, 14, 50, 13, 301, DateTimeKind.Local).AddTicks(4016), "Електроенергія, тепло, ОСББ/ЖЕК, дофомон, ліфт, вода...", false, "Комунальні платежі" },
                    { new Guid("2a4ccd69-bc95-4f31-9a9c-f93fb24e8def"), new DateTime(2025, 7, 15, 14, 50, 13, 301, DateTimeKind.Local).AddTicks(4054), new DateTime(2025, 7, 15, 14, 50, 13, 301, DateTimeKind.Local).AddTicks(4056), "Ремонт, ТО, заправка...", false, "Автомобіль" },
                    { new Guid("4214a29a-07a6-4e6e-807b-27cb1bdf9aaa"), new DateTime(2025, 7, 15, 14, 50, 13, 298, DateTimeKind.Local).AddTicks(9436), new DateTime(2025, 7, 15, 14, 50, 13, 301, DateTimeKind.Local).AddTicks(2569), "Сплата громадського транспорту, таксі", false, "Транспорт" },
                    { new Guid("86c9e6e1-dde0-474c-a080-10731bb21f4d"), new DateTime(2025, 7, 15, 14, 50, 13, 301, DateTimeKind.Local).AddTicks(4020), new DateTime(2025, 7, 15, 14, 50, 13, 301, DateTimeKind.Local).AddTicks(4022), "Оплата за товари для харчування", false, "Харчування" },
                    { new Guid("c285cb99-cc9d-497f-bf61-5b5ae8c533c6"), new DateTime(2025, 7, 15, 14, 50, 13, 301, DateTimeKind.Local).AddTicks(4078), new DateTime(2025, 7, 15, 14, 50, 13, 301, DateTimeKind.Local).AddTicks(4080), "Покупки для підвищення комфорту в житлі", false, "Житло" },
                    { new Guid("ec6fa397-1122-48e6-9dd1-69649c8dde73"), new DateTime(2025, 7, 15, 14, 50, 13, 301, DateTimeKind.Local).AddTicks(4059), new DateTime(2025, 7, 15, 14, 50, 13, 301, DateTimeKind.Local).AddTicks(4061), "Оплата тільки за одяг", false, "Одяг" },
                    { new Guid("fc31050a-d65b-4f54-aaa7-67d49652d5ff"), new DateTime(2025, 7, 15, 14, 50, 13, 301, DateTimeKind.Local).AddTicks(4025), new DateTime(2025, 7, 15, 14, 50, 13, 301, DateTimeKind.Local).AddTicks(4027), "Оплата за одяг, або інші речі (КОМФІ, ТА-ДА, АВРОРА)", false, "Шопінг" }
                });

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("441f3b9e-c955-4ca8-b6c5-59a31d2893f9"),
                column: "DateCreate",
                value: new DateTime(2025, 7, 15, 14, 50, 13, 307, DateTimeKind.Local).AddTicks(4302));
        }
    }
}
