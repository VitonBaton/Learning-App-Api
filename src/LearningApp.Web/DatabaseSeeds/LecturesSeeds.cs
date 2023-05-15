using System.Text.Json;
using LearningApp.Contracts;
using LearningApp.Contracts.Repositories;
using LearningApp.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LearningApp.Web.DatabaseSeeds;

public sealed class LecturesSeeds : ISeedsProvider
{
    private readonly IChaptersRepository _chaptersRepository;
    private readonly ILearningContext _learningContext;
    private readonly ILecturesRepository _lecturesRepository;
    private readonly SeedsSettings _seedsSettings;

    public LecturesSeeds(IChaptersRepository chaptersRepository, ILearningContext learningContext,
        IOptions<SeedsSettings> options, ILecturesRepository lecturesRepository)
    {
        _chaptersRepository = chaptersRepository;
        _learningContext = learningContext;
        _lecturesRepository = lecturesRepository;
        _seedsSettings = options.Value;
    }

    public async Task Seed(CancellationToken cancellationToken)
    {
        if (!_seedsSettings.UsePredefinedSeeds)
        {
            return;
        }

        await using var stream = File.OpenRead("./DatabaseSeeds/SeedsData/lectures.json");
        var chapters =
            await JsonSerializer.DeserializeAsync<IEnumerable<Chapter>>(stream, cancellationToken: cancellationToken);
        foreach (var chapter in chapters!)
        {
            if (await _chaptersRepository.FindByCondition(x => x.Title == chapter.Title)
                    .FirstOrDefaultAsync(cancellationToken) is null)
            {
                await _chaptersRepository.Create(chapter);
            }
        }

        await _learningContext.SaveChangesAsync(cancellationToken);
    }
}
