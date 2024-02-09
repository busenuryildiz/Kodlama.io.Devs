using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.SocialMediaAccounts.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.SocialMediaAccounts.Models
{
    public class SocialMediaAccountListModel : BasePageableModel
    {
        public IList<SocialMediaAccountListDto> Items { get; set; }
    }
}
