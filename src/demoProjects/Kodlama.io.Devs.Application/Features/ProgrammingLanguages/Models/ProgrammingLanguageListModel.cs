using Core.Persistence.Paging;
using Kodlama.Io.Devs.Application.Features.ProgrammingLanguages.Dtos;

namespace Kodlama.Io.Devs.Application.Features.ProgrammingLanguages.Models;

public class ProgrammingLanguageListModel : BasePageableModel
{
    public IList<ProgrammingLanguageDto> Items { get; set; }
}