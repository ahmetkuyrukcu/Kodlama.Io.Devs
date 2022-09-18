using Kodlama.Io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using MediatR;

namespace Kodlama.Io.Devs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;

public class CreateProgrammingLanguageCommand : IRequest<ProgrammingLanguageDto>
{
    public string Name { get; set; }
}