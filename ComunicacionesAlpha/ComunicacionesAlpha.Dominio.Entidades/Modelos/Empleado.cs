using System;

#nullable disable

namespace ComunicacionesAlpha.Infraestructura.Models
{
    public partial class Empleado
    {
        public long IdEmpleado { get; set; }
        public int IdRol { get; set; }
        public int IdCargo { get; set; }
        public string NombresEmpleado { get; set; }
        public string ApellidosEmpleado { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaInicioLabores { get; set; }
        public string TelefonoResidencia { get; set; }
        public string DireccionResidencia { get; set; }
        public string EmailCorporativo { get; set; }
        public string EmailPersonal { get; set; }

        public virtual Cargo IdCargoNavigation { get; set; }
        public virtual Role IdRolNavigation { get; set; }
    }
}
