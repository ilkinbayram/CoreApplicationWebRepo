using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TouchApp.DataAccess.Migrations
{
    public partial class enumTypeChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxTotalMonths",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "OverViewHtmlRawKey",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "MinTotalMonths",
                table: "Courses",
                newName: "TotalMonths");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "Tags",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 16, 20, 20, 29, 497, DateTimeKind.Local).AddTicks(7119),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 16, 5, 10, 53, 66, DateTimeKind.Local).AddTicks(2513));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "TagBlogs",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 16, 20, 20, 29, 499, DateTimeKind.Local).AddTicks(6673),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 16, 5, 10, 53, 70, DateTimeKind.Local).AddTicks(1938));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "TagBlogs",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 16, 20, 20, 29, 499, DateTimeKind.Local).AddTicks(6035),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 16, 5, 10, 53, 70, DateTimeKind.Local).AddTicks(483));

            migrationBuilder.AlterColumn<byte>(
                name: "SocialMediaType",
                table: "SocialMedias",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UniqueToken",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "548a147c-6924-4622-8dd7-af8f920a1060",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UniqueToken",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "16e0d300-c35d-42ae-a202-b73aa614a3c4",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "9a6e5fb1-cf36-4670-96e3-cbec355bfb74");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalMonths",
                table: "Courses",
                newName: "MinTotalMonths");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "Tags",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 16, 5, 10, 53, 66, DateTimeKind.Local).AddTicks(2513),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 16, 20, 20, 29, 497, DateTimeKind.Local).AddTicks(7119));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "TagBlogs",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 16, 5, 10, 53, 70, DateTimeKind.Local).AddTicks(1938),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 16, 20, 20, 29, 499, DateTimeKind.Local).AddTicks(6673));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "TagBlogs",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 16, 5, 10, 53, 70, DateTimeKind.Local).AddTicks(483),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 16, 20, 20, 29, 499, DateTimeKind.Local).AddTicks(6035));

            migrationBuilder.AlterColumn<int>(
                name: "SocialMediaType",
                table: "SocialMedias",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<string>(
                name: "UniqueToken",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "548a147c-6924-4622-8dd7-af8f920a1060");

            migrationBuilder.AddColumn<byte>(
                name: "MaxTotalMonths",
                table: "Courses",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<string>(
                name: "OverViewHtmlRawKey",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UniqueToken",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "9a6e5fb1-cf36-4670-96e3-cbec355bfb74",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "16e0d300-c35d-42ae-a202-b73aa614a3c4");
        }
    }
}
