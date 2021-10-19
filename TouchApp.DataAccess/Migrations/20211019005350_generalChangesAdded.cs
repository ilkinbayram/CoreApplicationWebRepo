using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TouchApp.DataAccess.Migrations
{
    public partial class generalChangesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AltrKey",
                table: "Medias");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "Tags",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 4, 53, 47, 677, DateTimeKind.Local).AddTicks(4945),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 0, 34, 13, 956, DateTimeKind.Local).AddTicks(6650));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "TagBlogs",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 4, 53, 47, 678, DateTimeKind.Local).AddTicks(9095),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 0, 34, 13, 958, DateTimeKind.Local).AddTicks(1348));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "TagBlogs",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 4, 53, 47, 678, DateTimeKind.Local).AddTicks(8496),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 0, 34, 13, 958, DateTimeKind.Local).AddTicks(639));

            migrationBuilder.AddColumn<string>(
                name: "AbriveatureClass",
                table: "SharingTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UniqueToken",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "edf29543-b901-471b-b83d-baa0ca6c0665",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "76492f06-ed4c-4f34-bcb3-07931dc0fa79");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "Courses",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 4, 53, 47, 655, DateTimeKind.Local).AddTicks(921),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 0, 34, 13, 932, DateTimeKind.Local).AddTicks(945));

            migrationBuilder.AlterColumn<string>(
                name: "UniqueToken",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "c014b7d2-6b0f-4795-b6f5-936971afca44",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "a120b1cf-4d09-4a72-b7d2-fbb5d6a8f951");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AbriveatureClass",
                table: "SharingTypes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "Tags",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 0, 34, 13, 956, DateTimeKind.Local).AddTicks(6650),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 4, 53, 47, 677, DateTimeKind.Local).AddTicks(4945));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "TagBlogs",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 0, 34, 13, 958, DateTimeKind.Local).AddTicks(1348),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 4, 53, 47, 678, DateTimeKind.Local).AddTicks(9095));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "TagBlogs",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 0, 34, 13, 958, DateTimeKind.Local).AddTicks(639),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 4, 53, 47, 678, DateTimeKind.Local).AddTicks(8496));

            migrationBuilder.AddColumn<string>(
                name: "AltrKey",
                table: "Medias",
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
                oldDefaultValue: "edf29543-b901-471b-b83d-baa0ca6c0665");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "Courses",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 0, 34, 13, 932, DateTimeKind.Local).AddTicks(945),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 4, 53, 47, 655, DateTimeKind.Local).AddTicks(921));

            migrationBuilder.AlterColumn<string>(
                name: "UniqueToken",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "a120b1cf-4d09-4a72-b7d2-fbb5d6a8f951",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "c014b7d2-6b0f-4795-b6f5-936971afca44");
        }
    }
}
