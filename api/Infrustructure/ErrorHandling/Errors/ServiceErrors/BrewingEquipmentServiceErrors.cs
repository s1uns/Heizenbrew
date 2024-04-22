using Infrustructure.ErrorHandling.Errors.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure.ErrorHandling.Errors.ServiceErrors
{
    public class BrewingEquipmentServiceErrors
    {
        public static Error CreateEquipmentError = new Error("Create Equipment Error", "Couldn't create this equipment.");
        public static Error GetEquipmentListError = new Error("Get Equipment List Error", "Couldn't get the list of available brewing equipment.");
        public static Error GetEquipmentByIdError = new Error("Get Equipment By Id Error", "Couldn't get information about this brewing equipment.");
        public static Error UpdateEquipmentError = new Error("Update Equipment Error", "Couldn't update information about this brewing equipment.");
        public static Error DeleteEquipmentError = new Error("Delete Equipment Error", "Couldn't delete this brewing equipment.");
        public static Error BuyEquipmentError = new Error("Buy Equipment Error", "Couldn't add this equipment to your profile.");
        public static Error NotYourEquipmentError = new Error("Not Your Equipment Error", "You are trying to access someone else's equipment information.");
        public static Error ChangeConnectionStringError = new Error("Change Connection String Error", "Couldn't change the connection string.");
    }
}
