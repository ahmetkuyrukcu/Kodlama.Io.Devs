using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;

public class UpdateProgrammingLanguageCommand : IRequest<ProgrammingLanguageDto>
{
    public Guid Id { get; set; }

    public string Name { get; set; }
}