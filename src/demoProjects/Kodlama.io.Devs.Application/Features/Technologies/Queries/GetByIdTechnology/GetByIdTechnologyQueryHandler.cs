using AutoMapper;
using Kodlama.Io.Devs.Application.Features.Technologies.Dtos;
using Kodlama.Io.Devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.Io.Devs.Application.Features.Technologies.Queries.GetByIdTechnology;

public class GetByIdTechnologyQueryHandler : IRequestHandler<GetByIdTechnologyQuery, TechnologyDto>
{
    private readonly ITechnologyRepository _technologyRepository;
    private readonly IMapper _mapper;

    public GetByIdTechnologyQueryHandler(ITechnologyRepository technologyRepository, IMapper mapper)
    {
        _technologyRepository = technologyRepository;
        _mapper = mapper;
    }

    public async Task<TechnologyDto> Handle(GetByIdTechnologyQuery request, CancellationToken cancellationToken)
    {
        return _mapper.Map<TechnologyDto>(await _technologyRepository.GetAsync(x => x.Id == request.Id, cancellationToken));
    }
}