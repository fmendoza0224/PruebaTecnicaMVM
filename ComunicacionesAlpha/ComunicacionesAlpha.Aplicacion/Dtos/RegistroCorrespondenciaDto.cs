using System.ComponentModel.DataAnnotations;

namespace ComunicacionesAlpha.Aplicacion.Dtos
{
    public class RegistroCorrespondenciaDto
    {
        [Required(ErrorMessage = "{0} es requerido.")]
        public string Consecutivo { get; set; }

        [Required(ErrorMessage = "{0} es requerido.")]
        public long NumeroDocumentoRemitente { get; set; }

        [Required(ErrorMessage = "{0} es requerido.")]
        public string NombresRemitente { get; set; }

        [Required(ErrorMessage = "{0} es requerido.")]
        public string ApellidosRemitente { get; set; }

        [Required(ErrorMessage = "{0} es requerido.")]
        public string EmailRemitente { get; set; }

        [Required(ErrorMessage = "{0} es requerido.")]
        public string TelefonoRemitente { get; set; }

        [Required(ErrorMessage = "{0} es requerido.")]
        public long NumeroDocumentoDestinatario { get; set; }

        [Required(ErrorMessage = "{0} es requerido.")]
        public string NombresDestinatario { get; set; }

        [Required(ErrorMessage = "{0} es requerido.")]
        public string ApellidosDestinatario { get; set; }

        [Required(ErrorMessage = "{0} es requerido.")]
        public string EmailDestinatario { get; set; }

        [Required(ErrorMessage = "{0} es requerido.")]
        public string TelefonoDestinatario { get; set; }

        [Required(ErrorMessage = "{0} es requerido.")]
        public string DireccionDestinatario { get; set; }

        [Required(ErrorMessage = "{0} es requerido.")]
        public string DocumentoDigital { get; set; }

        [Required(ErrorMessage = "{0} es requerido.")]
        public long IdEmpleado { get; set; }
    }
}
