using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp.Core.Exceptions
{
    public class NotFoundAppException : Exception 
    {
        public NotFoundAppException() { }

        public NotFoundAppException(string message) : base(message) { }

        protected NotFoundAppException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
