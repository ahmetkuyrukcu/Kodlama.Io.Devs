using Core.CrossCuttingConcerns.Exceptions;
using Kodlama.Io.Devs.Application.Services.Repositories;

namespace Kodlama.Io.Devs.Application.Features.Technologies.Rules;

public class TechnologyBusinessRules
{
    private readonly ITechnologyRepository _technologyRepository;

    public TechnologyBusinessRules(ITechnologyRepository technologyRepository)
    {
        _technologyRepository = technologyRepository;
    }

    public async Task TechnologyNameCanNotBeDuplicatedWhenInserted(string name)
    {
        if ((await _technologyRepository.GetListAsync(x => x.Name == name)).Items.Any())
        {
            throw new BusinessException("Technology name exists.");
        }
    }
}