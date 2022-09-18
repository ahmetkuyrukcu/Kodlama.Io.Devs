using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Kodlama.Io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using Kodlama.Io.Devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.Io.Devs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;

public class UpdateProgrammingLanguageCommandHandler : IRequestHandler<UpdateProgrammingLanguageCommand, ProgrammingLanguageDto>
{
    private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
    private readonly IMapper _mapper;

    public UpdateProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper)
    {
        _programmingLanguageRepository = programmingLanguageRepository;
        _mapper = mapper;
    }

    public async Task<ProgrammingLanguageDto> Handle(UpdateProgrammingLanguageCommand request, CancellationToken cancellationToken)
    {
        var programmingLanguage = await _programmingLanguageRepository.GetAsync(x => x.Id == request.Id, cancellationToken);

        if (programmingLanguage == null)
        {
            throw new BusinessException("Programming Language not found!");
        }

        _mapper.Map(request, programmingLanguage);

        return _mapper.Map<ProgrammingLanguageDto>(await _programmingLanguageRepository.UpdateAsync(programmingLanguage));
    }
}