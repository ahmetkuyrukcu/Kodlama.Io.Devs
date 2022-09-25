using Core.CrossCuttingConcerns.Exceptions;
using Kodlama.Io.Devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.Io.Devs.Application.Features.Technologies.Commands.DeleteTechnology;

public class DeleteTechnologyCommandHandler : IRequestHandler<DeleteTechnologyCommand>
{
    private readonly ITechnologyRepository _technologyRepository;

    public DeleteTechnologyCommandHandler(ITechnologyRepository technologyRepository)
    {
        _technologyRepository = technologyRepository;
    }

    public async Task<Unit> Handle(DeleteTechnologyCommand request, CancellationToken cancellationToken)
    {
        var technology = await _technologyRepository.GetAsync(x => x.Id == request.Id, cancellationToken);

        if (technology == null)
        {
            throw new BusinessException("Technology not found!");
        }

        await _technologyRepository.DeleteAsync(technology);

        return Unit.Value;
    }
}