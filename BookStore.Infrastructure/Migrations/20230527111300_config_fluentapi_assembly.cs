using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class config_fluentapi_assembly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModification",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 27, 14, 43, 0, 376, DateTimeKind.Local).AddTicks(1492),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 27, 14, 41, 55, 506, DateTimeKind.Local).AddTicks(3122));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreation",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 27, 14, 43, 0, 376, DateTimeKind.Local).AddTicks(1179),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 27, 14, 41, 55, 506, DateTimeKind.Local).AddTicks(2837));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModification",
                table: "Translator",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 27, 14, 43, 0, 375, DateTimeKind.Local).AddTicks(8844),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 27, 14, 41, 55, 506, DateTimeKind.Local).AddTicks(1684));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreation",
                table: "Translator",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 27, 14, 43, 0, 375, DateTimeKind.Local).AddTicks(8544),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 27, 14, 41, 55, 506, DateTimeKind.Local).AddTicks(1454));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModification",
                table: "Publisher",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 27, 14, 43, 0, 375, DateTimeKind.Local).AddTicks(6690),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 27, 14, 41, 55, 506, DateTimeKind.Local).AddTicks(629));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreation",
                table: "Publisher",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 27, 14, 43, 0, 375, DateTimeKind.Local).AddTicks(6399),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 27, 14, 41, 55, 506, DateTimeKind.Local).AddTicks(352));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModification",
                table: "OrderHeader",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 27, 14, 43, 0, 375, DateTimeKind.Local).AddTicks(3872),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 27, 14, 41, 55, 505, DateTimeKind.Local).AddTicks(9518));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreation",
                table: "OrderHeader",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 27, 14, 43, 0, 375, DateTimeKind.Local).AddTicks(3612),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 27, 14, 41, 55, 505, DateTimeKind.Local).AddTicks(9259));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "OrderHeader",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 5, 27, 14, 43, 0, 375, DateTimeKind.Local).AddTicks(3284),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 5, 27, 14, 41, 55, 505, DateTimeKind.Local).AddTicks(8965));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModification",
                table: "OrderDetail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 27, 14, 43, 0, 375, DateTimeKind.Local).AddTicks(1346),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 27, 14, 41, 55, 505, DateTimeKind.Local).AddTicks(8093));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreation",
                table: "OrderDetail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 27, 14, 43, 0, 375, DateTimeKind.Local).AddTicks(1009),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 27, 14, 41, 55, 505, DateTimeKind.Local).AddTicks(7749));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModification",
                table: "Book",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 27, 14, 43, 0, 374, DateTimeKind.Local).AddTicks(6201),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 27, 14, 41, 55, 505, DateTimeKind.Local).AddTicks(4640));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreation",
                table: "Book",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 27, 14, 43, 0, 374, DateTimeKind.Local).AddTicks(5838),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 27, 14, 41, 55, 505, DateTimeKind.Local).AddTicks(4340));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModification",
                table: "Author",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 27, 14, 43, 0, 374, DateTimeKind.Local).AddTicks(3837),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 27, 14, 41, 55, 505, DateTimeKind.Local).AddTicks(3383));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreation",
                table: "Author",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 27, 14, 43, 0, 374, DateTimeKind.Local).AddTicks(3507),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 27, 14, 41, 55, 505, DateTimeKind.Local).AddTicks(3052));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModification",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 27, 14, 41, 55, 506, DateTimeKind.Local).AddTicks(3122),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 27, 14, 43, 0, 376, DateTimeKind.Local).AddTicks(1492));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreation",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 27, 14, 41, 55, 506, DateTimeKind.Local).AddTicks(2837),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 27, 14, 43, 0, 376, DateTimeKind.Local).AddTicks(1179));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModification",
                table: "Translator",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 27, 14, 41, 55, 506, DateTimeKind.Local).AddTicks(1684),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 27, 14, 43, 0, 375, DateTimeKind.Local).AddTicks(8844));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreation",
                table: "Translator",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 27, 14, 41, 55, 506, DateTimeKind.Local).AddTicks(1454),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 27, 14, 43, 0, 375, DateTimeKind.Local).AddTicks(8544));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModification",
                table: "Publisher",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 27, 14, 41, 55, 506, DateTimeKind.Local).AddTicks(629),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 27, 14, 43, 0, 375, DateTimeKind.Local).AddTicks(6690));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreation",
                table: "Publisher",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 27, 14, 41, 55, 506, DateTimeKind.Local).AddTicks(352),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 27, 14, 43, 0, 375, DateTimeKind.Local).AddTicks(6399));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModification",
                table: "OrderHeader",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 27, 14, 41, 55, 505, DateTimeKind.Local).AddTicks(9518),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 27, 14, 43, 0, 375, DateTimeKind.Local).AddTicks(3872));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreation",
                table: "OrderHeader",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 27, 14, 41, 55, 505, DateTimeKind.Local).AddTicks(9259),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 27, 14, 43, 0, 375, DateTimeKind.Local).AddTicks(3612));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "OrderHeader",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 5, 27, 14, 41, 55, 505, DateTimeKind.Local).AddTicks(8965),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 5, 27, 14, 43, 0, 375, DateTimeKind.Local).AddTicks(3284));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModification",
                table: "OrderDetail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 27, 14, 41, 55, 505, DateTimeKind.Local).AddTicks(8093),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 27, 14, 43, 0, 375, DateTimeKind.Local).AddTicks(1346));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreation",
                table: "OrderDetail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 27, 14, 41, 55, 505, DateTimeKind.Local).AddTicks(7749),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 27, 14, 43, 0, 375, DateTimeKind.Local).AddTicks(1009));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModification",
                table: "Book",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 27, 14, 41, 55, 505, DateTimeKind.Local).AddTicks(4640),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 27, 14, 43, 0, 374, DateTimeKind.Local).AddTicks(6201));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreation",
                table: "Book",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 27, 14, 41, 55, 505, DateTimeKind.Local).AddTicks(4340),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 27, 14, 43, 0, 374, DateTimeKind.Local).AddTicks(5838));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateModification",
                table: "Author",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 27, 14, 41, 55, 505, DateTimeKind.Local).AddTicks(3383),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 27, 14, 43, 0, 374, DateTimeKind.Local).AddTicks(3837));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreation",
                table: "Author",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 27, 14, 41, 55, 505, DateTimeKind.Local).AddTicks(3052),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 5, 27, 14, 43, 0, 374, DateTimeKind.Local).AddTicks(3507));
        }
    }
}
