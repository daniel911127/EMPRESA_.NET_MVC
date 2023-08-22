using EMPRESA.Models;
using EMPRESA.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EMPRESA.Controllers
{
    public class HomeController : Controller
    {
        private readonly DBEMPRESAContext _DBContext;

        public HomeController(DBEMPRESAContext context)
        {
            _DBContext = context;
        }

        public IActionResult Index()
        {
            List<Empleado> lista=_DBContext.Empleados.Include(c=>c.oCargo).Include(s=>s.oSede).ToList();
            return View(lista);
        }
        [HttpGet]
        public IActionResult Empleado_Detalle(int IdEmpleado)
        {
            EmpleadoVM oEmpleadoVM = new EmpleadoVM()
            {
                oEmpleado = new Empleado(),
                oListaCargo = _DBContext.Cargos.Select(cargo => new SelectListItem()
                {
                    Text = cargo.Descripcion,
                    Value = cargo.IdCargo.ToString()
                }).ToList(),
                oListaSede = _DBContext.Sedes.Select(sede => new SelectListItem()
                {
                    Text = sede.Descripcion,
                    Value = sede.IdSede.ToString()
                }).ToList()

            };
            if(IdEmpleado != 0)
            {
                oEmpleadoVM.oEmpleado = _DBContext.Empleados.Find(IdEmpleado);
            }
            return View(oEmpleadoVM);
        }
        [HttpPost]
        public IActionResult Empleado_Detalle(EmpleadoVM oEmpleadoVM)
        {
            if(oEmpleadoVM.oEmpleado.IdEmpleado == 0) {
                _DBContext.Empleados.Add(oEmpleadoVM.oEmpleado);
            }
            else
            {
                _DBContext.Empleados.Update(oEmpleadoVM.oEmpleado);
            }

            _DBContext.SaveChanges();

            return RedirectToAction("Index","Home");
        }
        [HttpGet]
        public IActionResult Eliminar(int IdEmpleado)
        {       
            Empleado oEmpleado=_DBContext.Empleados.Include(c=>c.oCargo).Where(e=>e.IdEmpleado==IdEmpleado).Include(s => s.oSede).Where(e => e.IdEmpleado == IdEmpleado).FirstOrDefault();
            return View(oEmpleado);
        }
        [HttpPost]
        public IActionResult Eliminar(Empleado oEmpleado)
        {
            _DBContext.Empleados.Remove(oEmpleado);
            _DBContext.SaveChanges();

            return RedirectToAction("Index", "Home"); 
        }
    }
}