using Kodlama.Io.Devs.Application.Features.Technologies.Dtos;
using MediatR;

namespace Kodlama.Io.Devs.Application.Features.Technologies.Commands.UpdateTechnology;

public class UpdateTechnologyCommand : IRequest<TechnologyDto>
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public Guid ProgrammingLanguageId { get; set; }
}