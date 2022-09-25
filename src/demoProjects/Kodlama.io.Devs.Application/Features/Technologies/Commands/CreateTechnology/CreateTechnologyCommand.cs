using Kodlama.Io.Devs.Application.Features.Technologies.Dtos;
using MediatR;

namespace Kodlama.Io.Devs.Application.Features.Technologies.Commands.CreateTechnology;

public class CreateTechnologyCommand : IRequest<TechnologyDto>
{
    public string Name { get; set; }

    public Guid ProgrammingLanguageId { get; set; }
}