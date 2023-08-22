using System;
using System.Collections.Generic;

namespace EMPRESA.Models
{
    public partial class Empleado
    {
        public int IdEmpleado { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? Telefono { get; set; }
        public int? IdCargo { get; set; }
        public int? IdSede { get; set; }

        public virtual Cargo? oCargo { get; set; }
        public virtual Sede? oSede { get; set; }
    }
}
