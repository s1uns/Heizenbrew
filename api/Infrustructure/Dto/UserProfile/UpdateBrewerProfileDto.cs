using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure.Dto.UserProfile
{
    public record UpdateBrewerProfileDto
    (   
        string FirstName,
        string LastName,
        string ProfileColor
    );
}
