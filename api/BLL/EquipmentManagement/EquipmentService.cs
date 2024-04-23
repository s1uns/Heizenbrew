using AutoMapper;
using BLL.ProfileManagement;
using Core;
using Core.Models;
using Core.Models.Equipment;
using DAL;
using Infrustructure.Dto.Equipment;
using Infrustructure.ErrorHandling.Errors.Base;
using Infrustructure.ErrorHandling.Errors.ServiceErrors;
using Infrustructure.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.EquipmentManagement
{
    public class EquipmentService : IEquipmentService
    {
        private readonly ILogger<EquipmentService> _logger;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;

        public EquipmentService(ILogger<EquipmentService> logger, IMapper mapper, ApplicationDbContext context, IHttpContextAccessor contextAccessor)
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
            _contextAccessor = contextAccessor;
        }
        public async Task<Result<BrewingEquipmentFullInfoDto, Error>> AddEquipmentAsync(CreateBrewingEquipmentDto createBrewingEquipmentDto)
        {
            try
            {
                var equipment = _mapper.Map<BrewingEquipment>(createBrewingEquipmentDto);
                await _context.BrewingEquipment.AddAsync(equipment);
                await _context.SaveChangesAsync();
                return _mapper.Map<BrewingEquipmentFullInfoDto>(equipment);
            }
            catch (Exception ex)
            {
                _logger.LogError($"BLL.AddEquipmentAsync ERROR: {ex.Message}");
                return BrewingEquipmentServiceErrors.CreateEquipmentError;
            }
        }

        public async Task<Result<BrewerBrewingEquipmentFullInfoDto, Error>> BuyBrewingEquipmentAsync(Guid brewingEquipmentId)
        {
            try
            {
                var isUserValid = _contextAccessor.TryGetUserId(out Guid userId);

                if (!isUserValid)
                {
                    return UserErrors.InvalidUserId;
                }

                var user = await _context.Brewers.Where(u => u.Id == userId).Include(u => u.Equipment).FirstOrDefaultAsync();
                var equipment = await GetEquipmentAsync(brewingEquipmentId);
                var brewerEquipment = new BrewerBrewingEquipment { BrewingEquipment = equipment };
                user.Equipment.Add(brewerEquipment);
                await _context.SaveChangesAsync();
                return _mapper.Map<BrewerBrewingEquipmentFullInfoDto>(brewerEquipment);
            }
            catch (Exception ex)
            {
                _logger.LogError($"BLL.AddEquipmentAsync ERROR: {ex.Message}");
                return BrewingEquipmentServiceErrors.CreateEquipmentError;
            }
        }

        public async Task<Result<bool, Error>> DeleteEquipmentAsync(Guid brewingEquipmentId)
        {
            try
            {
                var equipment = await _context.BrewingEquipment.FirstOrDefaultAsync(bE => bE.Id == brewingEquipmentId);

                if(equipment is null)
                {
                    return BrewingEquipmentServiceErrors.GetEquipmentByIdError;
                }

                _context.BrewingEquipment.Remove(equipment);

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"BLL.DeleteEquipmentAsync ERROR: {ex.Message}");
                return BrewingEquipmentServiceErrors.DeleteEquipmentError;
            }
        }

        public async Task<Result<List<BrewingEquipmentFullInfoDto>, Error>> GetAllEquipmentAsync()
        {
            try
            {
                return _mapper.Map<List<BrewingEquipmentFullInfoDto>>(await _context.BrewingEquipment.ToListAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError($"BLL.GetAllEquipmentAsync ERROR: {ex.Message}");
                return BrewingEquipmentServiceErrors.GetEquipmentListError;
            }
        }

        public async Task<Result<List<BrewerBrewingEquipmentShortInfoDto>, Error>> GetBrewerEquipmentAsync()
        {
            try
            {
                var isUserValid = _contextAccessor.TryGetUserId(out Guid userId);

                if (!isUserValid)
                {
                    return UserErrors.InvalidUserId;
                }

                var filteredEquipment = await _context.BrewerBrewingEquipment.Where(bBE => bBE.BrewerId == userId).Include(bBE => bBE.BrewingEquipment).ToListAsync();

                var res = _mapper.Map<List<BrewerBrewingEquipmentShortInfoDto>>(filteredEquipment);

                return _mapper.Map<List<BrewerBrewingEquipmentShortInfoDto>>(filteredEquipment);
            }
            catch (Exception ex)
            {
                _logger.LogError($"BLL.GetAllEquipmentAsync ERROR: {ex.Message}");
                return BrewingEquipmentServiceErrors.GetEquipmentListError;
            }
        }

        public async Task<Result<BrewerBrewingEquipmentFullInfoDto, Error>> GetBrewerEquipmentByIdAsync(Guid brewerBrewingEquipmentId)
        {
            try
            {
                var isUserValid = _contextAccessor.TryGetUserId(out Guid userId);

                if (!isUserValid)
                {
                    return UserErrors.InvalidUserId;
                }

                var equipment = await _context.BrewerBrewingEquipment.Where(bE => bE.Id == brewerBrewingEquipmentId).Include(bBE => bBE.BrewingEquipment).FirstOrDefaultAsync();

                if(equipment is null)
                {
                    return BrewingEquipmentServiceErrors.GetEquipmentByIdError;
                }

                if(equipment.BrewerId != userId)
                {
                    return BrewingEquipmentServiceErrors.NotYourEquipmentError;
                }

                return _mapper.Map<BrewerBrewingEquipmentFullInfoDto>(equipment);
            }
            catch (Exception ex)
            {
                _logger.LogError($"BLL.GetBrewerEquipment ERROR: {ex.Message}");
                return BrewingEquipmentServiceErrors.GetEquipmentByIdError;
            }
        }

        public async Task<Result<BrewingEquipmentFullInfoDto, Error>> GetBrewingEquipmentAsync(Guid brewingEquipmentId)
        {
            try
            {
                var equipment = await _context.BrewingEquipment.FirstOrDefaultAsync(bE => bE.Id == brewingEquipmentId);

                if (equipment is null)
                {
                    return BrewingEquipmentServiceErrors.GetEquipmentByIdError;
                }


                return _mapper.Map<BrewingEquipmentFullInfoDto>(equipment);
            }
            catch (Exception ex)
            {
                _logger.LogError($"BLL.GetBrewingEquipmentAsync ERROR: {ex.Message}");
                return BrewingEquipmentServiceErrors.GetEquipmentByIdError;
            }
        }

        public async Task<Result<BrewerBrewingEquipmentFullInfoDto, Error>> UpdateConnectionStringAsync(Guid updateBrewingEquipmentId, string connectionString)
        {

            try  
            {
                var isUserValid = _contextAccessor.TryGetUserId(out Guid userId);

                if (!isUserValid)
                {
                    return UserErrors.InvalidUserId;
                }

                var equipment = await _context.BrewerBrewingEquipment.Where(bE => bE.Id == updateBrewingEquipmentId).Include(bBE => bBE.BrewingEquipment).FirstOrDefaultAsync();

                if (equipment is null)
                {
                    return BrewingEquipmentServiceErrors.GetEquipmentByIdError;
                }

                if (equipment.BrewerId != userId)
                {
                    return BrewingEquipmentServiceErrors.NotYourEquipmentError;
                }

                equipment.ConnectionString = connectionString;
                _context.BrewerBrewingEquipment.Update(equipment);
                await _context.SaveChangesAsync();
                return _mapper.Map<BrewerBrewingEquipmentFullInfoDto>(equipment);

                }
                catch (Exception ex)
                {
                    _logger.LogError($"BLL.UpdateConnectionStringAsync ERROR: {ex.Message}");
                    return BrewingEquipmentServiceErrors.ChangeConnectionStringError;
                }
            
        }

        public async Task<Result<BrewingEquipmentFullInfoDto, Error>> UpdateEquipmentAsync(UpdateBrewingEquipmentDto updateBrewingEquipmentDto)
        {
            try
            {
                var equipment = await _context.BrewingEquipment.FirstOrDefaultAsync(bE => bE.Id == updateBrewingEquipmentDto.Id);

                if (equipment is null)
                {
                    return BrewingEquipmentServiceErrors.GetEquipmentByIdError;
                }

                _mapper.Map(updateBrewingEquipmentDto, equipment);
                _context.BrewingEquipment.Update(equipment);
                await _context.SaveChangesAsync();

                return _mapper.Map<BrewingEquipmentFullInfoDto>(equipment);
            }
            catch (Exception ex)
            {
                _logger.LogError($"BLL.UpdateEquipmentAsync ERROR: {ex.Message}");
                return BrewingEquipmentServiceErrors.UpdateEquipmentError;
            }
        }


        private async Task<BrewingEquipment> GetEquipmentAsync(Guid equipmentId)
        {
            var equipment = await _context.BrewingEquipment.FirstOrDefaultAsync(bQ => bQ.Id == equipmentId);

            if(equipment is null)
            {
                throw new Exception("The equipment with such id doesn't exist.");
            }

            return equipment;
        }
    }
}
