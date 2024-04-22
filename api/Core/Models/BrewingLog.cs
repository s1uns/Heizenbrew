using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class BrewingLog : BaseEntity
    {
        public Brewing Brewing { get; set; }
        public BrewingLogCode BrewingLogCode { get; set; }
        public string Message { get; set; }
        public DateTime LogTime { get; set; }
    }
}
