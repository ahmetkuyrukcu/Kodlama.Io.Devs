using Kodlama.Io.Devs.Application.Features.Technologies.Dtos;
using MediatR;

namespace Kodlama.Io.Devs.Application.Features.Technologies.Queries.GetByIdTechnology;

public class GetByIdTechnologyQuery : IRequest<TechnologyDto>
{
    public Guid Id { get; set; }
}