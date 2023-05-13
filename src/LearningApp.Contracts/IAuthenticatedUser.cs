using LearningApp.Core.Classifiers;

namespace LearningApp.Contracts;

public interface IAuthenticatedUser
{
    int UserId { get; }
    RoleType? Role { get; }
}
