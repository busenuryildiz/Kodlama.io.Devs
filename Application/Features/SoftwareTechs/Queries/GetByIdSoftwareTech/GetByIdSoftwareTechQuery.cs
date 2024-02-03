using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Application.Features.SoftwareTechs.Dtos;
using Application.Features.SoftwareTechs.Models;
using Application.Features.SoftwareTechs.Queries.GetListSoftwareTech;
using Application.Features.SoftwareTechs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.SoftwareTechs.Queries.GetByIdSoftwareTech
{
    public class GetByIdSoftwareTechQuery : IRequest<SoftwareTechGetByIdDto>
    {
        public int Id { get; set; }

        public class GetByIdSoftwareTechQueryHandler : IRequestHandler<GetByIdSoftwareTechQuery, SoftwareTechGetByIdDto>
        {
            private readonly ISoftwareTechRepository _softwareTechRepository;
            private readonly IMapper _mapper;
            private readonly SoftwareTechBusinessRules _softwareTechBusinessRules;

            public GetByIdSoftwareTechQueryHandler(ISoftwareTechRepository softwareTechRepository, IMapper mapper, SoftwareTechBusinessRules softwareTechBusinessRules)
            {
                _softwareTechRepository = softwareTechRepository;
                _mapper = mapper;
                _softwareTechBusinessRules = softwareTechBusinessRules;
            }

            public async Task<SoftwareTechGetByIdDto> Handle(GetByIdSoftwareTechQuery request, CancellationToken cancellationToken)
            {

                SoftwareTech? softwareTech = await _softwareTechRepository.GetAsync(b => b.Id == request.Id);
                _softwareTechBusinessRules.SoftwareTechShouldExistWhenRequested(softwareTech);
                SoftwareTechGetByIdDto softwareTechGetByIdDto = _mapper.Map<SoftwareTechGetByIdDto>(softwareTech);
                return softwareTechGetByIdDto;
            }

        }

    }
}
