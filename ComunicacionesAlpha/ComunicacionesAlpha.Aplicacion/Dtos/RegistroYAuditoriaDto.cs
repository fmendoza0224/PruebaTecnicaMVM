using System.ComponentModel.DataAnnotations;

namespace ComunicacionesAlpha.Aplicacion.Dtos
{
    public class RegistroYAuditoriaDto
    {
        [Required(ErrorMessage = "{0} es requerido.")]
        public string EmailDestinatario { get; set; }

        [Required(ErrorMessage = "{0} es requerido.")]
        public string TelefonoDestinatario { get; set; }

        [Required(ErrorMessage = "{0} es requerido.")]
        public string DireccionDestinatario { get; set; }

        [Required(ErrorMessage = "{0} es requerido.")]
        public string DocumentoDigital { get; set; }

        [Required(ErrorMessage = "{0} es requerido.")]
        public string Consecutivo { get; set; }

        [Required(ErrorMessage = "{0} es requerido.")]
        public int IdRegistroCorrespondencia { get; set; }

        [Required(ErrorMessage = "{0} es requerido.")]
        public int IdEstadoCorrespondencia { get; set; }

        [Required(ErrorMessage = "{0} es requerido.")]
        public int IdEmpleado { get; set; }
    }
}
