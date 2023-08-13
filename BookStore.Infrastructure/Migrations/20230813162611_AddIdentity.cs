using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Translator_TranslatorId",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderHeader_User_UserId",
                table: "OrderHeader");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_Book_TranslatorId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "DateCreation",
                table: "Translator");

            migrationBuilder.DropColumn(
                name: "DateModification",
                table: "Translator");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Translator");

            migrationBuilder.DropColumn(
                name: "DateCreation",
                table: "Publisher");

            migrationBuilder.DropColumn(
                name: "DateModification",
                table: "Publisher");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Publisher");

            migrationBuilder.DropColumn(
                name: "DateCreation",
                table: "OrderHeader");

            migrationBuilder.DropColumn(
                name: "DateModification",
                table: "OrderHeader");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "OrderHeader");

            migrationBuilder.DropColumn(
                name: "DateCreation",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "DateModification",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "DateCreation",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "DateModification",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "TranslatorId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "DateCreation",
                table: "Author");

            migrationBuilder.DropColumn(
                name: "DateModification",
                table: "Author");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Author");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "OrderHeader",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "OrderHeader",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 8, 13, 19, 56, 10, 990, DateTimeKind.Local).AddTicks(2098),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 7, 26, 13, 27, 40, 983, DateTimeKind.Local).AddTicks(4092));

            migrationBuilder.CreateTable(
                name: "BookTranslator",
                columns: table => new
                {
                    BooksId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TranslatorsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookTranslator", x => new { x.BooksId, x.TranslatorsId });
                    table.ForeignKey(
                        name: "FK_BookTranslator_Book_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookTranslator_Translator_TranslatorsId",
                        column: x => x.TranslatorsId,
                        principalTable: "Translator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookTranslator_TranslatorsId",
                table: "BookTranslator",
                column: "TranslatorsId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHeader_AspNetUsers_UserId",
                table: "OrderHeader",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderHeader_AspNetUsers_UserId",
                table: "OrderHeader");

            migrationBuilder.DropTable(
                name: "BookTranslator");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreation",
                table: "Translator",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 26, 13, 27, 40, 983, DateTimeKind.Local).AddTicks(8465));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModification",
                table: "Translator",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 26, 13, 27, 40, 983, DateTimeKind.Local).AddTicks(8793));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Translator",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreation",
                table: "Publisher",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 26, 13, 27, 40, 983, DateTimeKind.Local).AddTicks(6501));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModification",
                table: "Publisher",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 26, 13, 27, 40, 983, DateTimeKind.Local).AddTicks(6772));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Publisher",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "OrderHeader",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "OrderHeader",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 7, 26, 13, 27, 40, 983, DateTimeKind.Local).AddTicks(4092),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 8, 13, 19, 56, 10, 990, DateTimeKind.Local).AddTicks(2098));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreation",
                table: "OrderHeader",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 26, 13, 27, 40, 983, DateTimeKind.Local).AddTicks(4495));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModification",
                table: "OrderHeader",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 26, 13, 27, 40, 983, DateTimeKind.Local).AddTicks(4734));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "OrderHeader",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreation",
                table: "OrderDetail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 26, 13, 27, 40, 983, DateTimeKind.Local).AddTicks(1988));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModification",
                table: "OrderDetail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 26, 13, 27, 40, 983, DateTimeKind.Local).AddTicks(2331));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "OrderDetail",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreation",
                table: "Book",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 26, 13, 27, 40, 982, DateTimeKind.Local).AddTicks(8290));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModification",
                table: "Book",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 26, 13, 27, 40, 982, DateTimeKind.Local).AddTicks(8646));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Book",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "TranslatorId",
                table: "Book",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreation",
                table: "Author",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 26, 13, 27, 40, 982, DateTimeKind.Local).AddTicks(6084));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModification",
                table: "Author",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 26, 13, 27, 40, 982, DateTimeKind.Local).AddTicks(6394));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Author",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 7, 26, 13, 27, 40, 984, DateTimeKind.Local).AddTicks(750)),
                    DateModification = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 7, 26, 13, 27, 40, 984, DateTimeKind.Local).AddTicks(1061)),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    NationalId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_TranslatorId",
                table: "Book",
                column: "TranslatorId");

            migrationBuilder.CreateIndex(
                name: "IX_User_BookId",
                table: "User",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Translator_TranslatorId",
                table: "Book",
                column: "TranslatorId",
                principalTable: "Translator",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHeader_User_UserId",
                table: "OrderHeader",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
