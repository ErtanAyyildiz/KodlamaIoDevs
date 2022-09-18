using KodlamaIoDevs.Application.Features.UserApp.Dtos;
using MediatR;

namespace KodlamaIoDevs.Application.Features.UserApp.Commands.RegisterUserApp
{
    public class RegisterUserAppCommand: IRequest<TokenDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
