namespace ApplicationGetter.Application.Commands.Application
{
    internal sealed class ApplicationsListNotFoundException : ApplicationException
    {
        internal ApplicationsListNotFoundException(string message)
            : base(message)
        { }
    }
}
