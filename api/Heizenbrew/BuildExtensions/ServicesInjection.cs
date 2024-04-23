


using BLL.IdentityManagement.Interfaces;
using BLL.ProfileManagement;
using BLL.IdentityManagement;
using BLL.ProfileManagement.Interface;
using BLL.EquipmentManagement;
using BLL.IngredientManagement;

namespace heisenbrew_api.BuildExtensions
{
    internal static class ServicesInjection
    {
        internal static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenGenerator, JwtTokenGenerator>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IEquipmentService, EquipmentService>();
            services.AddScoped<IIngredientService, IngredientService>();

        }
    }
}
