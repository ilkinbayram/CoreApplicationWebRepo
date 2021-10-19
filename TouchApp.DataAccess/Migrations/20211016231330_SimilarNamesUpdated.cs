using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TouchApp.DataAccess.Migrations
{
    public partial class SimilarNamesUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PreviewDescriptionKey",
                table: "Courses",
                newName: "PreviewDescKey");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "Tags",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 17, 3, 13, 28, 52, DateTimeKind.Local).AddTicks(2112),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 17, 1, 42, 40, 29, DateTimeKind.Local).AddTicks(3447));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "TagBlogs",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 17, 3, 13, 28, 55, DateTimeKind.Local).AddTicks(5869),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 17, 1, 42, 40, 32, DateTimeKind.Local).AddTicks(5106));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "TagBlogs",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 17, 3, 13, 28, 55, DateTimeKind.Local).AddTicks(4978),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 17, 1, 42, 40, 32, DateTimeKind.Local).AddTicks(3779));

            migrationBuilder.AlterColumn<string>(
                name: "UniqueToken",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "00b361df-5776-4e04-a30c-07768fedb5e5",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "d6eed483-8394-4d38-87b1-eb0a5d122cf4");

            migrationBuilder.AlterColumn<string>(
                name: "UniqueToken",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "588ea110-5e0e-4fab-b7d2-1327fba75241",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "5554c428-da8e-49b9-889d-fdf11fc29859");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PreviewDescKey",
                table: "Courses",
                newName: "PreviewDescriptionKey");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "Tags",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 17, 1, 42, 40, 29, DateTimeKind.Local).AddTicks(3447),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 17, 3, 13, 28, 52, DateTimeKind.Local).AddTicks(2112));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "TagBlogs",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 17, 1, 42, 40, 32, DateTimeKind.Local).AddTicks(5106),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 17, 3, 13, 28, 55, DateTimeKind.Local).AddTicks(5869));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "TagBlogs",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 17, 1, 42, 40, 32, DateTimeKind.Local).AddTicks(3779),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 17, 3, 13, 28, 55, DateTimeKind.Local).AddTicks(4978));

            migrationBuilder.AlterColumn<string>(
                name: "UniqueToken",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "d6eed483-8394-4d38-87b1-eb0a5d122cf4",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "00b361df-5776-4e04-a30c-07768fedb5e5");

            migrationBuilder.AlterColumn<string>(
                name: "UniqueToken",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "5554c428-da8e-49b9-889d-fdf11fc29859",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "588ea110-5e0e-4fab-b7d2-1327fba75241");
        }
    }
}
