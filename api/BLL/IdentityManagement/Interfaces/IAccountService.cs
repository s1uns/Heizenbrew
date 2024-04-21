
using Core;
using Infrustructure.Dto.Account;
using Infrustructure.ErrorHandling.Errors.Base;
using Microsoft.AspNetCore.Identity;


namespace BLL.IdentityManagement.Interfaces
{
    public interface IAccountService
    {
        public Task<Result<SignInResultDto, Error>> CreateBrewerAsync(CredentialsDto credentials);
        public Task<Result<SignInResultDto, Error>> SignInAsync(CredentialsDto credentials);
        public Task<Result<bool, Error>> ResetPasswordAsync(ResetPasswordDto resetPasswordDto);
    }
}
