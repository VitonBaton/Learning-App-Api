using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedLectures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "Lectures");

            migrationBuilder.AddColumn<string>(
                name: "ContentPath",
                table: "Lectures",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentPath",
                table: "Lectures");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Lectures",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
