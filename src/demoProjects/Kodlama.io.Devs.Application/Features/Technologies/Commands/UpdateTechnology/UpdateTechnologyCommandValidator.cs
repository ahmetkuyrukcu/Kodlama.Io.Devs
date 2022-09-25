using FluentValidation;

namespace Kodlama.Io.Devs.Application.Features.Technologies.Commands.UpdateTechnology;

public class UpdateTechnologyCommandValidator : AbstractValidator<UpdateTechnologyCommand>
{
    public UpdateTechnologyCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Name).MinimumLength(2);
    }
}