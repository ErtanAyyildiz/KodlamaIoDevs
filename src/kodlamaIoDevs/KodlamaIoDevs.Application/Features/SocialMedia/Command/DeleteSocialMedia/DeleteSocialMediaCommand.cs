using AutoMapper;
using KodlamaIoDevs.Application.Features.SocialMedia.Dtos;
using KodlamaIoDevs.Application.Features.SocialMedia.Rules;
using KodlamaIoDevs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.SocialMedia.Command.DeleteSocialMedia
{
    public class DeleteSocialMediaCommand:IRequest<DeletedSocialMediaDto>
    {
        public int Id { get; set; }

        public class DeleteSocialMediaCommandHandler : IRequestHandler<DeleteSocialMediaCommand, DeletedSocialMediaDto>
        {
            private readonly IMapper _mapper;
            private readonly ISocialMediaRepository _socialMediaRepository;
            private readonly SocialMediaBusinessRules _socialMediaBusinessRules;

            public DeleteSocialMediaCommandHandler(IMapper mapper, ISocialMediaRepository socialMediaRepository, SocialMediaBusinessRules socialMediaBusinessRules)
            {
                _mapper = mapper;
                _socialMediaRepository = socialMediaRepository;
                _socialMediaBusinessRules = socialMediaBusinessRules;
            }

            public async Task<DeletedSocialMediaDto> Handle(DeleteSocialMediaCommand request, CancellationToken cancellationToken)
            {
                var socialMediaEntity = await _socialMediaRepository.GetAsync(x => x.Id == request.Id);
                _socialMediaBusinessRules.SocialMediaShouldExistWhenDeleted(socialMediaEntity);

                socialMediaEntity =await _socialMediaRepository.DeleteAsync(socialMediaEntity);

                var deletedSocialMediaDto = _mapper.Map<DeletedSocialMediaDto>(socialMediaEntity);

                return deletedSocialMediaDto;
            }
        }
    }
}
