using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LearningApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ReworkedResults : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Result_AspNetUsers_UserId",
                table: "Result");

            migrationBuilder.DropForeignKey(
                name: "FK_Result_ChapterTests_ChapterTestId",
                table: "Result");

            migrationBuilder.DropForeignKey(
                name: "FK_Result_LectureTests_LectureTestId",
                table: "Result");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Result",
                table: "Result");

            migrationBuilder.DropIndex(
                name: "IX_Result_ChapterTestId",
                table: "Result");

            migrationBuilder.DropColumn(
                name: "ChapterTestId",
                table: "Result");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Result");

            migrationBuilder.RenameTable(
                name: "Result",
                newName: "LectureTestResults");

            migrationBuilder.RenameIndex(
                name: "IX_Result_UserId",
                table: "LectureTestResults",
                newName: "IX_LectureTestResults_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Result_LectureTestId",
                table: "LectureTestResults",
                newName: "IX_LectureTestResults_LectureTestId");

            migrationBuilder.AlterColumn<int>(
                name: "LectureTestId",
                table: "LectureTestResults",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LectureTestResults",
                table: "LectureTestResults",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ChapterTestResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ChapterTestId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Attempt = table.Column<int>(type: "integer", nullable: false),
                    RightAnswers = table.Column<int>(type: "integer", nullable: false),
                    QuestionsCount = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChapterTestResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChapterTestResults_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChapterTestResults_ChapterTests_ChapterTestId",
                        column: x => x.ChapterTestId,
                        principalTable: "ChapterTests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChapterTestResults_ChapterTestId",
                table: "ChapterTestResults",
                column: "ChapterTestId");

            migrationBuilder.CreateIndex(
                name: "IX_ChapterTestResults_UserId",
                table: "ChapterTestResults",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_LectureTestResults_AspNetUsers_UserId",
                table: "LectureTestResults",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LectureTestResults_LectureTests_LectureTestId",
                table: "LectureTestResults",
                column: "LectureTestId",
                principalTable: "LectureTests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LectureTestResults_AspNetUsers_UserId",
                table: "LectureTestResults");

            migrationBuilder.DropForeignKey(
                name: "FK_LectureTestResults_LectureTests_LectureTestId",
                table: "LectureTestResults");

            migrationBuilder.DropTable(
                name: "ChapterTestResults");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LectureTestResults",
                table: "LectureTestResults");

            migrationBuilder.RenameTable(
                name: "LectureTestResults",
                newName: "Result");

            migrationBuilder.RenameIndex(
                name: "IX_LectureTestResults_UserId",
                table: "Result",
                newName: "IX_Result_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_LectureTestResults_LectureTestId",
                table: "Result",
                newName: "IX_Result_LectureTestId");

            migrationBuilder.AlterColumn<int>(
                name: "LectureTestId",
                table: "Result",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "ChapterTestId",
                table: "Result",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Result",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Result",
                table: "Result",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Result_ChapterTestId",
                table: "Result",
                column: "ChapterTestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Result_AspNetUsers_UserId",
                table: "Result",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Result_ChapterTests_ChapterTestId",
                table: "Result",
                column: "ChapterTestId",
                principalTable: "ChapterTests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Result_LectureTests_LectureTestId",
                table: "Result",
                column: "LectureTestId",
                principalTable: "LectureTests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
