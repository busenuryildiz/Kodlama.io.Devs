using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.CrossCuttingConcerns.Exceptions;

namespace Application.Features.SoftwareTechs.Rules
{
    public class SoftwareTechBusinessRules
    {
        private readonly ISoftwareTechRepository _softwareTechRepository;

        public SoftwareTechBusinessRules(ISoftwareTechRepository softwareTechRepository)
        {
            _softwareTechRepository = softwareTechRepository;
        }

        public async Task SoftwareTechNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<SoftwareTech> result = await _softwareTechRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException("Programming Language name exists.");
        }
        public void SoftwareTechShouldExistWhenRequested(SoftwareTech softwareTech)
        {
            if (softwareTech == null) throw new BusinessException("Requested Programming Language does not exist");
        }
    }
}
