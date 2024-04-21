using Core;
using Infrustructure.ErrorHandling.Errors.Base;
using Infrustructure.ErrorHandling.Errors.ServiceErrors;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure.Extensions
{
    public static class PasswordValidatorsExtensions
    {
        public static async Task<Result<bool, Error>> ValidateAsync(this UserManager<IdentityUser> userManager, string newPassword)
        {
            var validators = userManager.PasswordValidators;


            foreach (var validator in validators)
            {
                var result = await validator.ValidateAsync(userManager, null, newPassword);

                if (!result.Succeeded)
                {
                    return IdentityServiceErrors.InvalidNewPasswordError(result.Errors.First().Description);
                }
            }

            return true;
        }
    }
}
