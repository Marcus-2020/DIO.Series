using System;

namespace DataLibrary.Exceptions
{
    /// <summary>
    /// The SeriesNotFoundException is thrown when, during a search, no series is found.
    /// </summary>
    public class SeriesNotFoundException : Exception
    {
        public SeriesNotFoundException()
        {
        }

        public SeriesNotFoundException(string message) : base(message)
        {

        }

        public SeriesNotFoundException(string message, Exception innerException) 
        : base(message, innerException)
        {
        }
    }
}