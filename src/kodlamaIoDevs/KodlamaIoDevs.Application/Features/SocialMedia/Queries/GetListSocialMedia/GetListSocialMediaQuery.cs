using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using KodlamaIoDevs.Application.Features.SocialMedia.Dtos;
using KodlamaIoDevs.Application.Features.SocialMedia.Models;
using KodlamaIoDevs.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIoDevs.Application.Features.SocialMedia.Queries.GetListSocialMedia
{
    public class GetListSocialMediaQuery : IRequest<SocialMediaListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListSocialMediaQueryHandler : IRequestHandler<GetListSocialMediaQuery, SocialMediaListModel>
        {
            private readonly ISocialMediaRepository _socialMediaRepository;
            private readonly IMapper _mapper;

            public GetListSocialMediaQueryHandler(ISocialMediaRepository socialMediaRepository, IMapper mapper)
            {
                _socialMediaRepository = socialMediaRepository;
                _mapper = mapper;
            }

            public async Task<SocialMediaListModel> Handle(GetListSocialMediaQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Domain.Entities.SocialMedia> socialMediaEntity = await _socialMediaRepository.GetListAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize,
                    include: m => m.Include(m => m.User)
                    );

                var socialMediaListModel = _mapper.Map<SocialMediaListModel>(socialMediaEntity);

                return socialMediaListModel;
            }
        }
    }
}
