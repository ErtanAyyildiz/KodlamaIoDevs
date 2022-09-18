using KodlamaIoDevs.Application.Features.Technology.Dtos;
using MediatR;

namespace KodlamaIoDevs.Application.Features.Technology.Commands.DeleteTechnology
{
    public class DeleteTechnologyCommand: IRequest<DeletedTechnologyDto>
    {
        public int Id { get; set; }
    }
}
