using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure.ErrorHandling.Repository.Exceptions
{
    public class RepositoryIdNotRetrievedException : Exception
    {
        public RepositoryIdNotRetrievedException() { }
        public RepositoryIdNotRetrievedException(string message) : base(message) { }
        public RepositoryIdNotRetrievedException(string message, Exception inner) : base(message, inner) { }
    }
}