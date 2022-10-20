using AutoMapper;
using Core.Persistence.Paging;
using KodlamaIoDevs.Application.Features.SocialMedia.Command.CreateSocialMedia;
using KodlamaIoDevs.Application.Features.SocialMedia.Command.DeleteSocialMedia;
using KodlamaIoDevs.Application.Features.SocialMedia.Command.UpdateSocialMedia;
using KodlamaIoDevs.Application.Features.SocialMedia.Dtos;
using KodlamaIoDevs.Application.Features.SocialMedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.SocialMedia.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            // Create
            CreateMap<Domain.Entities.SocialMedia, CreateSocialMediaCommand>().ReverseMap();
            CreateMap<Domain.Entities.SocialMedia, CreatedSocialMediaDto>().ReverseMap();

            // Delete
            CreateMap<Domain.Entities.SocialMedia, DeleteSocialMediaCommand>().ReverseMap();
            CreateMap<Domain.Entities.SocialMedia, DeletedSocialMediaDto>().ReverseMap();

            // Update
            CreateMap<Domain.Entities.SocialMedia, UpdateSocialMediaCommand>().ReverseMap();
            CreateMap<Domain.Entities.SocialMedia, UpdatedSocialMediaDto>().ReverseMap();

            // get list
            CreateMap<SocialMediaListModel, IPaginate<Domain.Entities.SocialMedia>>().ReverseMap();
            CreateMap<Domain.Entities.SocialMedia, SocialMediaListDto>()
                .ForMember(dest => dest.DeveloperFullName, src =>
                    src.MapFrom(c => c.User.FirstName + " " + c.User.LastName)).ReverseMap();
        }
    }
}
