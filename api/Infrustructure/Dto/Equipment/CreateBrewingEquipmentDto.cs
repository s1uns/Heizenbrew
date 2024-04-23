using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure.Dto.Equipment
{
    public record CreateBrewingEquipmentDto
    (
        string Name,
        string Description,
        string ImgUrl,
        decimal Price
    );
}
