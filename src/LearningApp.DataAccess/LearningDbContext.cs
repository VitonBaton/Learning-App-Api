using LearningApp.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LearningApp.DataAccess;

public class LearningDbContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
{
    public DbSet<Chapter>? Chapters { get; set; }
    public DbSet<ChapterTest>? ChapterTests { get; set; }
    public DbSet<ChapterTestAnswer>? ChapterTestAnswers { get; set; }
    public DbSet<ChapterTestQuestion>? ChapterTestQuestions { get; set; }
    public DbSet<Lecture>? Lectures { get; set; }
    public DbSet<LectureTest>? LectureTests { get; set; }
    public DbSet<LectureTestAnswer>? LectureTestAnswers { get; set; }
    public DbSet<LectureTestQuestion>? LectureTestQuestions { get; set; }
    public DbSet<ChapterTestResult>? ChapterTestResults { get; set; }
    public DbSet<LectureTestResult>? LectureTestResults { get; set; }


    public LearningDbContext(DbContextOptions<LearningDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<UserRole>(userRole =>
        {
            userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

            userRole.HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();

            userRole.HasOne(ur => ur.User)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();
        });
    }

}

