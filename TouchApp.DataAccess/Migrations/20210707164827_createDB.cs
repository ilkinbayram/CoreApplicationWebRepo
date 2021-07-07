using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TouchApp.DataAccess.Migrations
{
    public partial class createDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "HomeMetaTags",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Modified_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Created_at = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    Modified_at = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeMetaTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "Routings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaNameKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ControllerNameKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionNameKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Modified_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Created_at = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    Modified_at = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubtitleKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IconSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Modified_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Created_at = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    Modified_at = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
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
                name: "SocialMedias",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TagType = table.Column<byte>(type: "tinyint", nullable: false),
                    Created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HomeMetaTagGalleries",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Alt = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    HomeMetaTagId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeMetaTagGalleries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeMetaTagGalleries_HomeMetaTags_HomeMetaTagId",
                        column: x => x.HomeMetaTagId,
                        principalTable: "HomeMetaTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeacherInfos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PreviewMoviePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IconSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfessionId = table.Column<long>(type: "bigint", nullable: true),
                    Created_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Modified_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Created_at = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    Modified_at = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherInfos_Professions_ProfessionId",
                        column: x => x.ProfessionId,
                        principalTable: "Professions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RateCount = table.Column<int>(type: "int", nullable: true),
                    BiographyKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountType = table.Column<int>(type: "int", nullable: false),
                    SecurityToken = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    TeacherInfoId = table.Column<long>(type: "bigint", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_Users_TeacherInfos_TeacherInfoId",
                        column: x => x.TeacherInfoId,
                        principalTable: "TeacherInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostOwner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaptionSource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerProfessionKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubtitleKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsHtmlContent = table.Column<bool>(type: "bit", nullable: false),
                    ScreenType = table.Column<byte>(type: "tinyint", nullable: false),
                    SectionId = table.Column<long>(type: "bigint", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    Created_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Modified_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Created_at = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    Modified_at = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Posts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    SocialMediaId = table.Column<long>(type: "bigint", nullable: true),
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserSocialMedias_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Medias",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AltrKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MediaType = table.Column<byte>(type: "tinyint", nullable: false),
                    PostId = table.Column<long>(type: "bigint", nullable: true),
                    Created_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Modified_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Created_at = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    Modified_at = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medias_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SharingTypePosts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostId = table.Column<long>(type: "bigint", nullable: true),
                    SharingTypeId = table.Column<long>(type: "bigint", nullable: true),
                    Created_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Modified_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Created_at = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    Modified_at = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SharingTypePosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SharingTypePosts_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SharingTypePosts_SharingTypes_SharingTypeId",
                        column: x => x.SharingTypeId,
                        principalTable: "SharingTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TagPosts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagId = table.Column<long>(type: "bigint", nullable: true),
                    PostId = table.Column<long>(type: "bigint", nullable: true),
                    Created_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Modified_by = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Created_at = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    Modified_at = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TagPosts_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TagPosts_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeMetaTagGalleries_HomeMetaTagId",
                table: "HomeMetaTagGalleries",
                column: "HomeMetaTagId");

            migrationBuilder.CreateIndex(
                name: "IX_Medias_PostId",
                table: "Medias",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_SectionId",
                table: "Posts",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Professions_ParentProfessionId",
                table: "Professions",
                column: "ParentProfessionId");

            migrationBuilder.CreateIndex(
                name: "IX_SharingTypePosts_PostId",
                table: "SharingTypePosts",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_SharingTypePosts_SharingTypeId",
                table: "SharingTypePosts",
                column: "SharingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TagPosts_PostId",
                table: "TagPosts",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_TagPosts_TagId",
                table: "TagPosts",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherInfos_ProfessionId",
                table: "TeacherInfos",
                column: "ProfessionId");

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
                name: "IX_Users_TeacherInfoId",
                table: "Users",
                column: "TeacherInfoId");

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
                name: "HomeMetaTagGalleries");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Localizations");

            migrationBuilder.DropTable(
                name: "Medias");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Routings");

            migrationBuilder.DropTable(
                name: "SharingTypePosts");

            migrationBuilder.DropTable(
                name: "TagPosts");

            migrationBuilder.DropTable(
                name: "UserOperationClaims");

            migrationBuilder.DropTable(
                name: "UserSocialMedias");

            migrationBuilder.DropTable(
                name: "HomeMetaTags");

            migrationBuilder.DropTable(
                name: "SharingTypes");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "OperationClaims");

            migrationBuilder.DropTable(
                name: "SocialMedias");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "TeacherInfos");

            migrationBuilder.DropTable(
                name: "Professions");
        }
    }
}
