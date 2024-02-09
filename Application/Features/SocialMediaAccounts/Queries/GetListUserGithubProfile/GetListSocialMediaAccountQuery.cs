using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.SocialMediaAccounts.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.SocialMediaAccounts.Queries.GetListSocialMediaAccount
{
    public class GetListSocialMediaAccountQuery : IRequest<SocialMediaAccountListModel>,ISecuredRequest
    {
        public PageRequest PageRequest { get; set; }
        public string[] Roles { get; } = new string[] { "Admin" };

        public class GetListSocialMediaAccountQueryHandler : IRequestHandler<GetListSocialMediaAccountQuery, SocialMediaAccountListModel>
        {
            private readonly ISocialMediaAccountRepository _userGithubProfileRepository;
            private readonly IMapper  _mapper;

            public GetListSocialMediaAccountQueryHandler(ISocialMediaAccountRepository userGithubProfileRepository, IMapper mapper)
            {
                _userGithubProfileRepository = userGithubProfileRepository;
                _mapper = mapper;
            }

            public async Task<SocialMediaAccountListModel> Handle(GetListSocialMediaAccountQuery request, CancellationToken cancellationToken)
            {
                IPaginate<SocialMediaAccount> userGithubProfiles = await _userGithubProfileRepository.GetListAsync(
                    include: s => s.Include(x => x.User),
                    index: request.PageRequest.Page, size: request.PageRequest.PageSize);
                SocialMediaAccountListModel mappedSocialMediaAccountListModel = _mapper.Map <SocialMediaAccountListModel>(userGithubProfiles);

                return mappedSocialMediaAccountListModel;
            }
        }
    }
}
