using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SoftwareTech:Entity
    {
        public string Name { get; set; }
        public int? ProgrammingLanguageId { get; set; }
        public virtual ProgrammingLanguage ProgrammingLanguage { get; set; }

        public SoftwareTech()
        {
        }

        public SoftwareTech(int id,int prLanguageId, string name) : this()
        {
            Id = id;
            ProgrammingLanguageId = prLanguageId;
            Name = name;
        }
    }
}
