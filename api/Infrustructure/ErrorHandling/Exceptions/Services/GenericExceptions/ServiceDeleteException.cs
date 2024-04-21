using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure.ErrorHandling.Services.GenericException
{
    public class ServiceDeleteException : Exception
    {
        public ServiceDeleteException() { }
        public ServiceDeleteException(string message) : base(message) { }
        public ServiceDeleteException(string message, Exception inner) : base(message, inner) { }
    }
}