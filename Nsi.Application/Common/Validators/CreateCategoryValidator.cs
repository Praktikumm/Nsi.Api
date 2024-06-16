using FluentValidation;
using Nsi.Application.Common.Dto.Category;

namespace Nsi.Application.Common.Validators;

public class CreateCategoryValidator : AbstractValidator<CreateCategoryDto>
{
    public CreateCategoryValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(50)
            .WithMessage("Title is required");

        RuleFor(x => x.Content)
            .NotEmpty()
            .WithMessage("Content is required");
    }
}