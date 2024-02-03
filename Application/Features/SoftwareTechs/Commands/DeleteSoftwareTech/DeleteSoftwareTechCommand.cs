using Application.Features.SoftwareTechs.Dtos;
using AutoMapper;
using Core.Security.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.SoftwareTechs.Rules;
using Application.Services.Repositories;
using Domain.Entities;

namespace Application.Features.SoftwareTechs.Commands.DeleteSoftwareTech
{
    public class DeleteSoftwareTechCommand : IRequest<DeletedSoftwareTechDto>
    {
        public int Id { get; set; }
        public class DeleteSoftwareTechCommandHandler : IRequestHandler<DeleteSoftwareTechCommand, DeletedSoftwareTechDto>
        {
            private readonly ISoftwareTechRepository _softwareTechRepository;
            private readonly IMapper _mapper;
            private readonly SoftwareTechBusinessRules _softwareTechBusinessRules;

            public DeleteSoftwareTechCommandHandler(ISoftwareTechRepository softwareTechRepository, IMapper mapper, SoftwareTechBusinessRules softwareTechBusinessRules)
            {
                _softwareTechRepository = softwareTechRepository;
                _mapper = mapper;
                _softwareTechBusinessRules = softwareTechBusinessRules;
            }

            public async Task<DeletedSoftwareTechDto> Handle(DeleteSoftwareTechCommand request, CancellationToken cancellationToken)
            {
                SoftwareTech? softwareTech = await _softwareTechRepository.GetAsync(predicate: u => u.Id == request.Id);
                await _softwareTechRepository.DeleteAsync(softwareTech!);
                DeletedSoftwareTechDto response = _mapper.Map<DeletedSoftwareTechDto>(softwareTech);
                return response;
            }
        }
    }
}
