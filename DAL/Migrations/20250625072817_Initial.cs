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
                    DateCreate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "Дата створення"),
                    DateUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "Дата оновлення"),
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
                    DateCreate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "Дата створення"),
                    DateUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "Дата оновлення"),
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
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Первинний ключ"),
                    TransactionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Дата транзакції"),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false, comment: "Сума транзакції"),
                    Note = table.Column<string>(type: "text", nullable: true, comment: "Коментар до транзакції"),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true, comment: "Тип транзакції"),
                    Source = table.Column<string>(type: "text", nullable: true, comment: "Джерело транзакції"),
                    DateCreate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "Дата створення"),
                    DateUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, comment: "Дата оновлення"),
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

            migrationBuilder.CreateIndex(
                name: "IX_Categories_UserId",
                table: "Categories",
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
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
