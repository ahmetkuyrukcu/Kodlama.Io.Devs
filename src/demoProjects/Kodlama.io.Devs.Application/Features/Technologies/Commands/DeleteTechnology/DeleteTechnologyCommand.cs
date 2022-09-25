using MediatR;

namespace Kodlama.Io.Devs.Application.Features.Technologies.Commands.DeleteTechnology;

public class DeleteTechnologyCommand : IRequest
{
    public Guid Id { get; set; }
}