using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure.ErrorHandling.Services.GenericException
{
    public class ServiceUpdateException : Exception
    {
        public ServiceUpdateException() { }
        public ServiceUpdateException(string message) : base(message) { }
        public ServiceUpdateException(string message, Exception inner) : base(message, inner) { }
    }
}