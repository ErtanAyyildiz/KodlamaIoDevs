using AutoMapper;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using KodlamaIoDevs.Application.Features.UserApp.Dtos;
using KodlamaIoDevs.Application.Services.Repositorties;
using MediatR;

namespace KodlamaIoDevs.Application.Features.UserApp.Commands.RegisterUserApp
{
    public class RegisterUserAppCommandHandler : IRequestHandler<RegisterUserAppCommand, TokenDto>
    {
        private readonly IUserRepository _userAppRepository;
        private readonly IMapper _mapper;
        private readonly ITokenHelper _tokenHelper;

        public RegisterUserAppCommandHandler(IUserRepository userAppRepository, IMapper mapper, ITokenHelper tokenHelper)
        {
            _userAppRepository = userAppRepository;
            _mapper = mapper;
            _tokenHelper = tokenHelper;
        }

        public async Task<TokenDto> Handle(RegisterUserAppCommand request, CancellationToken cancellationToken)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);

            var userAppEntity = _mapper.Map<User>(request);
            userAppEntity.PasswordHash = passwordHash;
            userAppEntity.PasswordSalt = passwordSalt;
            //(userAppEntity.PasswordHash, userAppEntity.PasswordSalt) = (passwordHash, passwordSalt);

            var createdUserApp = await _userAppRepository.AddAsync(userAppEntity);

            AccessToken token = _tokenHelper.CreateToken(createdUserApp, new List<OperationClaim>());
            
            TokenDto tokenDto = _mapper.Map<TokenDto>(token);

            return tokenDto;
        }
    }
}
