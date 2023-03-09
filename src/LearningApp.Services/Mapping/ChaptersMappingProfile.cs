using AutoMapper;
using LearningApp.Entities.DataTransferObjects;
using LearningApp.Entities.Models;

namespace LearningApp.Services.Mapping;

public class ChaptersMappingProfile : Profile
{
    public ChaptersMappingProfile()
    {
        CreateMap<Chapter, ChapterDto>()
            .ForMember(c => c.Lectures,
                expression => expression.MapFrom(c => c.Lectures));
        CreateMap<ChapterTest, ChapterTestWithQuestionsDto>()
            .ForMember(lt => lt.Questions,
                expression => expression.MapFrom(lt => lt.ChapterTestQuestions));
        CreateMap<ChapterTest, TestDto>()
            .ForMember(lt => lt.Questions,
                expression => expression.MapFrom(lt => lt.ChapterTestQuestions));
        CreateMap<ChapterTestQuestion, TestQuestionDto>()
            .ForMember(ltq => ltq.Answers,
                expression => expression.MapFrom(ltq =>
                    ltq.ChapterTestAnswers!.Select(lta => lta.Answer)));

        CreateMap<ChapterForCreationDto, Chapter>();
    }
}