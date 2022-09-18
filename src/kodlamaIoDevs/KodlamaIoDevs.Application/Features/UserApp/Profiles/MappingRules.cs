using AutoMapper;
using Core.Security.Entities;
using Core.Security.JWT;
using KodlamaIoDevs.Application.Features.UserApp.Commands.RegisterUserApp;
using KodlamaIoDevs.Application.Features.UserApp.Dtos;

namespace KodlamaIoDevs.Application.Features.UserApp.Profiles
{
    public class MappingRules: Profile
    {
        public MappingRules()
        {
            CreateMap<User, RegisterUserAppCommand>().ReverseMap();
            CreateMap<TokenDto, AccessToken>().ReverseMap();
        }
    }
}
