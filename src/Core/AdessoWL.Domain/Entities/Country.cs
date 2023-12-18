using AdessoWL.Domain.Common;
using System.Collections.Generic;

namespace AdessoWL.Domain.Entities
{
    public class Country : BaseEntity
    {
        public Country()
        {
            Teams = new List<Team>();
        }
        public string Name { get; set; }

        //Navigation property
        //[DapperIgnore]
        public ICollection<Team> Teams { get; set; }
    }
}
