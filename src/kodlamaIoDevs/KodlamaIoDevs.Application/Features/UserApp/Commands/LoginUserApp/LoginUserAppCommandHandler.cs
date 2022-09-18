using AutoMapper;
using Core.Security.Entities;
using Core.Security.JWT;
using KodlamaIoDevs.Application.Features.UserApp.Dtos;
using KodlamaIoDevs.Application.Features.UserApp.Rules;
using KodlamaIoDevs.Application.Services.Repositorties;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KodlamaIoDevs.Application.Features.UserApp.Commands.LoginUserApp
{
    public class LoginUserAppCommandHandler : IRequestHandler<LoginUserAppCommand, TokenDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ITokenHelper _tokenHelper;
        private readonly UserAppBusinessRules _userAppBusinessRules;

        public LoginUserAppCommandHandler(IUserRepository userRepository, IMapper mapper, ITokenHelper tokenHelper, UserAppBusinessRules userAppBusinessRules)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _tokenHelper = tokenHelper;
            _userAppBusinessRules = userAppBusinessRules;
        }

        public async Task<TokenDto> Handle(LoginUserAppCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(
                u => u.Email.ToLower() == request.Email.ToLower(), 
                m => m.Include(c => c.UserOperationClaims).ThenInclude(x => x.OperationClaim)
            );

            _userAppBusinessRules.UserShouldExist(user);

            List<OperationClaim> operationClaims = new();
            foreach (var userOperationClaim in user.UserOperationClaims)
            {
                operationClaims.Add(userOperationClaim.OperationClaim);
            }

            _userAppBusinessRules.UserCredentialsShouldMatch(request.Password, user.PasswordHash, user.PasswordSalt);

            AccessToken token = _tokenHelper.CreateToken(user, operationClaims);

            TokenDto tokenDto = _mapper.Map<TokenDto>(token);

            return tokenDto;
        }
    }
}
