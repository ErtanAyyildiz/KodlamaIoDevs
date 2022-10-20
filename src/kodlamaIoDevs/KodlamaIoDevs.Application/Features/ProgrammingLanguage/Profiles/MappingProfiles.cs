using AutoMapper;
using Core.Persistence.Paging;
using KodlamaIoDevs.Application.Features.ProgrammingLanguage.Commands.CreateProgrammingLanguage;
using KodlamaIoDevs.Application.Features.ProgrammingLanguage.Commands.DeleteProgrammingLanguage;
using KodlamaIoDevs.Application.Features.ProgrammingLanguage.Commands.UpdateProgrammingLanguage;
using KodlamaIoDevs.Application.Features.ProgrammingLanguage.Dtos;
using KodlamaIoDevs.Application.Features.ProgrammingLanguage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.ProgrammingLanguage.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            // creating
            CreateMap<Domain.Entities.ProgrammingLanguage, CreatedProgrammingLanguageDto>().ReverseMap();
            CreateMap<Domain.Entities.ProgrammingLanguage, CreateProgrammingLanguageCommand>().ReverseMap();

            // deleting
            CreateMap<Domain.Entities.ProgrammingLanguage, DeletedProgrammingLanguageDto>().ReverseMap();
            CreateMap<Domain.Entities.ProgrammingLanguage, DeleteProgrammingLanguageCommand>().ReverseMap();

            //updating
            CreateMap<Domain.Entities.ProgrammingLanguage, UpdateProgrammingLanguageDto>().ReverseMap();
            CreateMap<Domain.Entities.ProgrammingLanguage, UpdateProgrammingLanguageCommand>().ReverseMap();

            //getById
            CreateMap<Domain.Entities.ProgrammingLanguage, ProgrammingLanguageGetByIdDto>().ReverseMap();

            // get list
            CreateMap<IPaginate<Domain.Entities.ProgrammingLanguage>, ProgrammingLanguageListModel>();
            CreateMap<Domain.Entities.ProgrammingLanguage, ProgrammingLanguageDto>().ReverseMap();
        }
    }
}
