namespace Infrustructure.ErrorHandling.Repository.Exceptions
{
    public class RepositoryGetByPredicateException : Exception
    {
        public RepositoryGetByPredicateException() { }
        public RepositoryGetByPredicateException(string message) : base(message) { }
        public RepositoryGetByPredicateException(string message, Exception inner) : base(message, inner) { }
    }
}
