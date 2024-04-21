namespace Infrustructure.ErrorHandling.Repository.Exceptions
{
    public class RepositoryAddRangeException : Exception
    {
        public RepositoryAddRangeException() { }
        public RepositoryAddRangeException(string message) : base(message) { }
        public RepositoryAddRangeException(string message, Exception inner) : base(message, inner) { }
    }
}