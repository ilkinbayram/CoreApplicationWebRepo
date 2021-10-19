using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TouchApp.DataAccess.Migrations
{
    public partial class sortBioKeyChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShortBiographyKey",
                table: "Teachers",
                newName: "BiographyShortKey");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "Tags",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 17, 1, 42, 40, 29, DateTimeKind.Local).AddTicks(3447),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 16, 20, 20, 29, 497, DateTimeKind.Local).AddTicks(7119));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "TagBlogs",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 17, 1, 42, 40, 32, DateTimeKind.Local).AddTicks(5106),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 16, 20, 20, 29, 499, DateTimeKind.Local).AddTicks(6673));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "TagBlogs",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 17, 1, 42, 40, 32, DateTimeKind.Local).AddTicks(3779),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 16, 20, 20, 29, 499, DateTimeKind.Local).AddTicks(6035));

            migrationBuilder.AlterColumn<string>(
                name: "UniqueToken",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "d6eed483-8394-4d38-87b1-eb0a5d122cf4",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "548a147c-6924-4622-8dd7-af8f920a1060");

            migrationBuilder.AlterColumn<string>(
                name: "UniqueToken",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "5554c428-da8e-49b9-889d-fdf11fc29859",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "16e0d300-c35d-42ae-a202-b73aa614a3c4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BiographyShortKey",
                table: "Teachers",
                newName: "ShortBiographyKey");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "Tags",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 16, 20, 20, 29, 497, DateTimeKind.Local).AddTicks(7119),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 17, 1, 42, 40, 29, DateTimeKind.Local).AddTicks(3447));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "TagBlogs",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 16, 20, 20, 29, 499, DateTimeKind.Local).AddTicks(6673),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 17, 1, 42, 40, 32, DateTimeKind.Local).AddTicks(5106));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "TagBlogs",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 16, 20, 20, 29, 499, DateTimeKind.Local).AddTicks(6035),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 17, 1, 42, 40, 32, DateTimeKind.Local).AddTicks(3779));

            migrationBuilder.AlterColumn<string>(
                name: "UniqueToken",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "548a147c-6924-4622-8dd7-af8f920a1060",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "d6eed483-8394-4d38-87b1-eb0a5d122cf4");

            migrationBuilder.AlterColumn<string>(
                name: "UniqueToken",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "16e0d300-c35d-42ae-a202-b73aa614a3c4",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "5554c428-da8e-49b9-889d-fdf11fc29859");
        }
    }
}
