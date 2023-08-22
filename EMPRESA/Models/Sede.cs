using System;
using System.Collections.Generic;

namespace EMPRESA.Models
{
    public partial class Sede
    {
        public Sede()
        {
            Empleados = new HashSet<Empleado>();
        }

        public int IdSede { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
