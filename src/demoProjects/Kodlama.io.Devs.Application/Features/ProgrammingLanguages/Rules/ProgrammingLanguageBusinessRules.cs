using Core.CrossCuttingConcerns.Exceptions;
using Kodlama.Io.Devs.Application.Services.Repositories;

namespace Kodlama.Io.Devs.Application.Features.ProgrammingLanguages.Rules;

public class ProgrammingLanguageBusinessRules
{
    private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

    public ProgrammingLanguageBusinessRules(IProgrammingLanguageRepository programmingLanguageRepository)
    {
        _programmingLanguageRepository = programmingLanguageRepository;
    }

    public async Task BrandNameCanNotBeDuplicatedWhenInserted(string name)
    {
        if ((await _programmingLanguageRepository.GetListAsync(x => x.Name == name)).Items.Any())
        {
            throw new BusinessException("Programming Language name exists.");
        }
    }

    public async Task BrandNameCanNotBeDuplicatedWhenUpdated(string name, Guid id)
    {
        if ((await _programmingLanguageRepository.GetListAsync(x => x.Name == name && x.Id != id)).Items.Any())
        {
            throw new BusinessException("Programming Language name exists.");
        }
    }
}