namespace Infrustructure.ErrorHandling.Repository.Exceptions
{
    public class RepositoryGetAllException : Exception
    {
        public RepositoryGetAllException() { }
        public RepositoryGetAllException(string message) : base(message) { }
        public RepositoryGetAllException(string message, Exception inner) : base(message, inner) { }
    }
}
