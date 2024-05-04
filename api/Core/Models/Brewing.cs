using Core.Models.Equipment;
using System;
namespace Core.Models
{
    public class Brewing : BaseEntity
    {
        public Guid BrewerBrewingEquipmentId { get; set; }
        public BrewerBrewingEquipment BrewerBrewingEquipment { get; set; }
        public Guid RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public ICollection<BrewingLog> BrewingLogs { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}

