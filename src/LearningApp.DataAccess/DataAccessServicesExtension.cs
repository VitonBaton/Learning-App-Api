using LearningApp.Contracts.Repositories;
using LearningApp.DataAccess.Repositories;
using LearningApp.Models;
using LearningApp.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LearningApp.DataAccess;

public static class DataAccessServicesExtension
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IChaptersRepository, ChaptersRepository>();
        services.AddScoped<IChapterTestQuestionsRepository, ChapterTestQuestionsRepository>();
        services.AddScoped<IChapterTestsRepository, ChapterTestsRepository>();
        services.AddScoped<ILecturesRepository, LecturesRepository>();
        services.AddScoped<ILectureTestQuestionsRepository, LectureTestQuestionsRepository>();
        services.AddScoped<ILectureTestsRepository, LectureTestsRepository>();

        return services;
    }

    public static IServiceCollection AddPostgreSqlDbContext(this IServiceCollection services,
        Action<DbContextOptionsBuilder> options)
    {
        services.AddDbContextPool<LearningDbContext>(options);
        services.AddScoped<ILearningContext, LearningContext>();
        services.AddDbSet<Chapter>();
        services.AddDbSet<ChapterTest>();
        services.AddDbSet<ChapterTestAnswer>();
        services.AddDbSet<ChapterTestQuestion>();
        services.AddDbSet<Lecture>();
        services.AddDbSet<LectureTest>();
        services.AddDbSet<LectureTestAnswer>();
        services.AddDbSet<LectureTestQuestion>();
        services.AddDbSet<ChapterTestResult>();
        services.AddDbSet<LectureTestResult>();

        return services;
    }

    private static IServiceCollection AddDbSet<T>(this IServiceCollection services) where T : class
    {
        services.AddScoped(serviceProvider => serviceProvider.GetRequiredService<LearningDbContext>().Set<T>());

        return services;
    }
}
