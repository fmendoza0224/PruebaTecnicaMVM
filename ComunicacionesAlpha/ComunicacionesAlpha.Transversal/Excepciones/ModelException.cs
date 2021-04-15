using System;
using System.Runtime.Serialization;

namespace ComunicacionesAlpha.Api.Excepciones
{
    [Serializable]
    public class ModelException : Exception
    {
        public ModelException(Exception e) : base(e.Message) { }

        public ModelException(string message) : base(message) { }

        protected ModelException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
