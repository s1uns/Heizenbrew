using Infrustructure.ErrorHandling.Errors.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure.ErrorHandling.Errors.ServiceErrors
{
    public class RecipeServiceErrors
    {
        public static Error CreateRecipeError = new Error("Create Recipe Error", "Couldn't create this recipe.");
        public static Error GetRecipeListError = new Error("Get Recipe List Error", "Couldn't get the list of available brewing recipe.");
        public static Error GetRecipeByIdError = new Error("Get Recipe By Id Error", "Couldn't get information about this brewing recipe.");
        public static Error UpdateRecipeError = new Error("Update Recipe Error", "Couldn't update information about this brewing recipe.");
        public static Error DeleteRecipeError = new Error("Delete Recipe Error", "Couldn't delete this brewing recipe.");
        public static Error BuyRecipeError = new Error("Buy Recipe Error", "Couldn't add this recipe to your profile.");
        public static Error NotYourRecipeError = new Error("Not Your Recipe Error", "You are trying to access someone else's recipe information.");
    }
}
