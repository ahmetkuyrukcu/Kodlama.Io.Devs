using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.Io.Devs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using Kodlama.Io.Devs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
using Kodlama.Io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using Kodlama.Io.Devs.Application.Features.ProgrammingLanguages.Models;
using Kodlama.Io.Devs.Domain.Entities;

namespace Kodlama.Io.Devs.Application.Features.ProgrammingLanguages.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ProgrammingLanguage, ProgrammingLanguageDto>().ReverseMap();
        CreateMap<ProgrammingLanguage, CreateProgrammingLanguageCommand>().ReverseMap();
        CreateMap<ProgrammingLanguage, UpdateProgrammingLanguageCommand>().ReverseMap();
        CreateMap<IPaginate<ProgrammingLanguage>, ProgrammingLanguageListModel>().ReverseMap();
    }
}