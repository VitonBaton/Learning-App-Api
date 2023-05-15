using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RemovedTestDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "LectureTests");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ChapterTests");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "LectureTests",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ChapterTests",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
