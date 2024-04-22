using Core.Models;
using Core.Models.Equipment;
using Core.Models.Ingredient;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public required DbSet<Brewer> Brewers { get; set; }
        public required DbSet<BrewerBrewingEquipment> BrewerBrewingEquipment { get; set; }
        public required DbSet<BrewingEquipment> BrewingEquipment { get; set; }
        public required DbSet<Brewing> Brewings { get; set; }
        public required DbSet<BrewingLog> BrewingLogs { get; set; }
        public required DbSet<BrewerIngredient> BrewerIngredients { get; set; }
        public required DbSet<Ingredient> Ingredients { get; set; }
        public required DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        public required DbSet<Recipe> Recipes { get; set; }
        public required DbSet<RecipeVote> RecipeVotes { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }
    }



}
