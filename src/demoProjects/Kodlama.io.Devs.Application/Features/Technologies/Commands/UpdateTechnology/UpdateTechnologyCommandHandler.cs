using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Kodlama.Io.Devs.Application.Features.Technologies.Dtos;
using Kodlama.Io.Devs.Application.Features.Technologies.Rules;
using Kodlama.Io.Devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.Io.Devs.Application.Features.Technologies.Commands.UpdateTechnology;

public class UpdateTechnologyCommandHandler : IRequestHandler<UpdateTechnologyCommand, TechnologyDto>
{
    private readonly ITechnologyRepository _technologyRepository;
    private readonly IMapper _mapper;
    private readonly TechnologyBusinessRules _technologyBusinessRules;

    public UpdateTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper, TechnologyBusinessRules technologyBusinessRules)
    {
        _technologyRepository = technologyRepository;
        _mapper = mapper;
        _technologyBusinessRules = technologyBusinessRules;
    }

    public async Task<TechnologyDto> Handle(UpdateTechnologyCommand request, CancellationToken cancellationToken)
    {
        var technology = await _technologyRepository.GetAsync(x => x.Id == request.Id, cancellationToken);

        if (technology == null)
        {
            throw new BusinessException("Technology not found!");
        }

        await _technologyBusinessRules.TechnologyNameCanNotBeDuplicatedWhenUpdated(request.Name, request.Id);

        _mapper.Map(request, technology);

        return _mapper.Map<TechnologyDto>(await _technologyRepository.UpdateAsync(technology));
    }
}