using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TouchApp.DataAccess.Migrations
{
    public partial class sliderTitleUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TitleKey",
                table: "Sliders",
                newName: "MainTitleKey");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "Tags",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 17, 15, 7, 14, 476, DateTimeKind.Local).AddTicks(6850),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 17, 7, 4, 12, 378, DateTimeKind.Local).AddTicks(9277));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "TagBlogs",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 17, 15, 7, 14, 478, DateTimeKind.Local).AddTicks(6589),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 17, 7, 4, 12, 381, DateTimeKind.Local).AddTicks(3030));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "TagBlogs",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 17, 15, 7, 14, 478, DateTimeKind.Local).AddTicks(5723),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 17, 7, 4, 12, 381, DateTimeKind.Local).AddTicks(2375));

            migrationBuilder.AlterColumn<string>(
                name: "UniqueToken",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "cca29ca4-aebb-4697-9b6e-11b85d042f78",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "08b035c1-6304-4baf-928d-2f0aaed64e9b");

            migrationBuilder.AlterColumn<string>(
                name: "Created_by",
                table: "Courses",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "System Manager",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "Courses",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 17, 15, 7, 14, 440, DateTimeKind.Local).AddTicks(8101),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<string>(
                name: "UniqueToken",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "53aa9663-6e80-4b8e-b918-1de636e9302e",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "e0ad5e86-d411-4734-8702-6f46f1e7252d");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MainTitleKey",
                table: "Sliders",
                newName: "TitleKey");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "Tags",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 17, 7, 4, 12, 378, DateTimeKind.Local).AddTicks(9277),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 17, 15, 7, 14, 476, DateTimeKind.Local).AddTicks(6850));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "TagBlogs",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 17, 7, 4, 12, 381, DateTimeKind.Local).AddTicks(3030),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 17, 15, 7, 14, 478, DateTimeKind.Local).AddTicks(6589));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "TagBlogs",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 17, 7, 4, 12, 381, DateTimeKind.Local).AddTicks(2375),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 17, 15, 7, 14, 478, DateTimeKind.Local).AddTicks(5723));

            migrationBuilder.AlterColumn<string>(
                name: "UniqueToken",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "08b035c1-6304-4baf-928d-2f0aaed64e9b",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "cca29ca4-aebb-4697-9b6e-11b85d042f78");

            migrationBuilder.AlterColumn<string>(
                name: "Created_by",
                table: "Courses",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "System Manager");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "Courses",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 17, 15, 7, 14, 440, DateTimeKind.Local).AddTicks(8101));

            migrationBuilder.AlterColumn<string>(
                name: "UniqueToken",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "e0ad5e86-d411-4734-8702-6f46f1e7252d",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "53aa9663-6e80-4b8e-b918-1de636e9302e");
        }
    }
}
