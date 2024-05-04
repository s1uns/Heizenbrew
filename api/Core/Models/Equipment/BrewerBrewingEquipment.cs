using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Equipment
{
    public class BrewerBrewingEquipment : BaseEntity
    {
        public Guid BrewerId { get; set; }
        public Brewer Brewer { get; set; }
        public BrewingEquipment BrewingEquipment { get; set; }
        public string ConnectionString { get; set; } = string.Empty;
        public ICollection<Brewing> Brewings { get; set; }
        public bool IsBrewing { get; set; }

    }
}
