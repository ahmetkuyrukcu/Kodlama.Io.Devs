using MediatR;

namespace Kodlama.Io.Devs.Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;

public class DeleteProgrammingLanguageCommand : IRequest
{
    public Guid Id { get; set; }
}