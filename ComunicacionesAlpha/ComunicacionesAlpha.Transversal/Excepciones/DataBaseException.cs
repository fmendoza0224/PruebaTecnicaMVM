using System;
using System.Runtime.Serialization;

namespace ComunicacionesAlpha.Transversal.Excepciones
{
    [Serializable]
    public class DataBaseException : Exception
    {
        public DataBaseException(Exception e) : base(e.Message) { }

        public DataBaseException(string message) : base(message) { }

        protected DataBaseException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
