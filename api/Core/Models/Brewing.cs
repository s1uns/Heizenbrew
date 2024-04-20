using Core.Models.Equipment;
using System;
namespace Core.Models
{
    public class Brewing : BaseEntity
    {
        public BrewerBrewingEquipment BrewerBrewingEquipment { get; set; }
        public ICollection<BrewingLog> BrewingLogs { get; set; }
        public Status Status { get; set; }

    }
}

