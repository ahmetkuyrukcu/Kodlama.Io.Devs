using Core.Application.Requests;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Models;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage;

public class GetListProgrammingLanguageQuery : IRequest<ProgrammingLanguageListModel>
{
    public PageRequest PageRequest { get; set; }
}