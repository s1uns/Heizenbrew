namespace Infrustructure.ErrorHandling.Services.GenericExceptions
{
    public class ServiceEntityIsNullException : Exception
    {
        public ServiceEntityIsNullException() { }
        public ServiceEntityIsNullException(string message) : base(message) { }
        public ServiceEntityIsNullException(string message, Exception inner) : base(message, inner) { }
    }
}