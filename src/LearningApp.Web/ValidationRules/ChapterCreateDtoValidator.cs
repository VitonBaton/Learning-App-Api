using FluentValidation;
using LearningApp.Models.DataTransferObjects;

namespace LearningApp.Web.ValidationRules;

public class ChapterCreateDtoValidator : AbstractValidator<ChapterCreateDto>
{
    public ChapterCreateDtoValidator()
    {
        RuleFor(x => x.Order)
            .GreaterThan(0);

        RuleFor(x => x.Title)
            .NotEmpty();

        RuleFor(x => x.Description)
            .NotEmpty();
    }
}
