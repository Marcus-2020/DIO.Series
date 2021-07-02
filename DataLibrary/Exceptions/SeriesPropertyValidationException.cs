using System;

namespace DataLibrary.Exceptions
{
    /// <summary>
    /// The SeriesPropertyValidationException is thrown when a validation error
    /// occurs by passing bad data to one of the Series properties.
    /// </summary>
    public class SeriesPropertyValidationException : Exception
    {
        public SeriesPropertyValidationException()
        {
        }

        public SeriesPropertyValidationException(string message) : base(message)
        {
        }

        public SeriesPropertyValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}