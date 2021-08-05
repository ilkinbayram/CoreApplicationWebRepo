using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TouchApp.DataAccess.Migrations
{
    public partial class ExtraDbChangesAndItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TagPosts_Tag_TagId",
                table: "TagPosts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tag",
                table: "Tag");

            migrationBuilder.RenameTable(
                name: "Tag",
                newName: "Tags");

            migrationBuilder.AddColumn<string>(
                name: "PrioritySeparatorKey",
                table: "Sections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Modified_by",
                table: "Tags",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "Tags",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Tags",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Created_by",
                table: "Tags",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "Tags",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tags",
                table: "Tags",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Phrases",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaptionSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfessionKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Modified_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Created_at = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    Modified_at = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phrases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProfessionCourseCategories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentCategoryId = table.Column<long>(type: "bigint", nullable: true),
                    Created_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Modified_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Created_at = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    Modified_at = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessionCourseCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfessionCourseCategories_ProfessionCourseCategories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "ProfessionCourseCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniqueCourseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PeriodAsMonth = table.Column<byte>(type: "tinyint", nullable: false),
                    PricePerMonth = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProfessionCourseCategoryId = table.Column<long>(type: "bigint", nullable: true),
                    TeacherInfoId = table.Column<long>(type: "bigint", nullable: true),
                    Created_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Modified_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Created_at = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    Modified_at = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_ProfessionCourseCategories_ProfessionCourseCategoryId",
                        column: x => x.ProfessionCourseCategoryId,
                        principalTable: "ProfessionCourseCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Courses_TeacherInfos_TeacherInfoId",
                        column: x => x.TeacherInfoId,
                        principalTable: "TeacherInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserCourses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegisteredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TeacherInfoId = table.Column<long>(type: "bigint", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    CourseId = table.Column<long>(type: "bigint", nullable: true),
                    Created_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Modified_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Created_at = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    Modified_at = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserCourses_TeacherInfos_TeacherInfoId",
                        column: x => x.TeacherInfoId,
                        principalTable: "TeacherInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserCourses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_ProfessionCourseCategoryId",
                table: "Courses",
                column: "ProfessionCourseCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TeacherInfoId",
                table: "Courses",
                column: "TeacherInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionCourseCategories_ParentCategoryId",
                table: "ProfessionCourseCategories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCourses_CourseId",
                table: "UserCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCourses_TeacherInfoId",
                table: "UserCourses",
                column: "TeacherInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCourses_UserId",
                table: "UserCourses",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TagPosts_Tags_TagId",
                table: "TagPosts",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TagPosts_Tags_TagId",
                table: "TagPosts");

            migrationBuilder.DropTable(
                name: "Phrases");

            migrationBuilder.DropTable(
                name: "UserCourses");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "ProfessionCourseCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tags",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "PrioritySeparatorKey",
                table: "Sections");

            migrationBuilder.RenameTable(
                name: "Tags",
                newName: "Tag");

            migrationBuilder.AlterColumn<string>(
                name: "Modified_by",
                table: "Tag",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "Tag",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Tag",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<string>(
                name: "Created_by",
                table: "Tag",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "Tag",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tag",
                table: "Tag",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TagPosts_Tag_TagId",
                table: "TagPosts",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
