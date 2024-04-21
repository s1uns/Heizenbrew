


using BLL.IdentityManagement.Interfaces;
using BLL.Services.IdentityManagement;

namespace heisenbrew_api.BuildExtensions
{
    internal static class ServicesInjection
    {
        internal static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenGenerator, JwtTokenGenerator>();
            services.AddScoped<IAccountService, AccountService>();
/*            services.AddScoped<IProfileService, ProfileService>();
*/
        }
    }
}
