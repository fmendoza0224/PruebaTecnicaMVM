using System.Collections.Generic;

#nullable disable

namespace ComunicacionesAlpha.Infraestructura.Models
{
    public partial class Role
    {
        public Role()
        {
            Empleados = new HashSet<Empleado>();
        }

        public int IdRol { get; set; }
        public string NombreRol { get; set; }
        public string Permisos { get; set; }

        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
