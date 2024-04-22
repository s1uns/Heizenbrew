using BLL.IdentityManagement.Interfaces;
using Core;
using Infrustructure.Dto.Account;
using Infrustructure.ErrorHandling.Errors.Base;
using Microsoft.AspNetCore.Identity;
using Infrustructure.ErrorHandling.Errors.ServiceErrors;
using Microsoft.Extensions.Logging;
using Core.Models;
using Infrustructure.ErrorHandling.Exceptions.Services.Account;
using Microsoft.AspNetCore.Http;
using Infrustructure.Extensions;
using DAL;

namespace BLL.IdentityManagement
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ITokenGenerator _tokenGenerator;
        private readonly ApplicationDbContext _context;
        private readonly ILogger<AccountService> _logger;
        private readonly IHttpContextAccessor _contextAccessor;


        public AccountService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ITokenGenerator tokenGenerator, ApplicationDbContext context, ILogger<AccountService> logger, IHttpContextAccessor contextAccessor)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _tokenGenerator = tokenGenerator;
            _context = context;
            _logger = logger;
            _contextAccessor = contextAccessor;
        }

        public async Task<Result<SignInResultDto, Error>> CreateBrewerAsync(CredentialsDto credentials)
        {
            try
            {
                var identityUser = new IdentityUser
                {
                    Email = credentials.Email,
                    UserName = credentials.Email
                };

                var createIdentity = await _userManager.CreateAsync(identityUser, credentials.Password);

                if (createIdentity.Succeeded is false)
                {
                    return IdentityServiceErrors.CreateAccountError(createIdentity.Errors.Select(e => e.Description).FirstOrDefault());
                }

                await AssureRoleCreatedAsync(Roles.Brewer.ToString());
                await _userManager.AddToRoleAsync(identityUser, Roles.Brewer.ToString());

                var brewer = new Brewer
                {

                    Id = Guid.Parse(identityUser.Id),
                    Email = credentials.Email,
                    CreatedAt = DateTime.UtcNow,
                    ProfileColor = "000000"
                };

                await _context.Brewers.AddAsync(brewer);
                await _context.SaveChangesAsync();

                var token = await _tokenGenerator.GenerateAsync(identityUser);

                return new SignInResultDto
                {
                    UserId = brewer.Id,
                    Bearer = token
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"BLL.CreateBrewerAsync ERROR: {ex.Message}");

                return IdentityServiceErrors.CreateAccountError("something went wrong.");
            }

        }

        public async Task<Result<SignInResultDto, Error>> SignInAsync(CredentialsDto credentials)
        {
            try
            {
                var identityUser = await _userManager.FindByEmailAsync(credentials.Email);

                if (identityUser is null)
                {
                    throw new SignInExceiption("Wrong email");
                }

                var isCredentialsValid = await _userManager.CheckPasswordAsync(identityUser, credentials.Password);

                if (!isCredentialsValid)
                {
                    throw new SignInExceiption("Wrong password");
                }

                var token = await _tokenGenerator.GenerateAsync(identityUser);
                var result = new SignInResultDto()
                {
                    UserId = Guid.Parse(identityUser.Id),
                    Bearer = token,
                };
                return result;
            }
            catch (SignInExceiption ex)
            {
                _logger.LogError($"BLL.SignInAsync ERROR: {ex.Message}");

                return IdentityServiceErrors.SignInError(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"BLL.SignInAsync ERROR: {ex.Message}");

                return IdentityServiceErrors.SignInError("something went wrong.");
            }
        }

        public async Task<Result<bool, Error>> ResetPasswordAsync(ResetPasswordDto resetPasswordDto)
        {
            try
            {
                var vaildUserEmail = _contextAccessor.TryGetUserEmail(out string userEmail);
                if (vaildUserEmail is false)
                {
                    throw new InvalidUserException("wrong user");
                }

                var identityUser = await _userManager.FindByEmailAsync(userEmail);
                var isCredentialsValid = await _userManager.CheckPasswordAsync(identityUser, resetPasswordDto.OldPassword);

                if (!isCredentialsValid)
                {
                    throw new WrongOldPasswordException("wrong old password");
                }

                if (isCredentialsValid)
                {
                    var isNewPasswordValid = await _userManager.ValidateAsync(resetPasswordDto.NewPassword);

                    if (!isNewPasswordValid._isSuccess)
                    {
                        return IdentityServiceErrors.ResetPasswordError(isNewPasswordValid._error.Message);
                    }

                    await _userManager.RemovePasswordAsync(identityUser);
                    await _userManager.AddPasswordAsync(identityUser, resetPasswordDto.NewPassword);
                }

                return true;
            }
            catch (WrongOldPasswordException ex)
            {
                _logger.LogError($"BLL.ResetPasswordAsync Reset Password ERROR: {ex.Message}");
                return IdentityServiceErrors.ResetPasswordError(ex.Message);
            }
            catch (InvalidUserException ex)
            {
                _logger.LogError($"BLL.ResetPasswordAsync Invalid User ERROR: {ex.Message}");
                return IdentityServiceErrors.ResetPasswordError(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"BLL.ResetPasswordAsync ERROR: {ex.Message}");
                return IdentityServiceErrors.ResetPasswordError("something went wrong");

            }
        }

        private async Task AssureRoleCreatedAsync(string role)
        {
            if (await _roleManager.RoleExistsAsync(role))
            {
                return;
            }

            await _roleManager.CreateAsync(new IdentityRole(role));
        }


    }
}