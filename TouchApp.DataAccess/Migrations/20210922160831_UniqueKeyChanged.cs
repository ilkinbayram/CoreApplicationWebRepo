using Microsoft.EntityFrameworkCore.Migrations;

namespace TouchApp.DataAccess.Migrations
{
    public partial class UniqueKeyChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Localizations_Key_Translate",
                table: "Localizations");

            migrationBuilder.AlterColumn<string>(
                name: "Translate",
                table: "Localizations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Localizations_Key_Lang_oid",
                table: "Localizations",
                columns: new[] { "Key", "Lang_oid" },
                unique: true,
                filter: "[Key] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Localizations_Key_Lang_oid",
                table: "Localizations");

            migrationBuilder.AlterColumn<string>(
                name: "Translate",
                table: "Localizations",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Localizations_Key_Translate",
                table: "Localizations",
                columns: new[] { "Key", "Translate" },
                unique: true,
                filter: "[Key] IS NOT NULL AND [Translate] IS NOT NULL");
        }
    }
}
