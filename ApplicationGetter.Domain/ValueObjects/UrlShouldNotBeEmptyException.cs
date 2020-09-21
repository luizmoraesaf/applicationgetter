namespace ApplicationGetter.Domain.ValueObjects
{
    public sealed class UrlShouldNotBeEmptyException : DomainException
    {
        internal UrlShouldNotBeEmptyException(string message)
            : base(message)
        { }
    }
}
