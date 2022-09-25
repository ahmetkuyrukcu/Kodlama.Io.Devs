using Kodlama.Io.Devs.Application.Features.ProgrammingLanguages.Dtos;

namespace Kodlama.Io.Devs.Application.Features.Technologies.Dtos;

public class TechnologyDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public ProgrammingLanguageDto ProgrammingLanguage { get; set; }
}