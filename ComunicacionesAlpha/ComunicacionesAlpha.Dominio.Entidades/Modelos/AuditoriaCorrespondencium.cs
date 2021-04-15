using System;

#nullable disable

namespace ComunicacionesAlpha.Infraestructura.Models
{
    public partial class AuditoriaCorrespondencium
    {
        public int IdAuditoriaCorrespondencia { get; set; }
        public int IdRegistroCorrespondencia { get; set; }
        public long IdEmpleado { get; set; }
        public int IdEstadoCorrespondencia { get; set; }
        public DateTime FechaHoraRegistro { get; set; }

        public virtual Empleado IdEmpleadoNavigation { get; set; }
        public virtual EstadosCorrespondencium IdEstadoCorrespondenciaNavigation { get; set; }
        public virtual RegistroCorrespondencium IdRegistroCorrespondenciaNavigation { get; set; }
    }
}
