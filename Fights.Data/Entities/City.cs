using System.Collections.Generic;

namespace Fights.Data.Entities
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Fight> Fights { get; set; }
    }
}