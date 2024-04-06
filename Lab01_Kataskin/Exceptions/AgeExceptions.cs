using System;

namespace Lab01_Kataskin.Exceptions
{
    internal class TooOldException : Exception
    {
        public TooOldException() { }
        public TooOldException(string message) : base(message) { }
        public TooOldException(string message, Exception inner) : base(message, inner) { }
    }
    
    internal class NegativeAgeException : Exception
    {
        public NegativeAgeException() { }
        public NegativeAgeException(string message) : base(message) { }
        public NegativeAgeException(string message, Exception inner) : base(message, inner) { }
    }
}