using Microsoft.AspNetCore.Mvc.Rendering;

namespace EMPRESA.Models.ViewModels
{
    public class EmpleadoVM
    {
        public Empleado oEmpleado { get; set; }
        public List<SelectListItem>oListaCargo { get; set; }
        public List<SelectListItem> oListaSede {  get; set; }
    }
}
