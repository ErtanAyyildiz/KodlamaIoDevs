using KodlamaIoDevs.Application.Features.Technology.Dtos;
using MediatR;

namespace KodlamaIoDevs.Application.Features.Technology.Commands.CreateTechnology
{
    public class CreateTechnologyCommand: IRequest<CreatedTechnologyDto>
    {
        public string Name { get; set; }
        public int ProgrammingLanguageId { get; set; }
    }
}
