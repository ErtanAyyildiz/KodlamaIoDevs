using AutoMapper;
using KodlamaIoDevs.Application.Features.SocialMedia.Dtos;
using KodlamaIoDevs.Application.Features.SocialMedia.Rules;
using KodlamaIoDevs.Application.Services.Repositorties;
using MediatR;

namespace KodlamaIoDevs.Application.Features.SocialMedia.Commands.CreateSocialMedia
{
    public class CreateSocialMediaCommandHandler : IRequestHandler<CreateSocialMediaCommand, CreatedSocialMediaDto>
    {
        private readonly IMapper _mapper;
        private readonly ISocialMediaRepository _socialMediaRepository;
        SocialMediaBussinessRules _socialMediaBussinessRules;

        public CreateSocialMediaCommandHandler(IMapper mapper, ISocialMediaRepository socialMediaRepository, SocialMediaBussinessRules socialMediaBussinessRules)
        {
            _mapper = mapper;
            _socialMediaRepository = socialMediaRepository;
            _socialMediaBussinessRules = socialMediaBussinessRules;
        }

        public async Task<CreatedSocialMediaDto> Handle(CreateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var socialMediaEntity = _mapper.Map<Domain.Entities.SocialMedia>(request);
            await _socialMediaBussinessRules.SocialMediaCanNotBeDuplicatedWhenInserted(socialMediaEntity.UserId, socialMediaEntity.Url);

            var createdSocialMedia = await _socialMediaRepository.AddAsync(socialMediaEntity);

            var createdSocialMediaDto = _mapper.Map<CreatedSocialMediaDto>(createdSocialMedia);

            return createdSocialMediaDto;
        }
    }
}
