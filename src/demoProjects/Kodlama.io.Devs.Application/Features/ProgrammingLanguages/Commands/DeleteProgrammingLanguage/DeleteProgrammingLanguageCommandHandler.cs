using Core.CrossCuttingConcerns.Exceptions;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;

public class DeleteProgrammingLanguageCommandHandler : IRequestHandler<DeleteProgrammingLanguageCommand>
{
    private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

    public DeleteProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository)
    {
        _programmingLanguageRepository = programmingLanguageRepository;
    }

    public async Task<Unit> Handle(DeleteProgrammingLanguageCommand request, CancellationToken cancellationToken)
    {
        var programmingLanguage = await _programmingLanguageRepository.GetAsync(x => x.Id == request.Id, cancellationToken);

        if (programmingLanguage is null) throw new BusinessException("Programming Language not found!");

        await _programmingLanguageRepository.DeleteAsync(programmingLanguage);

        return Unit.Value;
    }
}