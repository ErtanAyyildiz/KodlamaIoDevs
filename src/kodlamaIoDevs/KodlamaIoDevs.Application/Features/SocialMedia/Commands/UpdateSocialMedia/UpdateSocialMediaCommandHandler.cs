using AutoMapper;
using KodlamaIoDevs.Application.Features.SocialMedia.Dtos;
using KodlamaIoDevs.Application.Features.SocialMedia.Rules;
using KodlamaIoDevs.Application.Services.Repositorties;
using MediatR;

namespace KodlamaIoDevs.Application.Features.SocialMedia.Commands.UpdateSocialMedia
{
    public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommand, UpdatedSocialMediaDto>
    {
        private readonly IMapper _mapper;
        private readonly ISocialMediaRepository _socialMediaRepository;
        SocialMediaBussinessRules _socialMediaBussinessRules;

        public UpdateSocialMediaCommandHandler(IMapper mapper, ISocialMediaRepository socialMediaRepository, SocialMediaBussinessRules socialMediaBussinessRules)
        {
            _mapper = mapper;
            _socialMediaRepository = socialMediaRepository;
            _socialMediaBussinessRules = socialMediaBussinessRules;
        }

        public async Task<UpdatedSocialMediaDto> Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            //_socialMediaBussinessRules.SocialMediaCanNotBeDuplicatedWhenInserted(request.UserId, request.Url);

            var socialMediaEntity = _mapper.Map<Domain.Entities.SocialMedia>(request);
            _socialMediaBussinessRules.SocialMediaShouldExistWhenUpdated(socialMediaEntity);


            socialMediaEntity = _socialMediaRepository.Update(socialMediaEntity);

            var updatedSocialMediaDto = _mapper.Map<UpdatedSocialMediaDto>(socialMediaEntity);

            return updatedSocialMediaDto;
        }
    }
}
