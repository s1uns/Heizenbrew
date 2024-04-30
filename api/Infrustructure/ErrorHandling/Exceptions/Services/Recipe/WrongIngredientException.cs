using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure.ErrorHandling.Exceptions.Services.Recipe
{
    public class WrongIngredientException : Exception
    {
        public WrongIngredientException() { }
        public WrongIngredientException(string message) : base(message) { }
        public WrongIngredientException(string message, Exception inner) : base(message, inner) { }
    }
}
