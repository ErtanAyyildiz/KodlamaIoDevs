using AutoMapper;
using KodlamaIoDevs.Application.Features.SocialMedia.Dtos;
using KodlamaIoDevs.Application.Features.SocialMedia.Rules;
using KodlamaIoDevs.Application.Services.Repositorties;
using MediatR;

namespace KodlamaIoDevs.Application.Features.SocialMedia.Commands.DeleteSocialMedia
{
    public class DeleteSocialMediaCommandHandler : IRequestHandler<DeleteSocialMediaCommand, DeletedSocialMediaDto>
    {
        private readonly IMapper _mapper;
        private readonly ISocialMediaRepository _socialMediaRepository;
        SocialMediaBussinessRules _socialMediaBussinessRules;

        public DeleteSocialMediaCommandHandler(IMapper mapper, ISocialMediaRepository socialMediaRepository, SocialMediaBussinessRules socialMediaBussinessRules)
        {
            _mapper = mapper;
            _socialMediaRepository = socialMediaRepository;
            _socialMediaBussinessRules = socialMediaBussinessRules;
        }

        public async Task<DeletedSocialMediaDto> Handle(DeleteSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var socialMediaEntity = await _socialMediaRepository.GetAsync(x => x.Id == request.Id);

            _socialMediaBussinessRules.SocialMediaShouldExistWhenDeleted(socialMediaEntity);

            socialMediaEntity = await _socialMediaRepository.DeleteAsync(socialMediaEntity);

            var updatedSocialMediaDto = _mapper.Map<DeletedSocialMediaDto>(socialMediaEntity);

            return updatedSocialMediaDto;
        }
    }
}
