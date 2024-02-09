using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SocialMediaAccount:Entity
    {
        public string Link { get; set; }
        public string Name { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }

        public SocialMediaAccount()
        {
        }

        public SocialMediaAccount(int id,string name, int userId, string link) : this()
        {
            Id = id;
            UserId = userId;
            Link = link;
            Name = name;
        }
    }
}
