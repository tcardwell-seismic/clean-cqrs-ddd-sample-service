using System;

namespace Seismic.Clean.Domain.Common.Exceptions
{
    public class InvalidVersionOperationException : Exception
    {
        public InvalidVersionOperationException(string message)
            : base(message)
        {
        }
    }
}