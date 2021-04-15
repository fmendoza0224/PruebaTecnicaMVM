using System;
using System.Runtime.Serialization;

namespace ComunicacionesAlpha.Transversal.Excepciones
{
    [Serializable]
    public class TechnicalException : Exception
    {
        public TechnicalException(Exception e) : base(e.Message) { }

        public TechnicalException(string message) : base(message) { }

        public TechnicalException(string message, Exception innerException) { }

        protected TechnicalException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
