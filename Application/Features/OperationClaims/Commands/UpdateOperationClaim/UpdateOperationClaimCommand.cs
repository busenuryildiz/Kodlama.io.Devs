﻿using Application.Features.OperationClaims.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperaionClaims.Commands.UpdateOperationClaim
{
    public class UpdateOperationClaimCommand : IRequest<UpdatedOperationClaimDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public class UpdateOperationClaimCommandHandler : IRequestHandler<UpdateOperationClaimCommand, UpdatedOperationClaimDto>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly IMapper _mapper;

            public UpdateOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
            {
                _operationClaimRepository = operationClaimRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedOperationClaimDto> Handle(UpdateOperationClaimCommand request, CancellationToken cancellationToken)
            {
                OperationClaim mappedOperationClaim = _mapper.Map<OperationClaim>(request);
                OperationClaim updatedOperationClaim = await _operationClaimRepository.UpdateAsync(mappedOperationClaim);
                UpdatedOperationClaimDto updatedOperationClaimDto = _mapper.Map<UpdatedOperationClaimDto>(updatedOperationClaim);
                return updatedOperationClaimDto;

            }
        }
    }
}
