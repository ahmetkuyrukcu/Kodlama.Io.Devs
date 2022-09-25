using Core.Application.Requests;
using Kodlama.Io.Devs.Application.Features.Technologies.Models;
using MediatR;

namespace Kodlama.Io.Devs.Application.Features.Technologies.Queries.GetListTechnology;

public class GetListTechnologyQuery : IRequest<TechnologyListModel>
{
    public PageRequest PageRequest { get; set; }
}