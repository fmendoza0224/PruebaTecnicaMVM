using System.Collections.Generic;

#nullable disable

namespace ComunicacionesAlpha.Infraestructura.Models
{
    public partial class Cargo
    {
        public Cargo()
        {
            Empleados = new HashSet<Empleado>();
        }

        public int IdCargo { get; set; }
        public string NombreCargo { get; set; }

        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
