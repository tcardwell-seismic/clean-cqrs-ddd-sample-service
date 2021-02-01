using System;

namespace Seismic.Clean.Domain.Common.Exceptions
{
    public class InvalidContentFormatException : Exception
    {
        public InvalidContentFormatException(string format)
            : base($"{format} is not a supported content type")
        {
        }
    }
}