using Infrustructure.ErrorHandling.Errors.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure.ErrorHandling.Errors.ServiceErrors
{
    public class IngredientServiceErrors
    {
        public static Error CreateIngredientError = new Error("Create Ingredient Error", "Couldn't create this ingredient.");
        public static Error GetIngredientsListError = new Error("Get Ingredient List Error", "Couldn't get the list of available ingredient.");
        public static Error GetIngredientByIdError = new Error("Get Ingredient By Id Error", "Couldn't get information about this ingredient.");
        public static Error UpdateIngredientError = new Error("Update Ingredient Error", "Couldn't update information about this ingredient.");
        public static Error DeleteIngredientError = new Error("Delete Ingredient Error", "Couldn't delete this ingredient.");
        public static Error BuyIngredientError = new Error("Buy Ingredient Error", "Couldn't add this ingredient to your profile.");

    }
}
