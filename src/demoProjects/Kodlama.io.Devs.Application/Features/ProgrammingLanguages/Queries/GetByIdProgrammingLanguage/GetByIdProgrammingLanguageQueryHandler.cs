using AutoMapper;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage;

public class GetByIdProgrammingLanguageQueryHandler : IRequestHandler<GetByIdProgrammingLanguageQuery, ProgrammingLanguageDto>
{
    private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
    private readonly IMapper _mapper;

    public GetByIdProgrammingLanguageQueryHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper)
    {
        _programmingLanguageRepository = programmingLanguageRepository;
        _mapper = mapper;
    }

    public async Task<ProgrammingLanguageDto> Handle(GetByIdProgrammingLanguageQuery request, CancellationToken cancellationToken)
    {
        return _mapper.Map<ProgrammingLanguageDto>(await _programmingLanguageRepository.GetAsync(x => x.Id == request.Id, cancellationToken));
    }
}