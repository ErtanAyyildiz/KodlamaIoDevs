using AutoMapper;
using Core.Persistence.Paging;
using KodlamaIoDevs.Application.Features.Technology.Commands.CreateTechnology;
using KodlamaIoDevs.Application.Features.Technology.Commands.DeleteTechnology;
using KodlamaIoDevs.Application.Features.Technology.Commands.UpdateTechnology;
using KodlamaIoDevs.Application.Features.Technology.Dtos;
using KodlamaIoDevs.Application.Features.Technology.Models;

namespace KodlamaIoDevs.Application.Features.Technology.Profiles
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {

            // Query
            CreateMap<IPaginate<Domain.Entities.Technology>, TechnologyListModel>().ReverseMap();
            CreateMap<Domain.Entities.Technology, TechnologyListDto>()
                .ForMember(target => target.ProgrammingLanguageName, opt =>
                    opt.MapFrom(resource => resource.ProgrammingLanguage.Name)).ReverseMap();

            // Create
            CreateMap<Domain.Entities.Technology, CreatedTechnologyDto>().ReverseMap();
            CreateMap<Domain.Entities.Technology, CreateTechnologyCommand>().ReverseMap();

            // Update
            CreateMap<Domain.Entities.Technology, UpdatedTechnologyDto>().ReverseMap();
            CreateMap<Domain.Entities.Technology, UpdateTechnologyCommand>().ReverseMap();

            // Delete
            CreateMap<Domain.Entities.Technology, DeletedTechnologyDto>().ReverseMap();
            CreateMap<Domain.Entities.Technology, DeleteTechnologyCommand>().ReverseMap();

        }
    }
}
