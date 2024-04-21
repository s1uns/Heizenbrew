using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure.ErrorHandling.Services.GenericException
{
    public class ServiceAddException : Exception
    {
        public ServiceAddException() { }
        public ServiceAddException(string message) : base(message) { }
        public ServiceAddException(string message, Exception inner) : base(message, inner) { }
    }
}