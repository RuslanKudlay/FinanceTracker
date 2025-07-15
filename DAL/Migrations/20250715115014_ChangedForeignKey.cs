using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangedForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_FamilyGroups_FamilyGroupId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_FamilyGroupId",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("03a9ea38-0fbf-48b8-84ec-99dfe374b177"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0e5fb646-bd11-4599-8101-1954e4cd6262"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("205d8d6c-6626-4926-83db-7311180bffb1"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("209f62a8-629b-4ec5-a1fd-5c4dd350c811"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("23a87473-8a8d-45b0-b7c0-4a464b12701b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("357af260-56f7-4fd0-aa50-f0c64d08d863"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("74ce8132-e7cf-46b8-afc0-ad628956efee"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a4562db5-0230-4c4a-bdb2-e23c992d4714"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a6cf6e0e-13f3-4c5d-aadd-29f3f4ad177e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("edf5fee5-8ce9-4538-be11-2427a9691286"));

            migrationBuilder.DropColumn(
                name: "FamilyGroupId",
                table: "Users");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "FamilyGroupId",
                table: "Users",
                type: "uuid",
                nullable: true);

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

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: new Guid("441f3b9e-c955-4ca8-b6c5-59a31d2893f9"),
                column: "DateCreate",
                value: new DateTime(2025, 7, 2, 14, 13, 36, 329, DateTimeKind.Local).AddTicks(3159));

            migrationBuilder.CreateIndex(
                name: "IX_Users_FamilyGroupId",
                table: "Users",
                column: "FamilyGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_FamilyGroups_FamilyGroupId",
                table: "Users",
                column: "FamilyGroupId",
                principalTable: "FamilyGroups",
                principalColumn: "Id");
        }
    }
}
