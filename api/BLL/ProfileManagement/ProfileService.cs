using AutoMapper;
using Core;
using DAL;
using Infrustructure.Dto.UserProfile;
using Infrustructure.ErrorHandling.Errors.Base;
using Infrustructure.ErrorHandling.Errors.ServiceErrors;
using Infrustructure.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using BLL.ProfileManagement.Interface;

namespace BLL.ProfileManagement
{
    public class ProfileService : IProfileService
    {
        private readonly ILogger<ProfileService> _logger;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;


        public ProfileService(ILogger<ProfileService> logger, IMapper mapper, ApplicationDbContext context, IHttpContextAccessor contextAccessor)
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
            _contextAccessor = contextAccessor;
        }

        public async Task<Result<BrewerProfileDto, Error>> GetBrewerProfileAsync(Guid brewerId)
        {
            try
            {
                var brewer = await _context
                    .Brewers
                    .FirstOrDefaultAsync(x => x.Id == brewerId);

                if (brewer is null)
                {
                    return ProfileServiceErrors.UserNotFoundError;
                }

                return _mapper.Map<BrewerProfileDto>(brewer);
            }
            catch (Exception ex)
            {
                _logger.LogError($"BLL.GetBrewerProfileAsync ERROR: {ex.Message}");

                return ProfileServiceErrors.GetBrewerProfileError;
            }
        }

        public async Task<Result<BrewerProfileDto, Error>> GetOwnBrewerProfileAsync()
        {
            try
            {
                var isIdValid = _contextAccessor.TryGetUserId(out Guid userId);

                if (isIdValid is false)
                {
                    return UserErrors.InvalidUserId;
                }

                var brewer = await _context
                    .Brewers
                    .FirstOrDefaultAsync(x => x.Id == userId);

                if (brewer is null)
                {
                    return ProfileServiceErrors.UserNotFoundError;
                }

                return _mapper.Map<BrewerProfileDto>(brewer);
            }
            catch (Exception ex)
            {
                _logger.LogError($"BLL.GetOwnBrewerProfileAsync ERROR: {ex.Message}");

                return ProfileServiceErrors.GetBrewerProfileError;
            }
        }

        public async Task<Result<BrewerProfileDto, Error>> UpdateBrewerProfileAsync(UpdateBrewerProfileDto brewerProfileDto)
        {
            try
            {
                var isIdValid = _contextAccessor.TryGetUserId(out Guid userId);

                if (isIdValid is false)
                {
                    return UserErrors.InvalidUserId;
                }

                var brewer = await _context
                    .Brewers
                    .FirstOrDefaultAsync(x => x.Id == userId);

                if (brewer is null)
                {
                    return ProfileServiceErrors.UserNotFoundError;
                }

                _mapper.Map(brewerProfileDto, brewer);
                await _context.SaveChangesAsync();

                return _mapper.Map<BrewerProfileDto>(brewer);
            }
            catch (Exception ex)
            {
                _logger.LogError($"BLL.UpdateBrewerProfileAsync ERROR: {ex.Message}");

                return ProfileServiceErrors.UpdateProfileError;
            }
        }
    }
}
