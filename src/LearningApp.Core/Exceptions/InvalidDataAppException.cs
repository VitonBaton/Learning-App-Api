using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp.Core.Exceptions
{
    [Serializable]
    public class InvalidDataAppException : Exception
    {
        public InvalidDataAppException() { }

        public InvalidDataAppException(string message) : base(message) { }

        protected InvalidDataAppException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
