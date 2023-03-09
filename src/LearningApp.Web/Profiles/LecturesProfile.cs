using AutoMapper;
using LearningApp.Entities.DataTransferObjects;
using LearningApp.Entities.Models;

namespace LearningApp.Web.Profiles;

public class LecturesProfile : Profile
{
    public LecturesProfile()
    {
        CreateMap<Lecture, LectureDto>();
        CreateMap<LectureTest, LectureTestWithQuestionsDto>()
            .ForMember(lt => lt.Questions,
                expression => expression.MapFrom(lt => lt.LectureTestQuestions));
        CreateMap<LectureTest, TestDto>()
            .ForMember(lt => lt.Questions,
                expression => expression.MapFrom(lt => lt.LectureTestQuestions));
        CreateMap<LectureTestQuestion, TestQuestionDto>()
            .ForMember(ltq => ltq.Answers,
                expression => expression.MapFrom(ltq =>
                    ltq.LectureTestAnswers!.Select(lta => lta.Answer)));
    }
}