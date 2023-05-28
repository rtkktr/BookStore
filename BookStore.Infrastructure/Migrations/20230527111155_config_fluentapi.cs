using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class config_fluentapi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Publishers_PublisherId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Translators_TranslatorId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Books_BookId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_OrderHeaders_OrderHeaderId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderHeaders_Users_UserId",
                table: "OrderHeaders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Translators",
                table: "Translators");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Publishers",
                table: "Publishers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderHeaders",
                table: "OrderHeaders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_BookId",
                table: "OrderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_AuthorId",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authors",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Books");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Translators",
                newName: "Translator");

            migrationBuilder.RenameTable(
                name: "Publishers",
                newName: "Publisher");

            migrationBuilder.RenameTable(
                name: "OrderHeaders",
                newName: "OrderHeader");

            migrationBuilder.RenameTable(
                name: "OrderDetails",
                newName: "OrderDetail");

            migrationBuilder.RenameTable(
                name: "Books",
                newName: "Book");

            migrationBuilder.RenameTable(
                name: "Authors",
                newName: "Author");

            migrationBuilder.RenameIndex(
                name: "IX_OrderHeaders_UserId",
                table: "OrderHeader",
                newName: "IX_OrderHeader_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_OrderHeaderId",
                table: "OrderDetail",
                newName: "IX_OrderDetail_OrderHeaderId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_TranslatorId",
                table: "Book",
                newName: "IX_Book_TranslatorId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_PublisherId",
                table: "Book",
                newName: "IX_Book_PublisherId");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "User",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "User",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NationalId",
                table: "User",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "User",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BookId",
                table: "User",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreation",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 27, 14, 41, 55, 506, DateTimeKind.Local).AddTicks(2837));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModification",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 27, 14, 41, 55, 506, DateTimeKind.Local).AddTicks(3122));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreation",
                table: "Translator",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 27, 14, 41, 55, 506, DateTimeKind.Local).AddTicks(1454));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModification",
                table: "Translator",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 27, 14, 41, 55, 506, DateTimeKind.Local).AddTicks(1684));

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
                defaultValue: new DateTime(2023, 5, 27, 14, 41, 55, 506, DateTimeKind.Local).AddTicks(352));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModification",
                table: "Publisher",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 27, 14, 41, 55, 506, DateTimeKind.Local).AddTicks(629));

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
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "OrderHeader",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 5, 27, 14, 41, 55, 505, DateTimeKind.Local).AddTicks(8965),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreation",
                table: "OrderHeader",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 27, 14, 41, 55, 505, DateTimeKind.Local).AddTicks(9259));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModification",
                table: "OrderHeader",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 27, 14, 41, 55, 505, DateTimeKind.Local).AddTicks(9518));

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
                defaultValue: new DateTime(2023, 5, 27, 14, 41, 55, 505, DateTimeKind.Local).AddTicks(7749));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModification",
                table: "OrderDetail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 27, 14, 41, 55, 505, DateTimeKind.Local).AddTicks(8093));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "OrderDetail",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<Guid>(
                name: "TranslatorId",
                table: "Book",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "ShortDescription",
                table: "Book",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<Guid>(
                name: "PublisherId",
                table: "Book",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreation",
                table: "Book",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 27, 14, 41, 55, 505, DateTimeKind.Local).AddTicks(4340));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModification",
                table: "Book",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 27, 14, 41, 55, 505, DateTimeKind.Local).AddTicks(4640));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Book",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreation",
                table: "Author",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 27, 14, 41, 55, 505, DateTimeKind.Local).AddTicks(3052));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModification",
                table: "Author",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 27, 14, 41, 55, 505, DateTimeKind.Local).AddTicks(3383));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Author",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Translator",
                table: "Translator",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Publisher",
                table: "Publisher",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderHeader",
                table: "OrderHeader",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetail",
                table: "OrderDetail",
                columns: new[] { "BookId", "OrderHeaderId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Book",
                table: "Book",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Author",
                table: "Author",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AuthorBook",
                columns: table => new
                {
                    AuthorsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BooksId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBook", x => new { x.AuthorsId, x.BooksId });
                    table.ForeignKey(
                        name: "FK_AuthorBook_Author_AuthorsId",
                        column: x => x.AuthorsId,
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorBook_Book_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_BookId",
                table: "User",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBook_BooksId",
                table: "AuthorBook",
                column: "BooksId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Publisher_PublisherId",
                table: "Book",
                column: "PublisherId",
                principalTable: "Publisher",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Translator_TranslatorId",
                table: "Book",
                column: "TranslatorId",
                principalTable: "Translator",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Book_BookId",
                table: "OrderDetail",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_OrderHeader_OrderHeaderId",
                table: "OrderDetail",
                column: "OrderHeaderId",
                principalTable: "OrderHeader",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHeader_User_UserId",
                table: "OrderHeader",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Book_BookId",
                table: "User",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Publisher_PublisherId",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_Book_Translator_TranslatorId",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Book_BookId",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_OrderHeader_OrderHeaderId",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderHeader_User_UserId",
                table: "OrderHeader");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Book_BookId",
                table: "User");

            migrationBuilder.DropTable(
                name: "AuthorBook");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_BookId",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Translator",
                table: "Translator");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Publisher",
                table: "Publisher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderHeader",
                table: "OrderHeader");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetail",
                table: "OrderDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Book",
                table: "Book");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Author",
                table: "Author");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "DateCreation",
                table: "User");

            migrationBuilder.DropColumn(
                name: "DateModification",
                table: "User");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "User");

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
                name: "DateCreation",
                table: "Author");

            migrationBuilder.DropColumn(
                name: "DateModification",
                table: "Author");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Author");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Translator",
                newName: "Translators");

            migrationBuilder.RenameTable(
                name: "Publisher",
                newName: "Publishers");

            migrationBuilder.RenameTable(
                name: "OrderHeader",
                newName: "OrderHeaders");

            migrationBuilder.RenameTable(
                name: "OrderDetail",
                newName: "OrderDetails");

            migrationBuilder.RenameTable(
                name: "Book",
                newName: "Books");

            migrationBuilder.RenameTable(
                name: "Author",
                newName: "Authors");

            migrationBuilder.RenameIndex(
                name: "IX_OrderHeader_UserId",
                table: "OrderHeaders",
                newName: "IX_OrderHeaders_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetail_OrderHeaderId",
                table: "OrderDetails",
                newName: "IX_OrderDetails_OrderHeaderId");

            migrationBuilder.RenameIndex(
                name: "IX_Book_TranslatorId",
                table: "Books",
                newName: "IX_Books_TranslatorId");

            migrationBuilder.RenameIndex(
                name: "IX_Book_PublisherId",
                table: "Books",
                newName: "IX_Books_PublisherId");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<string>(
                name: "NationalId",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "OrderHeaders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "OrderHeaders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 5, 27, 14, 41, 55, 505, DateTimeKind.Local).AddTicks(8965));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "OrderDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "TranslatorId",
                table: "Books",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ShortDescription",
                table: "Books",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "PublisherId",
                table: "Books",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                table: "Books",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Translators",
                table: "Translators",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Publishers",
                table: "Publishers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderHeaders",
                table: "OrderHeaders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authors",
                table: "Authors",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_BookId",
                table: "OrderDetails",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Publishers_PublisherId",
                table: "Books",
                column: "PublisherId",
                principalTable: "Publishers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Translators_TranslatorId",
                table: "Books",
                column: "TranslatorId",
                principalTable: "Translators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Books_BookId",
                table: "OrderDetails",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_OrderHeaders_OrderHeaderId",
                table: "OrderDetails",
                column: "OrderHeaderId",
                principalTable: "OrderHeaders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHeaders_Users_UserId",
                table: "OrderHeaders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
