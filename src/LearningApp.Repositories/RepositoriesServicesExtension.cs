using LearningApp.Contracts.Repositories;
using LearningApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LearningApp.Repositories;

public static class RepositoriesServicesExtension
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IChaptersRepository, ChaptersRepository>();
        services.AddScoped<IChapterTestQuestionsRepository, ChapterTestQuestionsRepository>();
        services.AddScoped<IChapterTestsRepository, ChapterTestsRepository>();
        services.AddScoped<ILecturesRepository, LecturesRepository>();
        services.AddScoped<ILectureTestQuestionsRepository, LectureTestQuestionsRepository>();
        services.AddScoped<ILectureTestsRepository, LectureTestsRepository>();

        services.AddTransient<IRepositoryWrapper, RepositoryWrapper>();

        return services;
    }

    public static IServiceCollection AddPostgreSqlDbContext(this IServiceCollection services,
        Action<DbContextOptionsBuilder> options)
    {
        services.AddDbContextPool<LearningContext>(options);
        return services;
    }
}
