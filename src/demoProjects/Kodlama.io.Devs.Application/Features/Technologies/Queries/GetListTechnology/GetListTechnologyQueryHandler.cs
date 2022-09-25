using AutoMapper;
using Kodlama.Io.Devs.Application.Features.Technologies.Models;
using Kodlama.Io.Devs.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.Io.Devs.Application.Features.Technologies.Queries.GetListTechnology;

public class GetListTechnologyQueryHandler : IRequestHandler<GetListTechnologyQuery, TechnologyListModel>
{
    private readonly ITechnologyRepository _technologyRepository;
    private readonly IMapper _mapper;

    public GetListTechnologyQueryHandler(ITechnologyRepository technologyRepository, IMapper mapper)
    {
        _technologyRepository = technologyRepository;
        _mapper = mapper;
    }

    public async Task<TechnologyListModel> Handle(GetListTechnologyQuery request, CancellationToken cancellationToken)
    {
        return _mapper.Map<TechnologyListModel>(await _technologyRepository.GetListAsync(include: source => source.Include(x => x.ProgrammingLanguage), index: request.PageRequest.Page, size: request.PageRequest.PageSize, cancellationToken: cancellationToken));
    }
}