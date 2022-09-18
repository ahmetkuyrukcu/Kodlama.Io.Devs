using Kodlama.Io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using MediatR;

namespace Kodlama.Io.Devs.Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage;

public class GetByIdProgrammingLanguageQuery : IRequest<ProgrammingLanguageDto>
{
    public Guid Id { get; set; }
}