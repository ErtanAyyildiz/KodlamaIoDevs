using KodlamaIoDevs.Application.Features.UserApp.Dtos;
using MediatR;

namespace KodlamaIoDevs.Application.Features.UserApp.Commands.LoginUserApp
{
    public class LoginUserAppCommand: IRequest<TokenDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
