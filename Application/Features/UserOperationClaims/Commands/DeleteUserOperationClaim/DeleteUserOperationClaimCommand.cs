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

namespace Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim
{
    public class DeleteUserOperationClaimCommand : IRequest<DeletedUserOperationClaimDto>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
        public class DeleteUserOperationClaimCommandHandler : IRequestHandler<DeleteUserOperationClaimCommand, DeletedUserOperationClaimDto>
        {
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly IMapper _mapper;
            private readonly IUserRepository _userRepository;
            private readonly IOperationClaimRepository _operationClaimRepository;

            public DeleteUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper, IUserRepository userRepository, IOperationClaimRepository operationClaimRepository)
            {
                _userOperationClaimRepository = userOperationClaimRepository;
                _mapper = mapper;
                _userRepository = userRepository;
                _operationClaimRepository = operationClaimRepository;
            }
            public async Task<DeletedUserOperationClaimDto> Handle(DeleteUserOperationClaimCommand request, CancellationToken cancellationToken)
            {
                UserOperationClaim mappedUserOperationClaim = _mapper.Map<UserOperationClaim>(request);
                UserOperationClaim deletedUserOperationClaim =
                    await _userOperationClaimRepository.DeleteAsync(mappedUserOperationClaim);
                User? user = await _userRepository.GetAsync(u => u.Id == deletedUserOperationClaim.UserId);
                OperationClaim? operationClaim =
                    await _operationClaimRepository.GetAsync(o => o.Id == deletedUserOperationClaim.OperationClaimId);
                DeletedUserOperationClaimDto deletedUserOperationClaimDto = new()
                {
                    Id = deletedUserOperationClaim.Id,
                    OperationClaimName = operationClaim.Name,
                    UserName = user.FirstName
                };
                return deletedUserOperationClaimDto;
            }
        }
    }
}
