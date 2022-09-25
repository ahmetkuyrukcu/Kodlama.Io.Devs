using AutoMapper;
using Kodlama.Io.Devs.Application.Features.Technologies.Dtos;
using Kodlama.Io.Devs.Application.Features.Technologies.Rules;
using Kodlama.Io.Devs.Application.Services.Repositories;
using Kodlama.Io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.Io.Devs.Application.Features.Technologies.Commands.CreateTechnology;

public class CreateTechnologyCommandHandler : IRequestHandler<CreateTechnologyCommand, TechnologyDto>
{
    private readonly ITechnologyRepository _technologyRepository;
    private readonly IMapper _mapper;
    private readonly TechnologyBusinessRules _technologyBusinessRules;

    public CreateTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper, TechnologyBusinessRules technologyBusinessRules)
    {
        _technologyRepository = technologyRepository;
        _mapper = mapper;
        _technologyBusinessRules = technologyBusinessRules;
    }

    public async Task<TechnologyDto> Handle(CreateTechnologyCommand request, CancellationToken cancellationToken)
    {
        await _technologyBusinessRules.TechnologyNameCanNotBeDuplicatedWhenInserted(request.Name);

        return _mapper.Map<TechnologyDto>(await _technologyRepository.AddAsync(_mapper.Map<Technology>(request)));
    }
}