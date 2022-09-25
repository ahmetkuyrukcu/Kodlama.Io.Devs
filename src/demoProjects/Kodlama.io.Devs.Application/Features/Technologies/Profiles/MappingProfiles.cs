using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.Io.Devs.Application.Features.Technologies.Commands.CreateTechnology;
using Kodlama.Io.Devs.Application.Features.Technologies.Commands.UpdateTechnology;
using Kodlama.Io.Devs.Application.Features.Technologies.Dtos;
using Kodlama.Io.Devs.Application.Features.Technologies.Models;
using Kodlama.Io.Devs.Domain.Entities;

namespace Kodlama.Io.Devs.Application.Features.Technologies.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Technology, TechnologyDto>().ReverseMap();
        CreateMap<Technology, CreateTechnologyCommand>().ReverseMap();
        CreateMap<Technology, UpdateTechnologyCommand>().ReverseMap();
        CreateMap<IPaginate<Technology>, TechnologyListModel>().ReverseMap();
    }
}