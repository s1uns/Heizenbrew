namespace Infrustructure.ErrorHandling.Repository.Exceptions
{
    public class RepositoryAddException : Exception
    {
        public RepositoryAddException() { }
        public RepositoryAddException(string message) : base(message) { }
        public RepositoryAddException(string message, Exception inner) : base(message, inner) { }
    }
}
