using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TouchApp.DataAccess.Migrations
{
    public partial class defaultValuesAddedToConfigurations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Modified_by",
                table: "UserSocialMedias",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "System Manager",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "UserSocialMedias",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 790, DateTimeKind.Local).AddTicks(521),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<string>(
                name: "Created_by",
                table: "UserSocialMedias",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "System Manager",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "UserSocialMedias",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 789, DateTimeKind.Local).AddTicks(9835),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<string>(
                name: "Modified_by",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "System Manager",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "Users",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 755, DateTimeKind.Local).AddTicks(9404),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<string>(
                name: "Created_by",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "System Manager",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "Users",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 755, DateTimeKind.Local).AddTicks(8744),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<string>(
                name: "Modified_by",
                table: "TeacherSocialMedias",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "System Manager",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "TeacherSocialMedias",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 791, DateTimeKind.Local).AddTicks(2698),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<string>(
                name: "Created_by",
                table: "TeacherSocialMedias",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "System Manager",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "TeacherSocialMedias",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 791, DateTimeKind.Local).AddTicks(2036),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<string>(
                name: "Modified_by",
                table: "Teachers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "System Manager",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "Teachers",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 787, DateTimeKind.Local).AddTicks(3611),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<string>(
                name: "Created_by",
                table: "Teachers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "System Manager",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "Teachers",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 787, DateTimeKind.Local).AddTicks(2997),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<string>(
                name: "Modified_by",
                table: "TeacherCourses",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "System Manager",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "TeacherCourses",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 788, DateTimeKind.Local).AddTicks(9078),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<string>(
                name: "Created_by",
                table: "TeacherCourses",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "System Manager",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "TeacherCourses",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 788, DateTimeKind.Local).AddTicks(8406),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<string>(
                name: "Modified_by",
                table: "Tags",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "System Manager",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "Tags",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 782, DateTimeKind.Local).AddTicks(4271),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "Tags",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 782, DateTimeKind.Local).AddTicks(3644),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 4, 53, 47, 677, DateTimeKind.Local).AddTicks(4945));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "TagBlogs",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 783, DateTimeKind.Local).AddTicks(9169),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 4, 53, 47, 678, DateTimeKind.Local).AddTicks(9095));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "TagBlogs",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 783, DateTimeKind.Local).AddTicks(8483),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 4, 53, 47, 678, DateTimeKind.Local).AddTicks(8496));

            migrationBuilder.AlterColumn<string>(
                name: "Modified_by",
                table: "StudyingGroups",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "System Manager",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "StudyingGroups",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 804, DateTimeKind.Local).AddTicks(2300),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<string>(
                name: "Created_by",
                table: "StudyingGroups",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "System Manager",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "StudyingGroups",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 804, DateTimeKind.Local).AddTicks(1462),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<string>(
                name: "Modified_by",
                table: "StudentStudyingGroups",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "System Manager",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "StudentStudyingGroups",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 802, DateTimeKind.Local).AddTicks(5921),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<string>(
                name: "Created_by",
                table: "StudentStudyingGroups",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "System Manager",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "StudentStudyingGroups",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 802, DateTimeKind.Local).AddTicks(5240),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<string>(
                name: "Modified_by",
                table: "Students",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "System Manager",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "Students",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 774, DateTimeKind.Local).AddTicks(8224),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<string>(
                name: "Created_by",
                table: "Students",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "System Manager",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "Students",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 774, DateTimeKind.Local).AddTicks(7557),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<string>(
                name: "Modified_by",
                table: "SocialMedias",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "System Manager",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "SocialMedias",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 785, DateTimeKind.Local).AddTicks(3633),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<string>(
                name: "Created_by",
                table: "SocialMedias",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "System Manager",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "SocialMedias",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 785, DateTimeKind.Local).AddTicks(3047),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<string>(
                name: "Modified_by",
                table: "SharingTypes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "System Manager",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "SharingTypes",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 779, DateTimeKind.Local).AddTicks(6754),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<string>(
                name: "Created_by",
                table: "SharingTypes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "System Manager",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "SharingTypes",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 779, DateTimeKind.Local).AddTicks(6116),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<string>(
                name: "Modified_by",
                table: "SharingTypeMedias",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "System Manager",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "SharingTypeMedias",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 781, DateTimeKind.Local).AddTicks(677),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<string>(
                name: "Created_by",
                table: "SharingTypeMedias",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "System Manager",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "SharingTypeMedias",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 780, DateTimeKind.Local).AddTicks(9948),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<string>(
                name: "Modified_by",
                table: "ResultExams",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "System Manager",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "ResultExams",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 801, DateTimeKind.Local).AddTicks(1383),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<string>(
                name: "Created_by",
                table: "ResultExams",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "System Manager",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "ResultExams",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 801, DateTimeKind.Local).AddTicks(748),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<string>(
                name: "Modified_by",
                table: "QuestionVariations",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "System Manager",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "QuestionVariations",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 799, DateTimeKind.Local).AddTicks(5279),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<string>(
                name: "Created_by",
                table: "QuestionVariations",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "System Manager",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "QuestionVariations",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 799, DateTimeKind.Local).AddTicks(4605),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<string>(
                name: "Modified_by",
                table: "Questions",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "System Manager",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "Questions",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 796, DateTimeKind.Local).AddTicks(6044),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<string>(
                name: "Created_by",
                table: "Questions",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "System Manager",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "Questions",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 796, DateTimeKind.Local).AddTicks(5421),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<string>(
                name: "Modified_by",
                table: "QuestionResultExams",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "System Manager",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "QuestionResultExams",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 798, DateTimeKind.Local).AddTicks(1699),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<string>(
                name: "Created_by",
                table: "QuestionResultExams",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "System Manager",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "QuestionResultExams",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 798, DateTimeKind.Local).AddTicks(1032),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<string>(
                name: "Modified_by",
                table: "ProfessionCourseCategories",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "System Manager",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "ProfessionCourseCategories",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 762, DateTimeKind.Local).AddTicks(271),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<string>(
                name: "Created_by",
                table: "ProfessionCourseCategories",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "System Manager",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "ProfessionCourseCategories",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 761, DateTimeKind.Local).AddTicks(9626),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<string>(
                name: "Modified_by",
                table: "Phrases",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "System Manager",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "Phrases",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 772, DateTimeKind.Local).AddTicks(6410),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<string>(
                name: "Created_by",
                table: "Phrases",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "System Manager",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "Phrases",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 772, DateTimeKind.Local).AddTicks(5784),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<string>(
                name: "Modified_by",
                table: "OperationClaims",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "System Manager",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "OperationClaims",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 744, DateTimeKind.Local).AddTicks(7164),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<string>(
                name: "Created_by",
                table: "OperationClaims",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "System Manager",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "OperationClaims",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 744, DateTimeKind.Local).AddTicks(1318),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<string>(
                name: "Modified_by",
                table: "Medias",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "System Manager",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "Medias",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 771, DateTimeKind.Local).AddTicks(2776),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<string>(
                name: "Created_by",
                table: "Medias",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "System Manager",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "Medias",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 771, DateTimeKind.Local).AddTicks(2086),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<string>(
                name: "Modified_by",
                table: "Localizations",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "System Manager",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "Localizations",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 763, DateTimeKind.Local).AddTicks(5675),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<string>(
                name: "Created_by",
                table: "Localizations",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "System Manager",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "Localizations",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 763, DateTimeKind.Local).AddTicks(4775),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<string>(
                name: "Modified_by",
                table: "Exams",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "System Manager",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "Exams",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 793, DateTimeKind.Local).AddTicks(7022),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<string>(
                name: "Created_by",
                table: "Exams",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "System Manager",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "Exams",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 793, DateTimeKind.Local).AddTicks(6361),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<string>(
                name: "Modified_by",
                table: "ExamQuestions",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "System Manager",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "ExamQuestions",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 795, DateTimeKind.Local).AddTicks(1303),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<string>(
                name: "Created_by",
                table: "ExamQuestions",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "System Manager",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "ExamQuestions",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 795, DateTimeKind.Local).AddTicks(618),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<string>(
                name: "Modified_by",
                table: "CourseServices",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "System Manager",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "CourseServices",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 760, DateTimeKind.Local).AddTicks(6962),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<string>(
                name: "Created_by",
                table: "CourseServices",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "System Manager",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "CourseServices",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 760, DateTimeKind.Local).AddTicks(6150),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<string>(
                name: "UniqueToken",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "2e86be3a-4a4c-4832-9692-5138cf4a67c1",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "edf29543-b901-471b-b83d-baa0ca6c0665");

            migrationBuilder.AlterColumn<string>(
                name: "Modified_by",
                table: "Courses",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "System Manager",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "Courses",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 757, DateTimeKind.Local).AddTicks(8787),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "Courses",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 757, DateTimeKind.Local).AddTicks(8066),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 4, 53, 47, 655, DateTimeKind.Local).AddTicks(921));

            migrationBuilder.AlterColumn<string>(
                name: "Modified_by",
                table: "CourseComments",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "System Manager",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "CourseComments",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 759, DateTimeKind.Local).AddTicks(2653),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<string>(
                name: "Created_by",
                table: "CourseComments",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "System Manager",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "CourseComments",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 759, DateTimeKind.Local).AddTicks(1957),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<string>(
                name: "UniqueToken",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "d95b0710-df67-4d18-b117-934144a0cc6b",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "c014b7d2-6b0f-4795-b6f5-936971afca44");

            migrationBuilder.AlterColumn<string>(
                name: "Modified_by",
                table: "Blogs",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "System Manager",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "Blogs",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 776, DateTimeKind.Local).AddTicks(7950),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<string>(
                name: "Created_by",
                table: "Blogs",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "System Manager",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "Blogs",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 776, DateTimeKind.Local).AddTicks(7271),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<string>(
                name: "Modified_by",
                table: "BlogCategories",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "System Manager",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "BlogCategories",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 778, DateTimeKind.Local).AddTicks(1962),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<string>(
                name: "Created_by",
                table: "BlogCategories",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "System Manager",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "BlogCategories",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 778, DateTimeKind.Local).AddTicks(1242),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<string>(
                name: "Modified_by",
                table: "AnswerVariations",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "System Manager",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "AnswerVariations",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 792, DateTimeKind.Local).AddTicks(4172),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<string>(
                name: "Created_by",
                table: "AnswerVariations",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "System Manager",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "AnswerVariations",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 792, DateTimeKind.Local).AddTicks(3510),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Modified_by",
                table: "UserSocialMedias",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "System Manager");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "UserSocialMedias",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 790, DateTimeKind.Local).AddTicks(521));

            migrationBuilder.AlterColumn<string>(
                name: "Created_by",
                table: "UserSocialMedias",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "System Manager");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "UserSocialMedias",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 789, DateTimeKind.Local).AddTicks(9835));

            migrationBuilder.AlterColumn<string>(
                name: "Modified_by",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "System Manager");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "Users",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 755, DateTimeKind.Local).AddTicks(9404));

            migrationBuilder.AlterColumn<string>(
                name: "Created_by",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "System Manager");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "Users",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 755, DateTimeKind.Local).AddTicks(8744));

            migrationBuilder.AlterColumn<string>(
                name: "Modified_by",
                table: "TeacherSocialMedias",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "System Manager");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "TeacherSocialMedias",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 791, DateTimeKind.Local).AddTicks(2698));

            migrationBuilder.AlterColumn<string>(
                name: "Created_by",
                table: "TeacherSocialMedias",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "System Manager");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "TeacherSocialMedias",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 791, DateTimeKind.Local).AddTicks(2036));

            migrationBuilder.AlterColumn<string>(
                name: "Modified_by",
                table: "Teachers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "System Manager");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "Teachers",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 787, DateTimeKind.Local).AddTicks(3611));

            migrationBuilder.AlterColumn<string>(
                name: "Created_by",
                table: "Teachers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "System Manager");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "Teachers",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 787, DateTimeKind.Local).AddTicks(2997));

            migrationBuilder.AlterColumn<string>(
                name: "Modified_by",
                table: "TeacherCourses",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "System Manager");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "TeacherCourses",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 788, DateTimeKind.Local).AddTicks(9078));

            migrationBuilder.AlterColumn<string>(
                name: "Created_by",
                table: "TeacherCourses",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "System Manager");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "TeacherCourses",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 788, DateTimeKind.Local).AddTicks(8406));

            migrationBuilder.AlterColumn<string>(
                name: "Modified_by",
                table: "Tags",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "System Manager");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "Tags",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 782, DateTimeKind.Local).AddTicks(4271));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "Tags",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 4, 53, 47, 677, DateTimeKind.Local).AddTicks(4945),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 782, DateTimeKind.Local).AddTicks(3644));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "TagBlogs",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 4, 53, 47, 678, DateTimeKind.Local).AddTicks(9095),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 783, DateTimeKind.Local).AddTicks(9169));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "TagBlogs",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 4, 53, 47, 678, DateTimeKind.Local).AddTicks(8496),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 783, DateTimeKind.Local).AddTicks(8483));

            migrationBuilder.AlterColumn<string>(
                name: "Modified_by",
                table: "StudyingGroups",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "System Manager");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "StudyingGroups",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 804, DateTimeKind.Local).AddTicks(2300));

            migrationBuilder.AlterColumn<string>(
                name: "Created_by",
                table: "StudyingGroups",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "System Manager");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "StudyingGroups",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 804, DateTimeKind.Local).AddTicks(1462));

            migrationBuilder.AlterColumn<string>(
                name: "Modified_by",
                table: "StudentStudyingGroups",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "System Manager");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "StudentStudyingGroups",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 802, DateTimeKind.Local).AddTicks(5921));

            migrationBuilder.AlterColumn<string>(
                name: "Created_by",
                table: "StudentStudyingGroups",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "System Manager");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "StudentStudyingGroups",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 802, DateTimeKind.Local).AddTicks(5240));

            migrationBuilder.AlterColumn<string>(
                name: "Modified_by",
                table: "Students",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "System Manager");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "Students",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 774, DateTimeKind.Local).AddTicks(8224));

            migrationBuilder.AlterColumn<string>(
                name: "Created_by",
                table: "Students",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "System Manager");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "Students",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 774, DateTimeKind.Local).AddTicks(7557));

            migrationBuilder.AlterColumn<string>(
                name: "Modified_by",
                table: "SocialMedias",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "System Manager");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "SocialMedias",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 785, DateTimeKind.Local).AddTicks(3633));

            migrationBuilder.AlterColumn<string>(
                name: "Created_by",
                table: "SocialMedias",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "System Manager");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "SocialMedias",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 785, DateTimeKind.Local).AddTicks(3047));

            migrationBuilder.AlterColumn<string>(
                name: "Modified_by",
                table: "SharingTypes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "System Manager");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "SharingTypes",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 779, DateTimeKind.Local).AddTicks(6754));

            migrationBuilder.AlterColumn<string>(
                name: "Created_by",
                table: "SharingTypes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "System Manager");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "SharingTypes",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 779, DateTimeKind.Local).AddTicks(6116));

            migrationBuilder.AlterColumn<string>(
                name: "Modified_by",
                table: "SharingTypeMedias",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "System Manager");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "SharingTypeMedias",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 781, DateTimeKind.Local).AddTicks(677));

            migrationBuilder.AlterColumn<string>(
                name: "Created_by",
                table: "SharingTypeMedias",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "System Manager");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "SharingTypeMedias",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 780, DateTimeKind.Local).AddTicks(9948));

            migrationBuilder.AlterColumn<string>(
                name: "Modified_by",
                table: "ResultExams",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "System Manager");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "ResultExams",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 801, DateTimeKind.Local).AddTicks(1383));

            migrationBuilder.AlterColumn<string>(
                name: "Created_by",
                table: "ResultExams",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "System Manager");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "ResultExams",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 801, DateTimeKind.Local).AddTicks(748));

            migrationBuilder.AlterColumn<string>(
                name: "Modified_by",
                table: "QuestionVariations",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "System Manager");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "QuestionVariations",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 799, DateTimeKind.Local).AddTicks(5279));

            migrationBuilder.AlterColumn<string>(
                name: "Created_by",
                table: "QuestionVariations",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "System Manager");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "QuestionVariations",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 799, DateTimeKind.Local).AddTicks(4605));

            migrationBuilder.AlterColumn<string>(
                name: "Modified_by",
                table: "Questions",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "System Manager");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "Questions",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 796, DateTimeKind.Local).AddTicks(6044));

            migrationBuilder.AlterColumn<string>(
                name: "Created_by",
                table: "Questions",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "System Manager");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "Questions",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 796, DateTimeKind.Local).AddTicks(5421));

            migrationBuilder.AlterColumn<string>(
                name: "Modified_by",
                table: "QuestionResultExams",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "System Manager");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "QuestionResultExams",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 798, DateTimeKind.Local).AddTicks(1699));

            migrationBuilder.AlterColumn<string>(
                name: "Created_by",
                table: "QuestionResultExams",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "System Manager");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "QuestionResultExams",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 798, DateTimeKind.Local).AddTicks(1032));

            migrationBuilder.AlterColumn<string>(
                name: "Modified_by",
                table: "ProfessionCourseCategories",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "System Manager");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "ProfessionCourseCategories",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 762, DateTimeKind.Local).AddTicks(271));

            migrationBuilder.AlterColumn<string>(
                name: "Created_by",
                table: "ProfessionCourseCategories",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "System Manager");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "ProfessionCourseCategories",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 761, DateTimeKind.Local).AddTicks(9626));

            migrationBuilder.AlterColumn<string>(
                name: "Modified_by",
                table: "Phrases",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "System Manager");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "Phrases",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 772, DateTimeKind.Local).AddTicks(6410));

            migrationBuilder.AlterColumn<string>(
                name: "Created_by",
                table: "Phrases",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "System Manager");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "Phrases",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 772, DateTimeKind.Local).AddTicks(5784));

            migrationBuilder.AlterColumn<string>(
                name: "Modified_by",
                table: "OperationClaims",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "System Manager");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "OperationClaims",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 744, DateTimeKind.Local).AddTicks(7164));

            migrationBuilder.AlterColumn<string>(
                name: "Created_by",
                table: "OperationClaims",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "System Manager");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "OperationClaims",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 744, DateTimeKind.Local).AddTicks(1318));

            migrationBuilder.AlterColumn<string>(
                name: "Modified_by",
                table: "Medias",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "System Manager");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "Medias",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 771, DateTimeKind.Local).AddTicks(2776));

            migrationBuilder.AlterColumn<string>(
                name: "Created_by",
                table: "Medias",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "System Manager");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "Medias",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 771, DateTimeKind.Local).AddTicks(2086));

            migrationBuilder.AlterColumn<string>(
                name: "Modified_by",
                table: "Localizations",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "System Manager");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "Localizations",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 763, DateTimeKind.Local).AddTicks(5675));

            migrationBuilder.AlterColumn<string>(
                name: "Created_by",
                table: "Localizations",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "System Manager");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "Localizations",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 763, DateTimeKind.Local).AddTicks(4775));

            migrationBuilder.AlterColumn<string>(
                name: "Modified_by",
                table: "Exams",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "System Manager");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "Exams",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 793, DateTimeKind.Local).AddTicks(7022));

            migrationBuilder.AlterColumn<string>(
                name: "Created_by",
                table: "Exams",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "System Manager");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "Exams",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 793, DateTimeKind.Local).AddTicks(6361));

            migrationBuilder.AlterColumn<string>(
                name: "Modified_by",
                table: "ExamQuestions",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "System Manager");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "ExamQuestions",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 795, DateTimeKind.Local).AddTicks(1303));

            migrationBuilder.AlterColumn<string>(
                name: "Created_by",
                table: "ExamQuestions",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "System Manager");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "ExamQuestions",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 795, DateTimeKind.Local).AddTicks(618));

            migrationBuilder.AlterColumn<string>(
                name: "Modified_by",
                table: "CourseServices",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "System Manager");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "CourseServices",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 760, DateTimeKind.Local).AddTicks(6962));

            migrationBuilder.AlterColumn<string>(
                name: "Created_by",
                table: "CourseServices",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "System Manager");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "CourseServices",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 760, DateTimeKind.Local).AddTicks(6150));

            migrationBuilder.AlterColumn<string>(
                name: "UniqueToken",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "edf29543-b901-471b-b83d-baa0ca6c0665",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "2e86be3a-4a4c-4832-9692-5138cf4a67c1");

            migrationBuilder.AlterColumn<string>(
                name: "Modified_by",
                table: "Courses",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "System Manager");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "Courses",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 757, DateTimeKind.Local).AddTicks(8787));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "Courses",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2021, 10, 19, 4, 53, 47, 655, DateTimeKind.Local).AddTicks(921),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 757, DateTimeKind.Local).AddTicks(8066));

            migrationBuilder.AlterColumn<string>(
                name: "Modified_by",
                table: "CourseComments",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "System Manager");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "CourseComments",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 759, DateTimeKind.Local).AddTicks(2653));

            migrationBuilder.AlterColumn<string>(
                name: "Created_by",
                table: "CourseComments",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "System Manager");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "CourseComments",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 759, DateTimeKind.Local).AddTicks(1957));

            migrationBuilder.AlterColumn<string>(
                name: "UniqueToken",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "c014b7d2-6b0f-4795-b6f5-936971afca44",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "d95b0710-df67-4d18-b117-934144a0cc6b");

            migrationBuilder.AlterColumn<string>(
                name: "Modified_by",
                table: "Blogs",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "System Manager");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "Blogs",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 776, DateTimeKind.Local).AddTicks(7950));

            migrationBuilder.AlterColumn<string>(
                name: "Created_by",
                table: "Blogs",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "System Manager");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "Blogs",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 776, DateTimeKind.Local).AddTicks(7271));

            migrationBuilder.AlterColumn<string>(
                name: "Modified_by",
                table: "BlogCategories",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "System Manager");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "BlogCategories",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 778, DateTimeKind.Local).AddTicks(1962));

            migrationBuilder.AlterColumn<string>(
                name: "Created_by",
                table: "BlogCategories",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "System Manager");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "BlogCategories",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 778, DateTimeKind.Local).AddTicks(1242));

            migrationBuilder.AlterColumn<string>(
                name: "Modified_by",
                table: "AnswerVariations",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "System Manager");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified_at",
                table: "AnswerVariations",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 792, DateTimeKind.Local).AddTicks(4172));

            migrationBuilder.AlterColumn<string>(
                name: "Created_by",
                table: "AnswerVariations",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "System Manager");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_at",
                table: "AnswerVariations",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2021, 10, 19, 5, 9, 36, 792, DateTimeKind.Local).AddTicks(3510));
        }
    }
}
