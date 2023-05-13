using System.Security.Claims;
using LearningApp.Contracts;
using LearningApp.Core.Classifiers;

namespace LearningApp.Web.HttpContexts;

public class AuthenticatedUserContext : IAuthenticatedUser
{
    public AuthenticatedUserContext(IHttpContextAccessor httpContextAccessor)
    {
        HttpContextAccessor = httpContextAccessor;
    }

    public IHttpContextAccessor HttpContextAccessor { get; }

    public IEnumerable<Claim> Claims => HttpContextAccessor.HttpContext?.User?.Claims ?? new List<Claim>(0);

    public int UserId
    {
        get
        {
            var id = Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            return !string.IsNullOrEmpty(id) ? int.Parse(id) : 1;
        }
    }

    public RoleType? Role
    {
        get
        {
            var role = Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role);

            return role == null ? null : (RoleType) Enum.Parse(typeof(RoleType), role.Value);
        }
    }
}
