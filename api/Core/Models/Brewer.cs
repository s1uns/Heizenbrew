using Core.Models.Equipment;
using Core.Models.Ingredient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Brewer : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string ProfileColor { get; set; } = string.Empty;

        public ICollection<Recipe> Recipes { get; set; }
        public ICollection<BrewerBrewingEquipment> Equipment { get; set; }
        public ICollection<BrewerIngredient> Ingredients { get; set;}

    }
}
