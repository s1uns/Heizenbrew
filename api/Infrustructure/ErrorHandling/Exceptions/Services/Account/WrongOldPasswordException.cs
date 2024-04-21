using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure.ErrorHandling.Exceptions.Services.Account
{
    public class WrongOldPasswordException : Exception
    {
        public WrongOldPasswordException() { }
        public WrongOldPasswordException(string message) : base(message) { }
        public WrongOldPasswordException(string message, Exception inner) : base(message, inner) { }
    }
}
