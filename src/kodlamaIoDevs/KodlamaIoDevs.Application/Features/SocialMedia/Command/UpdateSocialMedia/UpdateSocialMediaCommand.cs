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

namespace KodlamaIoDevs.Application.Features.SocialMedia.Command.UpdateSocialMedia
{
    public class UpdateSocialMediaCommand : IRequest<UpdatedSocialMediaDto>
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int UserId { get; set; }

        public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommand, UpdatedSocialMediaDto>
        {
            private readonly IMapper _mapper;
            private readonly ISocialMediaRepository _socialMediaRepository;
            SocialMediaBusinessRules _socialMediaBussinessRules;

            public UpdateSocialMediaCommandHandler(IMapper mapper, ISocialMediaRepository socialMediaRepository, SocialMediaBusinessRules socialMediaBussinessRules)
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
}
