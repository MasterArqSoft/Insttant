using System;
using System.Globalization;

namespace CodeFirst.Infrastructure.Exceptions
{
    public class InfraestructuraException : Exception
    {
        public InfraestructuraException() : base() { }
        public InfraestructuraException(string message) : base(message) { }
        public InfraestructuraException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
        public InfraestructuraException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
