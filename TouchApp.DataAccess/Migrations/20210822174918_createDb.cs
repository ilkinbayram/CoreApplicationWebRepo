using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TouchApp.DataAccess.Migrations
{
    public partial class createDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogCategories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentCategoryId = table.Column<long>(type: "bigint", nullable: true),
                    IconSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Modified_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Created_at = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    Modified_at = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogCategories_BlogCategories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "BlogCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentCategoryId = table.Column<long>(type: "bigint", nullable: true),
                    ShowInHomePage = table.Column<bool>(type: "bit", nullable: false),
                    CategoryType = table.Column<byte>(type: "tinyint", nullable: false),
                    IconSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Modified_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Created_at = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    Modified_at = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseServices",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniqueToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IconSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Modified_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Created_at = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    Modified_at = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlagIconSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameAbr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CourseLanguageKey = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Localizations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Translate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Project_oid = table.Column<long>(type: "bigint", nullable: false),
                    Lang_oid = table.Column<byte>(type: "tinyint", nullable: false),
                    Created_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Modified_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Created_at = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    Modified_at = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medias",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AltrKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniqueParentToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MediaType = table.Column<byte>(type: "tinyint", nullable: false),
                    Created_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Modified_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Created_at = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    Modified_at = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageCode = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperationClaims",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Phrases",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerSurname = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    IconSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "Professions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubnameKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfDescKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartProfession = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProfessionDegree = table.Column<byte>(type: "tinyint", nullable: false),
                    CurrentCompanyKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentPositionAtCompanyKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentProfessionId = table.Column<long>(type: "bigint", nullable: true),
                    Created_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Modified_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Created_at = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    Modified_at = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Professions_Professions_ParentProfessionId",
                        column: x => x.ParentProfessionId,
                        principalTable: "Professions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SharingTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Modified_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Created_at = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    Modified_at = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SharingTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sliders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleKey = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SubTitleKey = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SliderMediaSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sliders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SocialMedias",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameSocial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Uri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IconSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Modified_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Created_at = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    Modified_at = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMedias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TagType = table.Column<byte>(type: "tinyint", nullable: false),
                    Created_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Modified_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Created_at = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    Modified_at = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WallpaperPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(1000)", maxLength: 1000, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(1000)", maxLength: 1000, nullable: false),
                    PhoneNumberPrefix = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false, defaultValue: 3),
                    BiographyKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountType = table.Column<int>(type: "int", nullable: false),
                    SecurityToken = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CategoryId = table.Column<long>(type: "bigint", nullable: true),
                    Created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniqueToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinTotalMonths = table.Column<byte>(type: "tinyint", nullable: false),
                    MaxTotalMonths = table.Column<byte>(type: "tinyint", nullable: false),
                    TotalHours = table.Column<short>(type: "smallint", nullable: false),
                    PricePerMonth = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ScheduleHtmlRawKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentHtmlRawKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OverViewHtmlRawKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProfessionCourseCategoryId = table.Column<long>(type: "bigint", nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberPrefix = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreviewMoviePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IconSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RateCount = table.Column<int>(type: "int", nullable: true),
                    BiographyKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WallpaperPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ProfessionId = table.Column<long>(type: "bigint", nullable: false),
                    Created_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Modified_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Created_at = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    Modified_at = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_Professions_ProfessionId",
                        column: x => x.ProfessionId,
                        principalTable: "Professions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SharingTypeMedias",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MediaId = table.Column<long>(type: "bigint", nullable: false),
                    SharingTypeId = table.Column<long>(type: "bigint", nullable: false),
                    Created_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Modified_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Created_at = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    Modified_at = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SharingTypeMedias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SharingTypeMedias_Medias_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Medias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SharingTypeMedias_SharingTypes_SharingTypeId",
                        column: x => x.SharingTypeId,
                        principalTable: "SharingTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniqueToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaptionSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerProfessionKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubtitleKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentHtmlRawKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OverviewHtmlRawKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScreenType = table.Column<byte>(type: "tinyint", nullable: false),
                    BlogCategoryId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Created_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Modified_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Created_at = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    Modified_at = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blogs_BlogCategories_BlogCategoryId",
                        column: x => x.BlogCategoryId,
                        principalTable: "BlogCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Blogs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserOperationClaims",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    OperationClaimId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOperationClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserOperationClaims_OperationClaims_OperationClaimId",
                        column: x => x.OperationClaimId,
                        principalTable: "OperationClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserOperationClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSocialMedias",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RedirectUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    SocialMediaId = table.Column<long>(type: "bigint", nullable: false),
                    Created_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Modified_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Created_at = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    Modified_at = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSocialMedias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSocialMedias_SocialMedias_SocialMediaId",
                        column: x => x.SocialMediaId,
                        principalTable: "SocialMedias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSocialMedias_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseComments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommentContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    Created_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Modified_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Created_at = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    Modified_at = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseComments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherCourses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherId = table.Column<long>(type: "bigint", nullable: false),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    Created_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Modified_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Created_at = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    Modified_at = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherCourses_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherSocialMedias",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RedirectUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeacherId = table.Column<long>(type: "bigint", nullable: false),
                    SocialMediaId = table.Column<long>(type: "bigint", nullable: false),
                    Created_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Modified_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Created_at = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    Modified_at = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherSocialMedias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherSocialMedias_SocialMedias_SocialMediaId",
                        column: x => x.SocialMediaId,
                        principalTable: "SocialMedias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherSocialMedias_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserCourses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegisteredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TeacherId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCourses_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCourses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TagBlogs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagId = table.Column<long>(type: "bigint", nullable: false),
                    BlogId = table.Column<long>(type: "bigint", nullable: false),
                    Created_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Modified_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Created_at = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    Modified_at = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagBlogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TagBlogs_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagBlogs_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogCategories_ParentCategoryId",
                table: "BlogCategories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_BlogCategoryId",
                table: "Blogs",
                column: "BlogCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_UserId",
                table: "Blogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseComments_CourseId",
                table: "CourseComments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_ProfessionCourseCategoryId",
                table: "Courses",
                column: "ProfessionCourseCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionCourseCategories_ParentCategoryId",
                table: "ProfessionCourseCategories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Professions_ParentProfessionId",
                table: "Professions",
                column: "ParentProfessionId");

            migrationBuilder.CreateIndex(
                name: "IX_SharingTypeMedias_MediaId",
                table: "SharingTypeMedias",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_SharingTypeMedias_SharingTypeId",
                table: "SharingTypeMedias",
                column: "SharingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TagBlogs_BlogId",
                table: "TagBlogs",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_TagBlogs_TagId",
                table: "TagBlogs",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCourses_CourseId",
                table: "TeacherCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCourses_TeacherId",
                table: "TeacherCourses",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_ProfessionId",
                table: "Teachers",
                column: "ProfessionId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSocialMedias_SocialMediaId",
                table: "TeacherSocialMedias",
                column: "SocialMediaId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSocialMedias_TeacherId",
                table: "TeacherSocialMedias",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCourses_CourseId",
                table: "UserCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCourses_TeacherId",
                table: "UserCourses",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCourses_UserId",
                table: "UserCourses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_OperationClaimId",
                table: "UserOperationClaims",
                column: "OperationClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_UserId",
                table: "UserOperationClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CategoryId",
                table: "Users",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSocialMedias_SocialMediaId",
                table: "UserSocialMedias",
                column: "SocialMediaId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSocialMedias_UserId",
                table: "UserSocialMedias",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseComments");

            migrationBuilder.DropTable(
                name: "CourseServices");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Localizations");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Phrases");

            migrationBuilder.DropTable(
                name: "SharingTypeMedias");

            migrationBuilder.DropTable(
                name: "Sliders");

            migrationBuilder.DropTable(
                name: "TagBlogs");

            migrationBuilder.DropTable(
                name: "TeacherCourses");

            migrationBuilder.DropTable(
                name: "TeacherSocialMedias");

            migrationBuilder.DropTable(
                name: "UserCourses");

            migrationBuilder.DropTable(
                name: "UserOperationClaims");

            migrationBuilder.DropTable(
                name: "UserSocialMedias");

            migrationBuilder.DropTable(
                name: "Medias");

            migrationBuilder.DropTable(
                name: "SharingTypes");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "OperationClaims");

            migrationBuilder.DropTable(
                name: "SocialMedias");

            migrationBuilder.DropTable(
                name: "BlogCategories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ProfessionCourseCategories");

            migrationBuilder.DropTable(
                name: "Professions");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
