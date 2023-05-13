using AutoMapper;
using LearningApp.Models.DataTransferObjects;
using LearningApp.Models.Entities;

namespace LearningApp.Services.Mapping;

public class LecturesMappingProfile : Profile
{
    public LecturesMappingProfile()
    {
        CreateMap<Lecture, LectureDto>();
        CreateMap<LectureTest, LectureTestWithQuestionsDto>()
            .ForMember(lt => lt.Questions,
                expression => expression.MapFrom(lt => lt.LectureTestQuestions));
        CreateMap<LectureTest, TestDto>()
            .ForMember(lt => lt.Questions,
                expression => expression.MapFrom(lt => lt.LectureTestQuestions))
            .ForMember(lt => lt.Results,
                expression => expression.MapFrom(lt => lt.LectureTestResults))
            .ForMember(lt => lt.QuestionsCount,
                expression => expression.MapFrom(lt => lt.LectureTestQuestions.Count()));
        ;
        CreateMap<LectureTestQuestion, TestQuestionDto>()
            .ForMember(ltq => ltq.Answers,
                expression => expression.MapFrom(ltq =>
                    ltq.LectureTestAnswers!.Select(lta => lta.Answer)));
        CreateMap<LectureTestResult, TestResultDto>()
            .ForMember(x => x.FirstName,
                expression => expression.MapFrom(x => x.User.FirstName))
            .ForMember(x => x.LastName,
                expression => expression.MapFrom(x => x.User.LastName));
    }
}
