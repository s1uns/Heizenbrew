using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure.ErrorHandling.Services.GenericException
{
    public class ServiceGetByPredicateException : Exception
    {
        public ServiceGetByPredicateException() { }
        public ServiceGetByPredicateException(string message) : base(message) { }
        public ServiceGetByPredicateException(string message, Exception inner) : base(message, inner) { }
    }
}