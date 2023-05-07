using LearningApp.Contracts.Repositories;
using LearningApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LearningApp.DataAccess.Repositories;

public sealed class UsersRepository : RepositoryBase<User>, IUsersRepository
{
    public UsersRepository(DbSet<User> entities)
        : base(entities)
    {
    }
}
