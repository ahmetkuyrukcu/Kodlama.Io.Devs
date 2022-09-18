using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.Technologies.Dtos;
using Kodlama.io.Devs.Application.Features.Technologies.Models;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.Technologies.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Technology, TechnologyDto>().ReverseMap();
        //CreateMap<Technology, CreateTechnologyCommand>().ReverseMap();
        //CreateMap<Technology, UpdateTechnologyCommand>().ReverseMap();
        CreateMap<IPaginate<Technology>, TechnologyListModel>().ReverseMap();
    }
}