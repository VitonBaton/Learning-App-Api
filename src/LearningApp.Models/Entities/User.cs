using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace LearningApp.Models.Entities;

public sealed class User : IdentityUser<int>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    public ICollection<ChapterTestResult> ChapterResults { get; set; } = new List<ChapterTestResult>();
    public ICollection<LectureTestResult> LectureResults { get; set; } = new List<LectureTestResult>();

    [Required]
    public DateTime CreatedAt { get; set; }
}
