namespace Infrustructure.ErrorHandling.Exceptions.Repository.Exceptions
{
    public class RepositoryDeleteException : Exception
    {
        public RepositoryDeleteException() { }
        public RepositoryDeleteException(string message) : base(message) { }
        public RepositoryDeleteException(string message, Exception inner) : base(message, inner) { }
    }
}
