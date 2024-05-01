using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure.ErrorHandling.Exceptions.Services.Recipe
{
    public class GetFilteredRecipesException : Exception
    {
        public GetFilteredRecipesException() { }
        public GetFilteredRecipesException(string message) : base(message) { }
        public GetFilteredRecipesException(string message, Exception inner) : base(message, inner) { }
    }
}
