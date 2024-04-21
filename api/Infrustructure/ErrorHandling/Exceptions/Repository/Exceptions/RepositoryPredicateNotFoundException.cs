using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure.ErrorHandling.Repository.Exceptions
{
    public class RepositoryPredicateNotFoundException : Exception
    {
        public RepositoryPredicateNotFoundException() { }
        public RepositoryPredicateNotFoundException(string message) : base(message) { }
        public RepositoryPredicateNotFoundException(string message, Exception inner) : base(message, inner) { }
    }
}