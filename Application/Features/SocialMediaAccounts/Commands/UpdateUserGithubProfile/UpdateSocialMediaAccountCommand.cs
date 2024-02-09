using Application.Features.SocialMediaAccounts.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Application.Features.SocialMediaAccounts.Commands.CreateSocialMediaAccount;

namespace Application.Features.SocialMediaAccounts.Commands.UpdateSocialMediaAccount
{
    public class UpdateSocialMediaAccountCommand : IRequest<UpdatedSocialMediaAccountDto>
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public string Name { get; set; }
        public int? UserId { get; set; }


        public class UpdateSocialMediaAccountCommandHandler : IRequestHandler<UpdateSocialMediaAccountCommand, UpdatedSocialMediaAccountDto>
        {
            private readonly ISocialMediaAccountRepository _userGithubProfileRepository;
            private readonly IMapper _mapper;

            public UpdateSocialMediaAccountCommandHandler(ISocialMediaAccountRepository userGithubProfileRepository, IMapper mapper)
            {
                _userGithubProfileRepository = userGithubProfileRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedSocialMediaAccountDto> Handle(UpdateSocialMediaAccountCommand request, CancellationToken cancellationToken)
            {
                SocialMediaAccount? userGithubProfile = await _userGithubProfileRepository.GetAsync(predicate: u => u.Id == request.Id);
                if (userGithubProfile != null)
                {
                    userGithubProfile.Name = request.Name;
                    await _userGithubProfileRepository.UpdateAsync(userGithubProfile);
                }
                UpdatedSocialMediaAccountDto response = _mapper.Map<UpdatedSocialMediaAccountDto>(userGithubProfile);
                return response;
            }
        }
    }
}
