using Infrustructure.ErrorHandling.Errors.Base;

namespace Infrustructure.ErrorHandling.Errors.ServiceErrors
{
    public static class ProfileServiceErrors
    {
        public static Error UserNotFoundError = new Error("User Not Found Error", "The user is not found");
        public static Error GetBrewerProfileError = new Error("Get Brewer's Profile Error", "Couldn't get the brewer's profile");
        public static Error GetOwnProfileError = new Error("Get Own Profile Error", "Couldn't get your profile");
        public static Error UpdateProfileError = new Error("Update Profile Error", "Couldn't update your profile");
    }
}
