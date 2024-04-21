using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure.ErrorHandling.Exceptions.Repository.Exceptions
{
    public class RepositoryGetRangeException : Exception
    {
        public RepositoryGetRangeException() { }
        public RepositoryGetRangeException(string message) : base(message) { }
        public RepositoryGetRangeException(string message, Exception inner) : base(message, inner) { }
    }
}