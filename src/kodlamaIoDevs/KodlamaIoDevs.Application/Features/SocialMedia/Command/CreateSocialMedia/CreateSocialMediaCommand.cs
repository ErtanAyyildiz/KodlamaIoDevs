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

namespace KodlamaIoDevs.Application.Features.SocialMedia.Command.CreateSocialMedia
{
    public class CreateSocialMediaCommand:IRequest<CreatedSocialMediaDto>
    {
        public int UserId { get; set; }
        public string Url { get; set; }

        public class CreateSocialMediaCommandHandler : IRequestHandler<CreateSocialMediaCommand, CreatedSocialMediaDto>
        {
            private readonly IMapper _mapper;
            private readonly ISocialMediaRepository _socialMediaRepository;
            private readonly SocialMediaBusinessRules _socialMediaBusinessRules;

            public CreateSocialMediaCommandHandler(IMapper mapper, ISocialMediaRepository socialMediaRepository, SocialMediaBusinessRules socialMediaBusinessRules)
            {
                _mapper = mapper;
                _socialMediaRepository = socialMediaRepository;
                _socialMediaBusinessRules = socialMediaBusinessRules;
            }

            public async Task<CreatedSocialMediaDto> Handle(CreateSocialMediaCommand request, CancellationToken cancellationToken)
            {
                var socialMediaEntity = _mapper.Map<Domain.Entities.SocialMedia>(request);
                await _socialMediaBusinessRules.SocialMediaCanNotBeDuplicatedWhenInserted(socialMediaEntity.UserId, socialMediaEntity.Url);

                var createdSocialMedia=await _socialMediaRepository.AddAsync(socialMediaEntity);

                var createdSocialMediaDto = _mapper.Map<CreatedSocialMediaDto>(createdSocialMedia);

                return createdSocialMediaDto;
            }
        }
    }
}
