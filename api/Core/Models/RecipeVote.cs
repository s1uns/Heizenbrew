using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class RecipeVote : BaseEntity
    {
        public Brewer Brewer { get; set; }
        public Recipe Recipe { get; set; }
        public bool IsPositive { get; set; }
    }
}
