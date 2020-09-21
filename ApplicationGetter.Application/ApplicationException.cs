using System;

namespace ApplicationGetter.Application
{
    public class ApplicationException : Exception
    {
        internal ApplicationException(string businessMessage)
               : base(businessMessage)
        {
        }
    }
}
