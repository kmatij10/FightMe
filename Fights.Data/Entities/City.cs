using System.Collections.Generic;

namespace Fights.Data.Entities
{
    public class City : BaseEntity
    {
        public string CityName { get; set; }

        public ICollection<Protest> Protests { get; set; }
    }
}