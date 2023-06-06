using AutoMapper;
using LearningApp.Models.DataTransferObjects;
using LearningApp.Models.Entities;

namespace LearningApp.Services.Mapping;

public class ChaptersMappingProfile : Profile
{
    public ChaptersMappingProfile()
    {
        CreateMap<Chapter, ChapterDto>()
            .ForMember(c => c.Lectures,
                expression => expression.MapFrom(c => c.Lectures));

        CreateMap<Chapter, ChapterWithTestsDto>()
            .ForMember(c => c.Tests,
                expression => expression.MapFrom(c => c.ChapterTests));


        CreateMap<Chapter, ChapterWithLecturesAndTestsDto>()
            .ForMember(c => c.Tests,
                expression => expression.MapFrom(c => c.ChapterTests));

        CreateMap<ChapterTest, ChapterTestWithQuestionsDto>()
            .ForMember(lt => lt.Questions,
                expression => expression.MapFrom(lt => lt.ChapterTestQuestions));
        CreateMap<ChapterTest, TestDto>()
            .ForMember(lt => lt.Questions,
                expression => expression.MapFrom(lt => lt.ChapterTestQuestions))
            .ForMember(lt => lt.Results,
                expression => expression.MapFrom(lt => lt.ChapterTestResults))
            .ForMember(ct => ct.QuestionsCount,
                expression => expression.MapFrom(ct => ct.ChapterTestQuestions.Count()));
        CreateMap<ChapterTestQuestion, TestQuestionDto>()
            .ForMember(ltq => ltq.Answers,
                expression => expression.MapFrom(ltq =>
                    ltq.ChapterTestAnswers!.Select(lta => lta.Answer)));

        CreateMap<ChapterTest, SimpleTestDto>();

        CreateMap<ChapterTestResult, TestResultDto>()
            .ForMember(x => x.FirstName,
                expression => expression.MapFrom(x => x.User.FirstName))
            .ForMember(x => x.LastName,
                expression => expression.MapFrom(x => x.User.LastName));

        CreateMap<ChapterCreateDto, Chapter>();

        CreateMap<TestCreateDto, ChapterTest>()
            .ForMember(x => x.ChapterId,
                expression => expression.MapFrom(x => x.ParentId))
            .ForMember(x => x.ChapterTestQuestions,
                expression => expression.MapFrom(x => x.TestQuestions));

        CreateMap<TestQuestionCreateDto, ChapterTestQuestion>()
            .ForMember(x => x.ChapterTestAnswers,
                expression => expression.MapFrom(x => x.TestAnswers));

        CreateMap<TestAnswerCreateDto, ChapterTestAnswer>();
    }
}
