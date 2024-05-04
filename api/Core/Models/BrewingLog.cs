using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class BrewingLog : BaseEntity
    {
        public Guid BrewingId { get; set; }
        public Brewing Brewing { get; set; }
        public BrewingLogCode StatusCode { get; set; }
        public string Message { get; set; }
        public DateTime LogTime { get; set; }
    }
}
