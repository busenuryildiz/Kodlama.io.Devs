using Application.Features.Auths.Dtos;
using Core.Security.Dtos;
using MediatR;
using Application.Features.Auths.Rules;
using Application.Services.AuthService;
using Application.Services.Repositories;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using Application.Features.Auths.Constants;

namespace Application.Features.Auths.Commands.Login
{
    public class LoginCommand : IRequest<LoginedDto>
    {
        public UserForLoginDto UserForLoginDto { get; set; }
        public string IpAddress { get; set; }

        public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginedDto>
        {
            private readonly IAuthService _authService;
            private readonly IUserRepository _userRepository;

            public LoginCommandHandler(IAuthService authService, IUserRepository userRepository)
            {
                _authService = authService;
                _userRepository = userRepository;
            }
            public async Task<LoginedDto> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                User? user = await _userRepository.GetAsync(u => u.Email == request.UserForLoginDto.Email);
                if (!HashingHelper.VerifyPasswordHash(request.UserForLoginDto.Password, user.PasswordHash, user.PasswordSalt))
                {
                    throw new Exception("Invalid password");
                }

                AccessToken createdAccessToken = await _authService.CreateAccessToken(user);
                RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(user, request.IpAddress);
                RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

                LoginedDto loginedDto = new() { AccessToken = createdAccessToken, RefreshToken = addedRefreshToken, Message = AuthMessages.LoginSuccess };
                return loginedDto;
            }
        }
    }
}
