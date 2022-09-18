using Core.Persistence.Paging;
using Kodlama.Io.Devs.Application.Features.Technologies.Dtos;

namespace Kodlama.Io.Devs.Application.Features.Technologies.Models;

public class TechnologyListModel : BasePageableModel
{
    public IList<TechnologyDto> Items { get; set; }
}