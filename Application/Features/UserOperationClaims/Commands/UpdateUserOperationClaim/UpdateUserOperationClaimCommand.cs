using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application.Features.UserOperationClaims.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.UserOperationClaims.Commands.UpdateUserOperationClaim
{
    public class UpdateUserOperationClaimCommand : IRequest<UpdatedUserOperationClaimDto>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
        public class UpdateUserOperationClaimCommandHandler : IRequestHandler<UpdateUserOperationClaimCommand, UpdatedUserOperationClaimDto>
        {
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly IMapper _mapper;
            private readonly IUserRepository _userRepository;
            private readonly IOperationClaimRepository _operationClaimRepository;

            public UpdateUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper, IUserRepository userRepository, IOperationClaimRepository operationClaimRepository)
            {
                _userOperationClaimRepository = userOperationClaimRepository;
                _mapper = mapper;
                _userRepository = userRepository;
                _operationClaimRepository = operationClaimRepository;
            }
            public async Task<UpdatedUserOperationClaimDto> Handle(UpdateUserOperationClaimCommand request, CancellationToken cancellationToken)
            {
                UserOperationClaim mappedUserOperationClaim = _mapper.Map<UserOperationClaim>(request);
                UserOperationClaim updatedUserOperationClaim =
                    await _userOperationClaimRepository.UpdateAsync(mappedUserOperationClaim);
                User? user = await _userRepository.GetAsync(u => u.Id == updatedUserOperationClaim.UserId);
                OperationClaim? operationClaim =
                    await _operationClaimRepository.GetAsync(o => o.Id == updatedUserOperationClaim.OperationClaimId);
                UpdatedUserOperationClaimDto updatedUserOperationClaimDto = new()
                {
                    Id = updatedUserOperationClaim.Id,
                    OperationClaimName = operationClaim.Name,
                    UserName = user.FirstName
                };
                return updatedUserOperationClaimDto;
            }
        }

    }
}
