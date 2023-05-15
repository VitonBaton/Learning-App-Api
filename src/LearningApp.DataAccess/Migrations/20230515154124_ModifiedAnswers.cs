using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedAnswers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRight",
                table: "LectureTestAnswers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRight",
                table: "ChapterTestAnswers",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRight",
                table: "LectureTestAnswers");

            migrationBuilder.DropColumn(
                name: "IsRight",
                table: "ChapterTestAnswers");
        }
    }
}
