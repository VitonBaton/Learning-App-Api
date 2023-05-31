using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedImagesToTests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "LectureTestQuestions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "ChapterTestQuestions",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "LectureTestQuestions");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "ChapterTestQuestions");
        }
    }
}
