namespace LearningApp.Core.Helpers;

public static class UsersHelper
{
    public static string GenerateUserName(string email) {
        return email.Replace("@", "").Replace(".", "").Replace("-", "");
    }
}
