using Infrustructure.Dto.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure.Dto.UserProfile
{
    public record BrewerProfileDto
    (
        Guid Id,
        string FullName,
        string ProfileColor,
        List<BrewerBrewingEquipmentShortInfoDto> Equipment
    );
}
