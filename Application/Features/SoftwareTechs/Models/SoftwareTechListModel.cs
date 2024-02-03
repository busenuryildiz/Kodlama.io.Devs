using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.SoftwareTechs.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.SoftwareTechs.Models
{
    public class SoftwareTechListModel : BasePageableModel
    {
        public IList<SoftwareTechListDto> Items { get; set; }
    }
}
