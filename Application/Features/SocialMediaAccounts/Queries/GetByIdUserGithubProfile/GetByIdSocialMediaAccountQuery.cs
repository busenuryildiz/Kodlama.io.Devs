using Application.Features.SocialMediaAccounts.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SocialMediaAccounts.Queries.GetByIdSocialMediaAccount
{
    public class GetByIdSocialMediaAccountQuery : IRequest<SocialMediaAccountGetByIdDto>
    {
        public int Id { get; set; }

        public class GetByIdSocialMediaAccountQueryHandler : IRequestHandler<GetByIdSocialMediaAccountQuery, SocialMediaAccountGetByIdDto>
        {
            private readonly ISocialMediaAccountRepository _userGithubProfileRepository;
            private readonly IMapper _mapper;

            public GetByIdSocialMediaAccountQueryHandler(ISocialMediaAccountRepository userGithubProfileRepository, IMapper mapper)
            {
                _userGithubProfileRepository = userGithubProfileRepository;
                _mapper = mapper;
            }

            public async Task<SocialMediaAccountGetByIdDto> Handle(GetByIdSocialMediaAccountQuery request, CancellationToken cancellationToken)
            {

                SocialMediaAccount? userGithubProfile = await _userGithubProfileRepository.GetAsync(b => b.Id == request.Id);
                SocialMediaAccountGetByIdDto userGithubProfileGetByIdDto = _mapper.Map<SocialMediaAccountGetByIdDto>(userGithubProfile);
                return userGithubProfileGetByIdDto;
            }

        }

    }
}
