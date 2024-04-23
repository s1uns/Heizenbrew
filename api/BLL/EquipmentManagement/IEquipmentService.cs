using Core;
using Infrustructure.Dto.Equipment;
using Infrustructure.ErrorHandling.Errors.Base;

namespace BLL.EquipmentManagement
{
    public interface IEquipmentService
    {
        //Brewing Equipment Management
        public Task<Result<BrewingEquipmentFullInfoDto, Error>> AddEquipmentAsync(CreateBrewingEquipmentDto createBrewingEquipmentDto);
        public Task<Result<BrewingEquipmentFullInfoDto, Error>> UpdateEquipmentAsync(UpdateBrewingEquipmentDto updateBrewingEquipmentDto);
        public Task<Result<bool, Error>> DeleteEquipmentAsync(Guid brewingEquipmentId);
        public Task<Result<BrewingEquipmentFullInfoDto, Error>> GetBrewingEquipmentAsync (Guid brewingEquipmentId);
        public Task<Result<List<BrewingEquipmentFullInfoDto>, Error>> GetAllEquipmentAsync();


        //Brewer's Brewing Equipment Management
        public Task<Result<List<BrewerBrewingEquipmentShortInfoDto>, Error>> GetBrewerEquipmentAsync();
        public Task<Result<BrewerBrewingEquipmentFullInfoDto, Error>> GetBrewerEquipmentByIdAsync(Guid brewerBrewingEquipmentId);
        public Task<Result<BrewerBrewingEquipmentFullInfoDto, Error>> BuyBrewingEquipmentAsync(Guid brewingEquipmentId);
        public Task<Result<BrewerBrewingEquipmentFullInfoDto, Error>> UpdateConnectionStringAsync(Guid Id, string connectionString);
    }
}
