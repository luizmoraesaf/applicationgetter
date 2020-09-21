namespace ApplicationGetter.Application.Commands.Application
{
    internal sealed class ApplicationNotFoundException : ApplicationException
    {
        internal ApplicationNotFoundException(string message)
            : base(message)
        { }
    }
}
