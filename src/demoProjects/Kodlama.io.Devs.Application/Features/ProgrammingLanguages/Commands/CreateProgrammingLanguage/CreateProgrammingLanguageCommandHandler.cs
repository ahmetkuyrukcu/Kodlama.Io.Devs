using AutoMapper;
using Kodlama.Io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using Kodlama.Io.Devs.Application.Features.ProgrammingLanguages.Rules;
using Kodlama.Io.Devs.Application.Services.Repositories;
using Kodlama.Io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.Io.Devs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;

public class CreateProgrammingLanguageCommandHandler : IRequestHandler<CreateProgrammingLanguageCommand, ProgrammingLanguageDto>
{
    private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
    private readonly IMapper _mapper;
    private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

    public CreateProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
    {
        _programmingLanguageRepository = programmingLanguageRepository;
        _mapper = mapper;
        _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
    }

    public async Task<ProgrammingLanguageDto> Handle(CreateProgrammingLanguageCommand request, CancellationToken cancellationToken)
    {
        await _programmingLanguageBusinessRules.BrandNameCanNotBeDuplicatedWhenInserted(request.Name);

        return _mapper.Map<ProgrammingLanguageDto>(await _programmingLanguageRepository.AddAsync(_mapper.Map<ProgrammingLanguage>(request)));
    }
}