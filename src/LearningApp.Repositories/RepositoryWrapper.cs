using LearningApp.Contracts.Repositories;
using LearningApp.Entities;

namespace LearningApp.Repositories;

public sealed class RepositoryWrapper : IRepositoryWrapper
{
    private readonly LearningContext _learningContext;
    private IChaptersRepository? _chaptersRepository;
    private IChapterTestsRepository? _chapterTestsRepository;
    private IChapterTestQuestionsRepository? _chapterTestQuestionsRepository;
    private ILecturesRepository? _lecturesRepository;
    private ILectureTestsRepository? _lectureTestsRepository;
    private ILectureTestQuestionsRepository? _lectureTestQuestionsRepository;

    public IChaptersRepository Chapters =>
        _chaptersRepository ??= new ChaptersRepository(_learningContext);
    
    public IChapterTestsRepository ChapterTests =>
        _chapterTestsRepository ??= new ChapterTestsRepository(_learningContext);
    
    public IChapterTestQuestionsRepository ChapterTestQuestions =>
        _chapterTestQuestionsRepository ??= new ChapterTestQuestionsRepository(_learningContext);
    public ILecturesRepository Lectures =>
        _lecturesRepository ??= new LecturesRepository(_learningContext);
    
    public ILectureTestsRepository LectureTests =>
        _lectureTestsRepository ??= new LectureTestsRepository(_learningContext);
    
    public ILectureTestQuestionsRepository LectureTestQuestions =>
        _lectureTestQuestionsRepository ??= new LectureTestQuestionsRepository(_learningContext);
    
    public RepositoryWrapper(LearningContext learningContext)
    {
        _learningContext = learningContext;
    }
    
    public Task SaveAsync()
    {
        return _learningContext.SaveChangesAsync();
    }
}