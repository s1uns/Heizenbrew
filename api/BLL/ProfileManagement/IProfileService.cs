using Core;
using Infrustructure.Dto.UserProfile;
using Infrustructure.ErrorHandling.Errors.Base;


namespace BLL.ProfileManagement.Interface
{
    public interface IProfileService
    {
        public Task<Result<BrewerProfileDto, Error>> GetBrewerProfileAsync(Guid brewerId);
        public Task<Result<BrewerProfileDto, Error>> GetOwnBrewerProfileAsync();
        public Task<Result<BrewerProfileDto, Error>> UpdateBrewerProfileAsync(UpdateBrewerProfileDto updateBrewerProfileDto);
    }
}
