using Infrustructure.ErrorHandling.Errors.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure.ErrorHandling.Errors.ServiceErrors
{
    public class BrewingServiceErrors
    {
        public static Error CreateBrewingError = new Error("Create Brewing Error", "Couldn't start this brewing.");
        public static Error GetBrewingListError = new Error("Get Brewing List Error", "Couldn't get the list of available brewing.");
        public static Error GetBrewingByIdError = new Error("Get Brewing By Id Error", "Couldn't get information about this brewing.");
        public static Error AbortBrewingError = new Error("Abort Brewing Error", "Couldn't abort this brewing.");
        public static Error DeleteBrewingError = new Error("Delete Brewing Error", "Couldn't delete this brewing.");
        public static Error BuyBrewingError = new Error("Buy Brewing Error", "Couldn't add this brewing to your profile.");
        public static Error NotYourBrewingError = new Error("Not Your Brewing Error", "You are trying to access someone else's brewing information.");
        public static Error GetBrewingStatusError = new Error("Get Brewing Status Error", "Couldn't get the brewing status.");
        public static Error EquipmentIsBusyError = new Error("Equipment Is Busy Error", "This equipment is busy.");
        public static Error NoBrewingsNowError = new Error("No Brewings Now Error", "This equipment has no brewings now.");
        public static Error NoBrewingsError = new Error("No Brewings Error", "This equipment has no brewings.");
        public static Error NoBrewingLogsError = new Error("No Brewing Logs Error", "This equipment has no logs now.");
        public static Error DontHaveIngredientError(string ingredientName) => new Error("Don't Have Ingredient Error", $"You don't have {ingredientName} to cook this recipe.");
        public static Error DontHaveEnoughIngredientError(string ingredientName) => new Error("Don't Have Enough Ingredient Error", $"You don't have enough {ingredientName} to cook this recipe.");
    }
}
