using System;
namespace Algorithms.Exceptions
{
    public class CoreDateDiffException : Exception
    {
        public CoreDateDiffException()
        {
        }

        public CoreDateDiffException(string message) : base(message)
        {
        }

        public CoreDateDiffException(string message, Exception innerException): base(message, innerException)
        {

        }
    }
}
