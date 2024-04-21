﻿using Infrustructure.ErrorHandling.Exceptions.Extensions;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;


namespace Infrustructure.Extensions
{
    public static class HttpContextExtensions
    {
        public static bool TryGetUserId(this IHttpContextAccessor accessor, out Guid userId)
        {
            return accessor.HttpContext.TryGetUserId(out userId);
        }       
        
        public static bool TryGetUserId(this HttpContext? context, out Guid userId)
        {
            var identityName = context?.User?.Claims?.Single(c => c.Type == ClaimTypes.NameIdentifier).Value;

            if (!string.IsNullOrEmpty(identityName))
            {
                var isValid = Guid.TryParse(identityName, out Guid parsedUserId);

                if (isValid && parsedUserId == Guid.Empty)
                {
                    isValid = !isValid;
                }

                userId = parsedUserId;

                return isValid;
            }

            userId = Guid.Empty;

            return false;
        }

        public static bool TryGetUserEmail(this IHttpContextAccessor accessor, out string userEmail)
        {
            return accessor.HttpContext.TryGetUserEmail(out userEmail);
        }

        public static bool TryGetUserEmail(this HttpContext? context, out string userEmail)
        {
            var identityEmail = context?.User?.Claims?.Single(c => c.Type == ClaimTypes.Name).Value;

            if (!string.IsNullOrEmpty(identityEmail))
            {
                userEmail = identityEmail;
                return true;
            }

            throw new IdentityEmailNotFoundException("Couldn't get identity's email");
        }

        public static bool IsUserAuthenticated(this IHttpContextAccessor accessor)
        {
            return accessor.HttpContext.IsUserAuthenticated();
        }

        public static bool IsUserAuthenticated(this HttpContext? context)
        {
            return context.User.Identity.IsAuthenticated;
        }
    }
}
