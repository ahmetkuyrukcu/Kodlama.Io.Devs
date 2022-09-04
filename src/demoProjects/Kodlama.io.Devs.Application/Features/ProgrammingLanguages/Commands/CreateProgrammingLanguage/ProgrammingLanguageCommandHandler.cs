using AutoMapper;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;

public class ProgrammingLanguageCommandHandler : IRequestHandler<ProgrammingLanguageCommand, ProgrammingLanguageDto>
{
    private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
    private readonly IMapper _mapper;
    private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

    public ProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
    {
        _programmingLanguageRepository = programmingLanguageRepository;
        _mapper = mapper;
        _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
    }

    public async Task<ProgrammingLanguageDto> Handle(ProgrammingLanguageCommand request, CancellationToken cancellationToken)
    {
        await _programmingLanguageBusinessRules.BrandNameCanNotBeDuplicatedWhenInserted(request.Name);

        return _mapper.Map<ProgrammingLanguageDto>(await _programmingLanguageRepository.AddAsync(_mapper.Map<ProgrammingLanguage>(request)));
    }
}