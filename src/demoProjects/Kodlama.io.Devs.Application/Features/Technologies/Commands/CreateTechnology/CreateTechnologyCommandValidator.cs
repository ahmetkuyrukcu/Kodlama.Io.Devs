using FluentValidation;

namespace Kodlama.Io.Devs.Application.Features.Technologies.Commands.CreateTechnology;

public class CreateTechnologyCommandValidator : AbstractValidator<CreateTechnologyCommand>
{
    public CreateTechnologyCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Name).MinimumLength(2);
    }
}