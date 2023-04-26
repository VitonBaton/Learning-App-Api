using FluentValidation;
using LearningApp.Entities.DataTransferObjects;

namespace LearningApp.Services.ValidationRules;

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
