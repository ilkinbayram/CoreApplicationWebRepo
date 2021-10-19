using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TouchApp.DataAccess.Migrations
{
    public partial class modelCourseChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "Tags",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 17, 7, 4, 12, 378, DateTimeKind.Local).AddTicks(9277),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 17, 3, 13, 28, 52, DateTimeKind.Local).AddTicks(2112));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "TagBlogs",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 17, 7, 4, 12, 381, DateTimeKind.Local).AddTicks(3030),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 17, 3, 13, 28, 55, DateTimeKind.Local).AddTicks(5869));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "TagBlogs",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 17, 7, 4, 12, 381, DateTimeKind.Local).AddTicks(2375),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 17, 3, 13, 28, 55, DateTimeKind.Local).AddTicks(4978));

            migrationBuilder.AlterColumn<string>(
                name: "UniqueToken",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "08b035c1-6304-4baf-928d-2f0aaed64e9b",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "00b361df-5776-4e04-a30c-07768fedb5e5");

            migrationBuilder.AddColumn<string>(
                name: "CourseInfoHtmlMaintenanceKey",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UniqueToken",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "e0ad5e86-d411-4734-8702-6f46f1e7252d",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "588ea110-5e0e-4fab-b7d2-1327fba75241");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseInfoHtmlMaintenanceKey",
                table: "Courses");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "Tags",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 17, 3, 13, 28, 52, DateTimeKind.Local).AddTicks(2112),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 17, 7, 4, 12, 378, DateTimeKind.Local).AddTicks(9277));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "TagBlogs",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 17, 3, 13, 28, 55, DateTimeKind.Local).AddTicks(5869),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 17, 7, 4, 12, 381, DateTimeKind.Local).AddTicks(3030));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "TagBlogs",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 17, 3, 13, 28, 55, DateTimeKind.Local).AddTicks(4978),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 17, 7, 4, 12, 381, DateTimeKind.Local).AddTicks(2375));

            migrationBuilder.AlterColumn<string>(
                name: "UniqueToken",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "00b361df-5776-4e04-a30c-07768fedb5e5",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "08b035c1-6304-4baf-928d-2f0aaed64e9b");

            migrationBuilder.AlterColumn<string>(
                name: "UniqueToken",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "588ea110-5e0e-4fab-b7d2-1327fba75241",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "e0ad5e86-d411-4734-8702-6f46f1e7252d");
        }
    }
}
