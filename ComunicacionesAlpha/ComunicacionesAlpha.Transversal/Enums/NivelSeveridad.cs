using System.Runtime.Serialization;

namespace ComunicacionesAlpha.Transversal
{
    public enum NivelSeveridad
    {
        [EnumMember(Value = "INFORMACION")]
        Info,
        [EnumMember(Value = "ERROR")]
        Error
    }
}
