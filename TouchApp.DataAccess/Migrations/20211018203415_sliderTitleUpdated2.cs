using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TouchApp.DataAccess.Migrations
{
    public partial class sliderTitleUpdated2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "Tags",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 0, 34, 13, 956, DateTimeKind.Local).AddTicks(6650),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 17, 15, 7, 14, 476, DateTimeKind.Local).AddTicks(6850));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "TagBlogs",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 0, 34, 13, 958, DateTimeKind.Local).AddTicks(1348),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 17, 15, 7, 14, 478, DateTimeKind.Local).AddTicks(6589));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "TagBlogs",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 0, 34, 13, 958, DateTimeKind.Local).AddTicks(639),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 17, 15, 7, 14, 478, DateTimeKind.Local).AddTicks(5723));

            migrationBuilder.AddColumn<string>(
                name: "ButtonRoute",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ButtonTextKey",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IconHtml",
                table: "CourseServices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UniqueToken",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "76492f06-ed4c-4f34-bcb3-07931dc0fa79",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "cca29ca4-aebb-4697-9b6e-11b85d042f78");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "Courses",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 0, 34, 13, 932, DateTimeKind.Local).AddTicks(945),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 17, 15, 7, 14, 440, DateTimeKind.Local).AddTicks(8101));

            migrationBuilder.AlterColumn<string>(
                name: "UniqueToken",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "a120b1cf-4d09-4a72-b7d2-fbb5d6a8f951",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "53aa9663-6e80-4b8e-b918-1de636e9302e");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ButtonRoute",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "ButtonTextKey",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "IconHtml",
                table: "CourseServices");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "Tags",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 17, 15, 7, 14, 476, DateTimeKind.Local).AddTicks(6850),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 0, 34, 13, 956, DateTimeKind.Local).AddTicks(6650));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "TagBlogs",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 17, 15, 7, 14, 478, DateTimeKind.Local).AddTicks(6589),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 0, 34, 13, 958, DateTimeKind.Local).AddTicks(1348));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "TagBlogs",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 17, 15, 7, 14, 478, DateTimeKind.Local).AddTicks(5723),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 0, 34, 13, 958, DateTimeKind.Local).AddTicks(639));

            migrationBuilder.AlterColumn<string>(
                name: "UniqueToken",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "cca29ca4-aebb-4697-9b6e-11b85d042f78",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "76492f06-ed4c-4f34-bcb3-07931dc0fa79");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "Courses",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 17, 15, 7, 14, 440, DateTimeKind.Local).AddTicks(8101),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 0, 34, 13, 932, DateTimeKind.Local).AddTicks(945));

            migrationBuilder.AlterColumn<string>(
                name: "UniqueToken",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "53aa9663-6e80-4b8e-b918-1de636e9302e",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "a120b1cf-4d09-4a72-b7d2-fbb5d6a8f951");
        }
    }
}
