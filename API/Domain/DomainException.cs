namespace API.Domain
{
    public class DomainException : Exception
    {
        public DomainException(){}
        public DomainException(string message) : base(message) {}
        public DomainException(string message, Exception innerExcepetion) : base(message, innerExcepetion){ }
    }
}
