﻿using LearningApp.Core.Classifiers;

namespace LearningApp.Models.DataTransferObjects;

public sealed class UserRegistrationDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public RoleType Role { get; set; }
}
