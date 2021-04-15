namespace ComunicacionesAlpha.Dominio.Entidades.Modelos
{
    public class RegistroYAuditoria
    {
        public string EmailDestinatario { get; set; }
        public string TelefonoDestinatario { get; set; }
        public string DireccionDestinatario { get; set; }
        public string DocumentoDigital { get; set; }
        public string Consecutivo { get; set; }
        public long IdRegistroCorrespondencia { get; set; }
        public long IdEstadoCorrespondencia { get; set; }
        public long IdEmpleado { get; set; }
    }
}
