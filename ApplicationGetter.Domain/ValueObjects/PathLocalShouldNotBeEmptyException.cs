namespace ApplicationGetter.Domain.ValueObjects
{
    public sealed class PathLocalShouldNotBeEmptyException : DomainException
    {
        internal PathLocalShouldNotBeEmptyException(string message)
            : base(message)
        { }
    }
}
