using BLL.ProfileManagement.Interface;
using Core;
using Infrustructure.Dto.UserProfile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace heisenbrew_api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        /// <summary>
        /// Gets a profile of specific brewer.
        /// </summary>
        /// <param name="id">The id of a specific brewer profile.</param>
        /// <remarks>
        /// If the operation is successful, it will return a BrewerProfileDto.
        /// </remarks>
        /// <returns>An IActionResult representing the result of the operation.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrewerProfile(Guid id)
        {
            var result = await _profileService.GetBrewerProfileAsync(id);

            return this.CreateResponse(result);
        }

        /// <summary>
        /// Gets brewer's own profile.
        /// </summary>
        /// <remarks>
        /// If the operation is successful, it will return a BrewerProfileDto.
        /// </remarks>
        /// <returns>An IActionResult representing the result of the operation.</returns>
        [HttpGet("me")]
        [Authorize]
        public async Task<IActionResult> GetOwnBrewerProfile()
        {
            var result = await _profileService.GetOwnBrewerProfileAsync();

            return this.CreateResponse(result);
        }

        /// <summary>
        /// Updates brewer's own profile.
        /// </summary>
        /// <param name="brewerProfileDto">The dto to update brewer's profile.</param>
        /// <remarks>
        /// If the operation is successful, it will return a BrewerProfileDto.
        /// </remarks>
        /// <returns>An IActionResult representing the result of the operation.</returns>
        [HttpPut("edit")]
        [Authorize]
        public async Task<IActionResult> EditBrewerProfile([FromBody] UpdateBrewerProfileDto brewerProfileDto)
        {
            var result = await _profileService.UpdateBrewerProfileAsync(brewerProfileDto);

            return this.CreateResponse(result);
        }

    }
}
