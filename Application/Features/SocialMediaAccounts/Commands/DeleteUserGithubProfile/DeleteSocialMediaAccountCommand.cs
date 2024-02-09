using Application.Features.SocialMediaAccounts.Dtos;
using AutoMapper;
using Core.Security.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.Repositories;
using Domain.Entities;

namespace Application.Features.SocialMediaAccounts.Commands.DeleteSocialMediaAccount
{
    public class DeleteSocialMediaAccountCommand : IRequest<DeletedSocialMediaAccountDto>
    {
        public int Id { get; set; }
        public class DeleteSocialMediaAccountCommandHandler : IRequestHandler<DeleteSocialMediaAccountCommand, DeletedSocialMediaAccountDto>
        {
            private readonly ISocialMediaAccountRepository _userGithubProfileRepository;
            private readonly IMapper _mapper;

            public DeleteSocialMediaAccountCommandHandler(ISocialMediaAccountRepository userGithubProfileRepository, IMapper mapper)
            {
                _userGithubProfileRepository = userGithubProfileRepository;
                _mapper = mapper;
            }

            public async Task<DeletedSocialMediaAccountDto> Handle(DeleteSocialMediaAccountCommand request, CancellationToken cancellationToken)
            {
                SocialMediaAccount? userGithubProfile = await _userGithubProfileRepository.GetAsync(predicate: u => u.Id == request.Id);
                await _userGithubProfileRepository.DeleteAsync(userGithubProfile!);
                DeletedSocialMediaAccountDto response = _mapper.Map<DeletedSocialMediaAccountDto>(userGithubProfile);
                return response;
            }
        }
    }
}
