using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TouchApp.DataAccess.Migrations
{
    public partial class BlogModelChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OverviewHtmlRawKey",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "OwnerProfessionKey",
                table: "Blogs");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "Tags",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 16, 5, 10, 53, 66, DateTimeKind.Local).AddTicks(2513),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 15, 19, 14, 18, 436, DateTimeKind.Local).AddTicks(9322));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "TagBlogs",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 16, 5, 10, 53, 70, DateTimeKind.Local).AddTicks(1938),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 15, 19, 14, 18, 439, DateTimeKind.Local).AddTicks(8774));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "TagBlogs",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 16, 5, 10, 53, 70, DateTimeKind.Local).AddTicks(483),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 15, 19, 14, 18, 439, DateTimeKind.Local).AddTicks(7680));

            migrationBuilder.AlterColumn<string>(
                name: "UniqueToken",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "9a6e5fb1-cf36-4670-96e3-cbec355bfb74",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "6b201d21-52a7-41da-9d8d-ed78b74c6d05");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "Tags",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 15, 19, 14, 18, 436, DateTimeKind.Local).AddTicks(9322),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 16, 5, 10, 53, 66, DateTimeKind.Local).AddTicks(2513));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "TagBlogs",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 15, 19, 14, 18, 439, DateTimeKind.Local).AddTicks(8774),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 16, 5, 10, 53, 70, DateTimeKind.Local).AddTicks(1938));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "TagBlogs",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 15, 19, 14, 18, 439, DateTimeKind.Local).AddTicks(7680),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 16, 5, 10, 53, 70, DateTimeKind.Local).AddTicks(483));

            migrationBuilder.AlterColumn<string>(
                name: "UniqueToken",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "6b201d21-52a7-41da-9d8d-ed78b74c6d05",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "9a6e5fb1-cf36-4670-96e3-cbec355bfb74");

            migrationBuilder.AddColumn<string>(
                name: "OverviewHtmlRawKey",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerProfessionKey",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
