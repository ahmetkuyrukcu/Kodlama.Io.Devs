using AutoMapper;
using Kodlama.Io.Devs.Application.Features.ProgrammingLanguages.Models;
using Kodlama.Io.Devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.Io.Devs.Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage;

public class GetListProgrammingLanguageQueryHandler : IRequestHandler<GetListProgrammingLanguageQuery, ProgrammingLanguageListModel>
{
    private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
    private readonly IMapper _mapper;

    public GetListProgrammingLanguageQueryHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper)
    {
        _programmingLanguageRepository = programmingLanguageRepository;
        _mapper = mapper;
    }

    public async Task<ProgrammingLanguageListModel> Handle(GetListProgrammingLanguageQuery request, CancellationToken cancellationToken)
    {
        return _mapper.Map<ProgrammingLanguageListModel>(await _programmingLanguageRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize, cancellationToken: cancellationToken));
    }
}