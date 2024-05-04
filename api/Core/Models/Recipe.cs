using Core.Models.Ingredient;

namespace Core.Models
{
    public class Recipe : BaseEntity
    {
        public Guid BrewerId { get; set; }
        public Brewer Brewer { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<RecipeIngredient> Ingredients { get; set; }
        public ICollection<RecipeVote> Votes { get; set; }
        public ICollection<Brewing> Brewings { get; set; }
    }
}
