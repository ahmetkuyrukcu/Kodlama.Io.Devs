using Core.CrossCuttingConcerns.Exceptions;
using Kodlama.io.Devs.Application.Services.Repositories;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Rules;

public class ProgrammingLanguageBusinessRules
{
    private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

    public ProgrammingLanguageBusinessRules(IProgrammingLanguageRepository programmingLanguageRepository)
    {
        _programmingLanguageRepository = programmingLanguageRepository;
    }

    public async Task BrandNameCanNotBeDuplicatedWhenInserted(string name)
    {
        if ((await _programmingLanguageRepository.GetListAsync(x => x.Name == name)).Items.Any()) throw new BusinessException("Programming Language name exists.");
    }
}