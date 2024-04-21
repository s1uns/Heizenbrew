using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure.ErrorHandling.Services.GenericException
{
    public class ServiceGetAllException : Exception
    {
        public ServiceGetAllException() { }
        public ServiceGetAllException(string message) : base(message) { }
        public ServiceGetAllException(string message, Exception inner) : base(message, inner) { }
    }
}