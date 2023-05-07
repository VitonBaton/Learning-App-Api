using Microsoft.AspNetCore.Identity;

namespace LearningApp.Models.Entities;

public sealed class UserRole : IdentityUserRole<int>
{
    public User? User { get; set; }
    public Role? Role { get; set; }
}
