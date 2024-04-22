using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure.Dto.EquipmentDto
{
    public record BrewingEquipmentShortInfoDto
    (
        Guid Id,
        string Name,
        string ImgUrl,
        decimal Price
    );
}
