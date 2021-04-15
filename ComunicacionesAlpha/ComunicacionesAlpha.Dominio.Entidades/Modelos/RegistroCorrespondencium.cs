#nullable disable

namespace ComunicacionesAlpha.Infraestructura.Models
{
    public partial class RegistroCorrespondencium
    {
        public int IdRegistroCorrespondencia { get; set; }
        public string Consecutivo { get; set; }
        public long NumeroDocumentoRemitente { get; set; }
        public string NombresRemitente { get; set; }
        public string ApellidosRemitente { get; set; }
        public string EmailRemitente { get; set; }
        public string TelefonoRemitente { get; set; }
        public long NumeroDocumentoDestinatario { get; set; }
        public string NombresDestinatario { get; set; }
        public string ApellidosDestinatario { get; set; }
        public string EmailDestinatario { get; set; }
        public string TelefonoDestinatario { get; set; }
        public string DireccionDestinatario { get; set; }
        public string DocumentoDigital { get; set; }
    }
}
