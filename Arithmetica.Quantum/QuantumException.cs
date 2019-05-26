using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Arithmetica.Quantum
{
    public class QuantumException : Exception
    {
        public QuantumException()
        {
        }

        public QuantumException(string message) : base(message)
        {
        }

        public QuantumException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected QuantumException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
