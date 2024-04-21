using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure.ErrorHandling.Repository.Exceptions
{
    public class RepositoryListIsNullException : Exception
    {
        public RepositoryListIsNullException() { }
        public RepositoryListIsNullException(string message) : base(message) { }
        public RepositoryListIsNullException(string message, Exception inner) : base(message, inner) { }
    }
}