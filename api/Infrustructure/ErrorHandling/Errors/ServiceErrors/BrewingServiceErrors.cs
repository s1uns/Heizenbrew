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
        public static Error CreateBrewingError = new Error("Create Brewing Error", "Couldn't create this equipment.");
        public static Error GetBrewingListError = new Error("Get Brewing List Error", "Couldn't get the list of available brewing equipment.");
        public static Error GetBrewingByIdError = new Error("Get Brewing By Id Error", "Couldn't get information about this brewing equipment.");
        public static Error UpdateBrewingError = new Error("Update Brewing Error", "Couldn't update information about this brewing equipment.");
        public static Error DeleteBrewingError = new Error("Delete Brewing Error", "Couldn't delete this brewing equipment.");
        public static Error BuyBrewingError = new Error("Buy Brewing Error", "Couldn't add this equipment to your profile.");
        public static Error NotYourBrewingError = new Error("Not Your Brewing Error", "You are trying to access someone else's equipment information.");
        public static Error ChangeConnectionStringError = new Error("Change Connection String Error", "Couldn't change the connection string.");
        public static Error GetBrewingStatusError = new Error("Get Brewing Status Error", "Couldn't get the equipment status.");
    }
}
