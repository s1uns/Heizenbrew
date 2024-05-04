using Core;
using Infrustructure.Dto.Brewing;
using Infrustructure.ErrorHandling.Errors.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BrewingManagement
{
    public interface IBrewingService
    {
        public Task<Result<string, Error>> StartBrewingAsync(Guid recipeId, Guid equipmentId);
        public Task<Result<BrewingFullInfoDto, Error>> GetBrewingStatusAsync(Guid equipmentId);
        public Task<Result<string, Error>> AbortBrewingAsync(Guid equipmentId);
        public Task<Result<List<BrewingShortInfoDto>, Error>> GetBrewingsAsync(Guid equipmentId);

    }
}
