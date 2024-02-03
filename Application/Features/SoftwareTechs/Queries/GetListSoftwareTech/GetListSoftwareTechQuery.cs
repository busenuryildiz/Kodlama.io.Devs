using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.SoftwareTechs.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.SoftwareTechs.Queries.GetListSoftwareTech
{
    public class GetListSoftwareTechQuery : IRequest<SoftwareTechListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListSoftwareTechQueryHandler : IRequestHandler<GetListSoftwareTechQuery, SoftwareTechListModel>
        {
            private readonly ISoftwareTechRepository _softwareTechRepository;
            private readonly IMapper  _mapper;

            public GetListSoftwareTechQueryHandler(ISoftwareTechRepository softwareTechRepository, IMapper mapper)
            {
                _softwareTechRepository = softwareTechRepository;
                _mapper = mapper;
            }

            public async Task<SoftwareTechListModel> Handle(GetListSoftwareTechQuery request, CancellationToken cancellationToken)
            {
                IPaginate<SoftwareTech> softwareTechs = await _softwareTechRepository.GetListAsync(

                    include: a => a.Include(c => c.ProgrammingLanguage),
                    index: request.PageRequest.Page, size: request.PageRequest.PageSize);
                SoftwareTechListModel mappedSoftwareTechListModel = _mapper.Map <SoftwareTechListModel>(softwareTechs);

                return mappedSoftwareTechListModel;
            }
        }
    }
}
