using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp.Core.Exceptions
{
    [Serializable]
    public class AppException : Exception
    {
        public AppException() { }

        public AppException(string message) : base(message) { }

        protected AppException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
