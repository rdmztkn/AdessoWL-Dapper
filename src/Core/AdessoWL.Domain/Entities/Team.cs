using AdessoWL.Domain.Common;

namespace AdessoWL.Domain.Entities
{
    public class Team : BaseEntity
    {
        public string Name { get; set; }

        //Foreign Key Property
        public int CountryId { get; set; }
    }
}
