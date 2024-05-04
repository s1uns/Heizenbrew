using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure.Dto.Brewing
{
    public record BrewingFullInfoDto
    (
        string EquipmentTitle,
        string RecipeTitle,
        string BrewingStatus,
        string LastUpdateDate,
        IList<BrewingLogDto> BrewingLogs
    );
}
