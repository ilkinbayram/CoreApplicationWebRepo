using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TouchApp.DataAccess.Migrations
{
    public partial class backupFirst : Migration
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
                    Created_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "System Manager"),
                    Modified_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "System Manager"),
                    Created_at = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2021, 10, 19, 19, 46, 55, 447, DateTimeKind.Local).AddTicks(9272)),
                    Modified_at = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2021, 10, 19, 19, 46, 55, 448, DateTimeKind.Local).AddTicks(21)),
                    ModelType = table.Column<short>(type: "smallint", nullable: false),
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
                name: "CourseServices",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniqueToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IconSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IconHtml = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "System Manager"),
                    Modified_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "System Manager"),
                    Created_at = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2021, 10, 19, 19, 46, 55, 422, DateTimeKind.Local).AddTicks(8797)),
                    Modified_at = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2021, 10, 19, 19, 46, 55, 422, DateTimeKind.Local).AddTicks(9509)),
                    ModelType = table.Column<short>(type: "smallint", nullable: false),
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
                    Language_oid = table.Column<short>(type: "smallint", nullable: false),
                    NameKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlagIconSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameAbr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modified_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModelType = table.Column<short>(type: "smallint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
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
                    Key = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Translate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Project_oid = table.Column<short>(type: "smallint", nullable: false),
                    Lang_oid = table.Column<short>(type: "smallint", nullable: false),
                    Created_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "System Manager"),
                    Modified_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "System Manager"),
                    Created_at = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2021, 10, 19, 19, 46, 55, 425, DateTimeKind.Local).AddTicks(9313)),
                    Modified_at = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2021, 10, 19, 19, 46, 55, 426, DateTimeKind.Local).AddTicks(83)),
                    ModelType = table.Column<short>(type: "smallint", nullable: false),
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
                    UniqueParentToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MediaType = table.Column<byte>(type: "tinyint", nullable: false),
                    Created_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "System Manager"),
                    Modified_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "System Manager"),
                    Created_at = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2021, 10, 19, 19, 46, 55, 439, DateTimeKind.Local).AddTicks(1823)),
                    Modified_at = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2021, 10, 19, 19, 46, 55, 439, DateTimeKind.Local).AddTicks(3545)),
                    ModelType = table.Column<short>(type: "smallint", nullable: false),
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
                    Created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modified_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModelType = table.Column<short>(type: "smallint", nullable: false),
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
                    Created_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "System Manager"),
                    Modified_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "System Manager"),
                    Created_at = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2021, 10, 19, 19, 46, 55, 402, DateTimeKind.Local).AddTicks(5467)),
                    Modified_at = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2021, 10, 19, 19, 46, 55, 403, DateTimeKind.Local).AddTicks(2216)),
                    ModelType = table.Column<short>(type: "smallint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
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
                    Created_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "System Manager"),
                    Modified_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "System Manager"),
                    Created_at = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2021, 10, 19, 19, 46, 55, 441, DateTimeKind.Local).AddTicks(9567)),
                    Modified_at = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2021, 10, 19, 19, 46, 55, 442, DateTimeKind.Local).AddTicks(333)),
                    ModelType = table.Column<short>(type: "smallint", nullable: false),
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
                    Created_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "System Manager"),
                    Modified_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "System Manager"),
                    Created_at = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2021, 10, 19, 19, 46, 55, 424, DateTimeKind.Local).AddTicks(2742)),
                    Modified_at = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2021, 10, 19, 19, 46, 55, 424, DateTimeKind.Local).AddTicks(3530)),
                    ModelType = table.Column<short>(type: "smallint", nullable: false),
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
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionType = table.Column<byte>(type: "tinyint", nullable: false),
                    QuestionTextKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DifficultyDegree = table.Column<byte>(type: "tinyint", nullable: false),
                    EvaluationPoint = table.Column<byte>(type: "tinyint", nullable: false),
                    Created_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "System Manager"),
                    Modified_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "System Manager"),
                    Created_at = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2021, 10, 19, 19, 46, 55, 475, DateTimeKind.Local).AddTicks(6952)),
                    Modified_at = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2021, 10, 19, 19, 46, 55, 475, DateTimeKind.Local).AddTicks(8203)),
                    ModelType = table.Column<short>(type: "smallint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SharingTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AbriveatureClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "System Manager"),
                    Modified_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "System Manager"),
                    Created_at = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2021, 10, 19, 19, 46, 55, 449, DateTimeKind.Local).AddTicks(5903)),
                    Modified_at = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2021, 10, 19, 19, 46, 55, 449, DateTimeKind.Local).AddTicks(6649)),
                    ModelType = table.Column<short>(type: "smallint", nullable: false),
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
                    MainTitleKey = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SubTitleKey = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ButtonTextKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ButtonRoute = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SliderMediaSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modified_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModelType = table.Column<short>(type: "smallint", nullable: false),
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
                    SocialMediaType = table.Column<byte>(type: "tinyint", nullable: false),
                    NameSocial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Uri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IconSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IconHtml = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "System Manager"),
                    Modified_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "System Manager"),
                    Created_at = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2021, 10, 19, 19, 46, 55, 457, DateTimeKind.Local).AddTicks(2547)),
                    Modified_at = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2021, 10, 19, 19, 46, 55, 457, DateTimeKind.Local).AddTicks(3300)),
                    ModelType = table.Column<short>(type: "smallint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMedias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfilePhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccessToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PhoneNumberPrefix = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<byte>(type: "tinyint", nullable: false),
                    AccountType = table.Column<byte>(type: "tinyint", nullable: false),
                    SecurityToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "System Manager"),
                    Modified_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "System Manager"),
                    Created_at = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2021, 10, 19, 19, 46, 55, 444, DateTimeKind.Local).AddTicks(686)),
                    Modified_at = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2021, 10, 19, 19, 46, 55, 444, DateTimeKind.Local).AddTicks(1460)),
                    ModelType = table.Column<short>(type: "smallint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TagType = table.Column<byte>(type: "tinyint", nullable: false),
                    Created_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "System Manager"),
                    Modified_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "System Manager"),
                    Created_at = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2021, 10, 19, 19, 46, 55, 453, DateTimeKind.Local).AddTicks(7704)),
                    Modified_at = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2021, 10, 19, 19, 46, 55, 453, DateTimeKind.Local).AddTicks(8414)),
                    ModelType = table.Column<short>(type: "smallint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
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
                    CaptionSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<byte>(type: "tinyint", nullable: false),
                    BiographyKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BiographyShortKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WallpaperPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ProfessionNameKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfessionDescriptionKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartProfessionCareer = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProfessionDegree = table.Column<byte>(type: "tinyint", nullable: false),
                    CompanyNameKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobDescriptionKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "System Manager"),
                    Modified_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "System Manager"),
                    Created_at = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2021, 10, 19, 19, 46, 55, 460, DateTimeKind.Local).AddTicks(7446)),
                    Modified_at = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2021, 10, 19, 19, 46, 55, 460, DateTimeKind.Local).AddTicks(8414)),
                    ModelType = table.Column<short>(type: "smallint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
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
                    Gender = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)3),
                    AccountType = table.Column<byte>(type: "tinyint", nullable: false),
                    SecurityToken = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Created_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "System Manager"),
                    Modified_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "System Manager"),
                    Created_at = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2021, 10, 19, 19, 46, 55, 417, DateTimeKind.Local).AddTicks(785)),
                    Modified_at = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2021, 10, 19, 19, 46, 55, 417, DateTimeKind.Local).AddTicks(1552)),
                    ModelType = table.Column<short>(type: "smallint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniqueToken = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "ab7e11df-eb32-48ec-9980-feb54c416ae3"),
                    CaptionSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubtitleKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreviewDescriptionKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentHtmlRawKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScreenType = table.Column<byte>(type: "tinyint", nullable: false),
                    BlogCategoryId = table.Column<long>(type: "bigint", nullable: false),
                    Created_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "System Manager"),
                    Modified_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "System Manager"),
                    Created_at = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2021, 10, 19, 19, 46, 55, 446, DateTimeKind.Local).AddTicks(2876)),
                    Modified_at = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2021, 10, 19, 19, 46, 55, 446, DateTimeKind.Local).AddTicks(3626)),
                    ModelType = table.Column<short>(type: "smallint", nullable: false),
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
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniqueToken = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "8d1bd36f-9742-4aa4-8351-e37fdaa4cafa"),
                    CourseInfoHtmlMaintenanceKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaptionImageSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalMonths = table.Column<byte>(type: "tinyint", nullable: false),
                    TotalHours = table.Column<short>(type: "smallint", nullable: false),
                    PricePerMonth = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ScheduleHtmlRawKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentHtmlRawKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreviewDescKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProfessionCourseCategoryId = table.Column<long>(type: "bigint", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    Created_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "System Manager"),
                    Modified_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "System Manager"),
                    Created_at = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2021, 10, 19, 19, 46, 55, 419, DateTimeKind.Local).AddTicks(3387)),
                    Modified_at = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2021, 10, 19, 19, 46, 55, 419, DateTimeKind.Local).AddTicks(4226)),
                    ModelType = table.Column<short>(type: "smallint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Courses_ProfessionCourseCategories_ProfessionCourseCategoryId",
                        column: x => x.ProfessionCourseCategoryId,
                        principalTable: "ProfessionCourseCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionVariations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VariationToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefinitionKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OptionKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsTrue = table.Column<bool>(type: "bit", nullable: false),
                    QuestionId = table.Column<long>(type: "bigint", nullable: false),
                    Created_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "System Manager"),
                    Modified_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "System Manager"),
                    Created_at = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2021, 10, 19, 19, 46, 55, 479, DateTimeKind.Local).AddTicks(4462)),
                    Modified_at = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2021, 10, 19, 19, 46, 55, 479, DateTimeKind.Local).AddTicks(5267)),
                    ModelType = table.Column<short>(type: "smallint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionVariations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionVariations_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
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
                    Created_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "System Manager"),
                    Modified_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "System Manager"),
                    Created_at = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2021, 10, 19, 19, 46, 55, 451, DateTimeKind.Local).AddTicks(4228)),
                    Modified_at = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2021, 10, 19, 19, 46, 55, 451, DateTimeKind.Local).AddTicks(6195)),
                    ModelType = table.Column<short>(type: "smallint", nullable: false),
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
                name: "StudentOperationClaims",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<long>(type: "bigint", nullable: false),
                    OperationClaimId = table.Column<long>(type: "bigint", nullable: false),
                    Created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modified_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModelType = table.Column<short>(type: "smallint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentOperationClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentOperationClaims_OperationClaims_OperationClaimId",
                        column: x => x.OperationClaimId,
                        principalTable: "OperationClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentOperationClaims_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherOperationClaims",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherId = table.Column<long>(type: "bigint", nullable: false),
                    OperationClaimId = table.Column<long>(type: "bigint", nullable: false),
                    Created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modified_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModelType = table.Column<short>(type: "smallint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherOperationClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherOperationClaims_OperationClaims_OperationClaimId",
                        column: x => x.OperationClaimId,
                        principalTable: "OperationClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherOperationClaims_Teachers_TeacherId",
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
                    Created_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "System Manager"),
                    Modified_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "System Manager"),
                    Created_at = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2021, 10, 19, 19, 46, 55, 467, DateTimeKind.Local).AddTicks(846)),
                    Modified_at = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2021, 10, 19, 19, 46, 55, 467, DateTimeKind.Local).AddTicks(2034)),
                    ModelType = table.Column<short>(type: "smallint", nullable: false),
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
                name: "UserOperationClaims",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    OperationClaimId = table.Column<long>(type: "bigint", nullable: false),
                    Created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modified_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModelType = table.Column<short>(type: "smallint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOperationClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserOperationClaims_OperationClaims_OperationClaimId",
                        column: x => x.OperationClaimId,
                        principalTable: "OperationClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    Created_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "System Manager"),
                    Modified_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "System Manager"),
                    Created_at = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2021, 10, 19, 19, 46, 55, 465, DateTimeKind.Local).AddTicks(880)),
                    Modified_at = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2021, 10, 19, 19, 46, 55, 465, DateTimeKind.Local).AddTicks(2090)),
                    ModelType = table.Column<short>(type: "smallint", nullable: false),
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
                name: "TagBlogs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagId = table.Column<long>(type: "bigint", nullable: false),
                    BlogId = table.Column<long>(type: "bigint", nullable: false),
                    Created_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "System Manager"),
                    Modified_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "System Manager"),
                    Created_at = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2021, 10, 19, 19, 46, 55, 455, DateTimeKind.Local).AddTicks(4890)),
                    Modified_at = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2021, 10, 19, 19, 46, 55, 455, DateTimeKind.Local).AddTicks(5721)),
                    ModelType = table.Column<short>(type: "smallint", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "CourseComments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommentContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAccepted = table.Column<bool>(type: "bit", nullable: false),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    Created_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "System Manager"),
                    Modified_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "System Manager"),
                    Created_at = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2021, 10, 19, 19, 46, 55, 421, DateTimeKind.Local).AddTicks(24)),
                    Modified_at = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2021, 10, 19, 19, 46, 55, 421, DateTimeKind.Local).AddTicks(843)),
                    ModelType = table.Column<short>(type: "smallint", nullable: false),
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
                name: "StudyingGroups",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    Created_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "System Manager"),
                    Modified_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "System Manager"),
                    Created_at = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2021, 10, 19, 19, 46, 55, 484, DateTimeKind.Local).AddTicks(9808)),
                    Modified_at = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2021, 10, 19, 19, 46, 55, 485, DateTimeKind.Local).AddTicks(990)),
                    ModelType = table.Column<short>(type: "smallint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyingGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudyingGroups_Courses_CourseId",
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
                    Created_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "System Manager"),
                    Modified_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "System Manager"),
                    Created_at = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2021, 10, 19, 19, 46, 55, 463, DateTimeKind.Local).AddTicks(2364)),
                    Modified_at = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2021, 10, 19, 19, 46, 55, 463, DateTimeKind.Local).AddTicks(3378)),
                    ModelType = table.Column<short>(type: "smallint", nullable: false),
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
                name: "Exams",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamTitleKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExamPeriodMinute = table.Column<byte>(type: "tinyint", nullable: false),
                    ExamDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AverageResulPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StudyingGroupId = table.Column<long>(type: "bigint", nullable: false),
                    Created_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "System Manager"),
                    Modified_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "System Manager"),
                    Created_at = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2021, 10, 19, 19, 46, 55, 471, DateTimeKind.Local).AddTicks(682)),
                    Modified_at = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2021, 10, 19, 19, 46, 55, 471, DateTimeKind.Local).AddTicks(1740)),
                    ModelType = table.Column<short>(type: "smallint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exams_StudyingGroups_StudyingGroupId",
                        column: x => x.StudyingGroupId,
                        principalTable: "StudyingGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentStudyingGroups",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegisteredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudentId = table.Column<long>(type: "bigint", nullable: false),
                    StudyingGroupId = table.Column<long>(type: "bigint", nullable: false),
                    Created_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "System Manager"),
                    Modified_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "System Manager"),
                    Created_at = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2021, 10, 19, 19, 46, 55, 482, DateTimeKind.Local).AddTicks(8006)),
                    Modified_at = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2021, 10, 19, 19, 46, 55, 482, DateTimeKind.Local).AddTicks(8819)),
                    ModelType = table.Column<short>(type: "smallint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentStudyingGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentStudyingGroups_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentStudyingGroups_StudyingGroups_StudyingGroupId",
                        column: x => x.StudyingGroupId,
                        principalTable: "StudyingGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamQuestions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamId = table.Column<long>(type: "bigint", nullable: false),
                    QuestionId = table.Column<long>(type: "bigint", nullable: false),
                    Created_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "System Manager"),
                    Modified_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "System Manager"),
                    Created_at = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2021, 10, 19, 19, 46, 55, 473, DateTimeKind.Local).AddTicks(4031)),
                    Modified_at = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2021, 10, 19, 19, 46, 55, 473, DateTimeKind.Local).AddTicks(4992)),
                    ModelType = table.Column<short>(type: "smallint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamQuestions_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamQuestions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResultExams",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsJoined = table.Column<bool>(type: "bit", nullable: false),
                    RightAnswerCount = table.Column<byte>(type: "tinyint", nullable: false),
                    WrongAnswerCount = table.Column<byte>(type: "tinyint", nullable: false),
                    NoAnswerCount = table.Column<byte>(type: "tinyint", nullable: false),
                    TotalPoint = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalRightPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StudentId = table.Column<long>(type: "bigint", nullable: false),
                    ExamId = table.Column<long>(type: "bigint", nullable: false),
                    Created_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "System Manager"),
                    Modified_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "System Manager"),
                    Created_at = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2021, 10, 19, 19, 46, 55, 481, DateTimeKind.Local).AddTicks(1350)),
                    Modified_at = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2021, 10, 19, 19, 46, 55, 481, DateTimeKind.Local).AddTicks(2253)),
                    ModelType = table.Column<short>(type: "smallint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultExams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResultExams_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResultExams_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionResultExams",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<long>(type: "bigint", nullable: false),
                    ResultExamId = table.Column<long>(type: "bigint", nullable: false),
                    Created_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "System Manager"),
                    Modified_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "System Manager"),
                    Created_at = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2021, 10, 19, 19, 46, 55, 477, DateTimeKind.Local).AddTicks(8823)),
                    Modified_at = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2021, 10, 19, 19, 46, 55, 477, DateTimeKind.Local).AddTicks(9624)),
                    ModelType = table.Column<short>(type: "smallint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionResultExams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionResultExams_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionResultExams_ResultExams_ResultExamId",
                        column: x => x.ResultExamId,
                        principalTable: "ResultExams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnswerVariations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DefinitionKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OptionKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsTrue = table.Column<bool>(type: "bit", nullable: false),
                    QuestionResultId = table.Column<long>(type: "bigint", nullable: false),
                    Created_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "System Manager"),
                    Modified_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: "System Manager"),
                    Created_at = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2021, 10, 19, 19, 46, 55, 469, DateTimeKind.Local).AddTicks(136)),
                    Modified_at = table.Column<DateTime>(type: "smalldatetime", nullable: false, defaultValue: new DateTime(2021, 10, 19, 19, 46, 55, 469, DateTimeKind.Local).AddTicks(1217)),
                    ModelType = table.Column<short>(type: "smallint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerVariations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnswerVariations_QuestionResultExams_QuestionResultId",
                        column: x => x.QuestionResultId,
                        principalTable: "QuestionResultExams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnswerVariations_QuestionResultId",
                table: "AnswerVariations",
                column: "QuestionResultId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogCategories_ParentCategoryId",
                table: "BlogCategories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_BlogCategoryId",
                table: "Blogs",
                column: "BlogCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseComments_CourseId",
                table: "CourseComments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_LanguageId",
                table: "Courses",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_ProfessionCourseCategoryId",
                table: "Courses",
                column: "ProfessionCourseCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamQuestions_ExamId",
                table: "ExamQuestions",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamQuestions_QuestionId",
                table: "ExamQuestions",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_StudyingGroupId",
                table: "Exams",
                column: "StudyingGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Localizations_Key_Lang_oid",
                table: "Localizations",
                columns: new[] { "Key", "Lang_oid" },
                unique: true,
                filter: "[Key] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionCourseCategories_ParentCategoryId",
                table: "ProfessionCourseCategories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionResultExams_QuestionId",
                table: "QuestionResultExams",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionResultExams_ResultExamId",
                table: "QuestionResultExams",
                column: "ResultExamId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionVariations_QuestionId",
                table: "QuestionVariations",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultExams_ExamId",
                table: "ResultExams",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultExams_StudentId",
                table: "ResultExams",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_SharingTypeMedias_MediaId",
                table: "SharingTypeMedias",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_SharingTypeMedias_SharingTypeId",
                table: "SharingTypeMedias",
                column: "SharingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentOperationClaims_OperationClaimId",
                table: "StudentOperationClaims",
                column: "OperationClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentOperationClaims_StudentId",
                table: "StudentOperationClaims",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentStudyingGroups_StudentId",
                table: "StudentStudyingGroups",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentStudyingGroups_StudyingGroupId",
                table: "StudentStudyingGroups",
                column: "StudyingGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyingGroups_CourseId",
                table: "StudyingGroups",
                column: "CourseId");

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
                name: "IX_TeacherOperationClaims_OperationClaimId",
                table: "TeacherOperationClaims",
                column: "OperationClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherOperationClaims_TeacherId",
                table: "TeacherOperationClaims",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSocialMedias_SocialMediaId",
                table: "TeacherSocialMedias",
                column: "SocialMediaId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSocialMedias_TeacherId",
                table: "TeacherSocialMedias",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_OperationClaimId",
                table: "UserOperationClaims",
                column: "OperationClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_UserId",
                table: "UserOperationClaims",
                column: "UserId");

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
                name: "AnswerVariations");

            migrationBuilder.DropTable(
                name: "CourseComments");

            migrationBuilder.DropTable(
                name: "CourseServices");

            migrationBuilder.DropTable(
                name: "ExamQuestions");

            migrationBuilder.DropTable(
                name: "Localizations");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Phrases");

            migrationBuilder.DropTable(
                name: "QuestionVariations");

            migrationBuilder.DropTable(
                name: "SharingTypeMedias");

            migrationBuilder.DropTable(
                name: "Sliders");

            migrationBuilder.DropTable(
                name: "StudentOperationClaims");

            migrationBuilder.DropTable(
                name: "StudentStudyingGroups");

            migrationBuilder.DropTable(
                name: "TagBlogs");

            migrationBuilder.DropTable(
                name: "TeacherCourses");

            migrationBuilder.DropTable(
                name: "TeacherOperationClaims");

            migrationBuilder.DropTable(
                name: "TeacherSocialMedias");

            migrationBuilder.DropTable(
                name: "UserOperationClaims");

            migrationBuilder.DropTable(
                name: "UserSocialMedias");

            migrationBuilder.DropTable(
                name: "QuestionResultExams");

            migrationBuilder.DropTable(
                name: "Medias");

            migrationBuilder.DropTable(
                name: "SharingTypes");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "OperationClaims");

            migrationBuilder.DropTable(
                name: "SocialMedias");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "ResultExams");

            migrationBuilder.DropTable(
                name: "BlogCategories");

            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "StudyingGroups");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "ProfessionCourseCategories");
        }
    }
}
