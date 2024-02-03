using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.SoftwareTechs.Dtos;
using Application.Features.SoftwareTechs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SoftwareTechs.Commands.CreateSoftwareTech
{
    public class CreateSoftwareTechCommand : IRequest<CreatedSoftwareTechDto>
    {
        public string Name { get; set; }
        public class CreatedSoftwareTechCommandHandler : IRequestHandler<CreateSoftwareTechCommand, CreatedSoftwareTechDto>
        {
            private readonly ISoftwareTechRepository _softwareTechRepository;
            private readonly IMapper _mapper;
            private readonly SoftwareTechBusinessRules _softwareTechBusinessRules;

            public CreatedSoftwareTechCommandHandler(ISoftwareTechRepository softwareTechRepository, IMapper mapper, SoftwareTechBusinessRules softwareTechBusinessRules)
            {
                _softwareTechRepository = softwareTechRepository;
                _mapper = mapper;
                _softwareTechBusinessRules = softwareTechBusinessRules;
            }

            public async Task<CreatedSoftwareTechDto> Handle(CreateSoftwareTechCommand request, CancellationToken cancellationToken)
            {
                await _softwareTechBusinessRules.SoftwareTechNameCanNotBeDuplicatedWhenInserted(request.Name);

                SoftwareTech mappedSoftwareTech = _mapper.Map<SoftwareTech>(request);
                SoftwareTech createdSoftwareTech = await _softwareTechRepository.AddAsync(mappedSoftwareTech);
                CreatedSoftwareTechDto createdSoftwareTechDto = _mapper.Map<CreatedSoftwareTechDto>(createdSoftwareTech);

                return createdSoftwareTechDto;
            }
        }

    }
}
