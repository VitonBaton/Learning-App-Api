using LearningApp.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningApp.Entities;

public class LearningContext : DbContext
{
    public DbSet<Chapter>? Chapters { get; set; }
    public DbSet<ChapterTest>? ChapterTests { get; set; }
    public DbSet<ChapterTestAnswer>? ChapterTestAnswers { get; set; }
    public DbSet<ChapterTestQuestion>? ChapterTestQuestions { get; set; }
    public DbSet<Lecture>? Lectures { get; set; }
    public DbSet<LectureTest>? LectureTests { get; set; }
    public DbSet<LectureTestAnswer>? LectureTestAnswers { get; set; }
    public DbSet<LectureTestQuestion>? LectureTestQuestions { get; set; }
    
    
    public LearningContext(DbContextOptions<LearningContext> options)
        : base(options)
    {
    }

}

