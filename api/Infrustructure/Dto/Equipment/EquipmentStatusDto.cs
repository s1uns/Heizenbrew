using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure.Dto.Equipment
{
    public record EquipmentStatusDto
    (
        double Temperature,
        double Pressure,
        double Humidity,
        double Fullness,
        string LastUpdate
    );
}
