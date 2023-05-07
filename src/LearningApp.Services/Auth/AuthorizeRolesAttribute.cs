﻿using LearningApp.Core.Classifiers;
using Microsoft.AspNetCore.Authorization;

namespace LearningApp.Services.Auth;

public class AuthorizeRolesAttribute : AuthorizeAttribute
{
    public AuthorizeRolesAttribute(params RoleType[] roles)
    {
        if (roles.Any())
        {
            Roles = string.Join(",", roles.Select(x => x.ToString()));
        }
    }
}
