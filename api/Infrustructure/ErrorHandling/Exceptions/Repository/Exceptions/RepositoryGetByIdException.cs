namespace Infrustructure.ErrorHandling.Repository.Exceptions
{
    public class RepositoryGetByIdException : Exception
    {
        public RepositoryGetByIdException() { }
        public RepositoryGetByIdException(string message) : base(message) { }
        public RepositoryGetByIdException(string message, Exception inner) : base(message, inner) { }
    }
}
