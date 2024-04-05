using Microsoft.AspNetCore.Mvc;
using DrogueriaWeb1.Datos;
using DrogueriaWeb1.Models;

namespace DrogueriaWeb1.Controllers
{
    public class MantenedorController : Controller
    {
        EmpleadosDatos _EmpleadosDatos = new EmpleadosDatos();
        
        public IActionResult Listar()
        {
                      
            //Listar todos los empleados
            var oLista = _EmpleadosDatos.Listar();
            return View(oLista);
        }

        public IActionResult Guardar()
        {
            //Devuelve vista
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(EmpleadosModel oEmpleado)
        {
            //Recibe un objeto y lo guarda en la BD
            if (!ModelState.IsValid)
                return View();

            var respuesta = _EmpleadosDatos.Guardar(oEmpleado);

            if (respuesta)
                return RedirectToAction("Listar");
            else 
                return View();
        }
    }
}
