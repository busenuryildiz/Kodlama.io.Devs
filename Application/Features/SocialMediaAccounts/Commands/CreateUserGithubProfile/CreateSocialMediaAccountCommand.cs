using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.SocialMediaAccounts.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SocialMediaAccounts.Commands.CreateSocialMediaAccount
{
    public class CreateSocialMediaAccountCommand : IRequest<CreatedSocialMediaAccountDto>
    {
        public string Link { get; set; }
        public string Name { get; set; }
        public int? UserId { get; set; }
        public class CreatedSocialMediaAccountCommandHandler : IRequestHandler<CreateSocialMediaAccountCommand, CreatedSocialMediaAccountDto>
        {
            private readonly ISocialMediaAccountRepository _userGithubProfileRepository;
            private readonly IMapper _mapper;

            public CreatedSocialMediaAccountCommandHandler(ISocialMediaAccountRepository userGithubProfileRepository, IMapper mapper)
            {
                _userGithubProfileRepository = userGithubProfileRepository;
                _mapper = mapper;
            }

            public async Task<CreatedSocialMediaAccountDto> Handle(CreateSocialMediaAccountCommand request, CancellationToken cancellationToken)
            {

                SocialMediaAccount mappedSocialMediaAccount = _mapper.Map<SocialMediaAccount>(request);
                SocialMediaAccount createdSocialMediaAccount = await _userGithubProfileRepository.AddAsync(mappedSocialMediaAccount);
                CreatedSocialMediaAccountDto createdSocialMediaAccountDto = _mapper.Map<CreatedSocialMediaAccountDto>(createdSocialMediaAccount);

                return createdSocialMediaAccountDto;
            }
        }

    }
}
