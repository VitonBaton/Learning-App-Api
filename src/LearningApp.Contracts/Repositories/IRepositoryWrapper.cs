namespace LearningApp.Contracts.Repositories;

public interface IRepositoryWrapper
{
    IChaptersRepository Chapters { get; }
    IChapterTestsRepository ChapterTests { get; }
    IChapterTestQuestionsRepository ChapterTestQuestions { get; }
    ILecturesRepository Lectures { get; }
    ILectureTestsRepository LectureTests { get; }
    ILectureTestQuestionsRepository LectureTestQuestions { get; }
    Task SaveAsync();
}



