using System;
using System.Runtime.Serialization;

namespace Lab23.Controllers
{
    [Serializable]
    internal class RetrylimitExceededException : Exception
    {
        public RetrylimitExceededException()
        {
        }

        public RetrylimitExceededException(string message) : base(message)
        {
        }

        public RetrylimitExceededException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RetrylimitExceededException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}