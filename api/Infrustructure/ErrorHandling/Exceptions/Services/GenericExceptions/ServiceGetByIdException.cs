using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure.ErrorHandling.Services.GenericException
{
    public class ServiceGetByIdException : Exception
    {
        public ServiceGetByIdException() { }
        public ServiceGetByIdException(string message) : base(message) { }
        public ServiceGetByIdException(string message, Exception inner) : base(message, inner) { }
    }
}