namespace LearningApp.Models.DataTransferObjects;

public sealed class PasswordUpdateDto
{
    public string CurrentPassword { get; set; }

    public string NewPassword { get; set; }
}
