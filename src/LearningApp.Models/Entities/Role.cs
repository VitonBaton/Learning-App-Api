using Microsoft.AspNetCore.Identity;

namespace LearningApp.Models.Entities;

public sealed class Role : IdentityRole<int>
{
    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
