using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoyectoTorresBack.services;
using PoyectoTorresBack.viewmodels;

namespace PoyectoTorresBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        public IEmpleados empleado;

        public EmpleadosController(IEmpleados _empleados)
        {
            this.empleado = _empleados;
        }
        [HttpGet("ObtenerEmpleados")]
        public ActionResult ObtenerEmpleados()
        {
            return new JsonResult(empleado.ObtenerEmpleado());
        }
        [HttpGet("ObtenerCargos")]
        public ActionResult ObtenerCargo()
        {
            return new JsonResult(empleado.GetAllCargos());
        }
        [HttpGet("ObtenerDepartamentos")]
        public ActionResult ObtenerDepartamento()
        {
            return new JsonResult(empleado.GetAllDepartamentos());
        }
        [HttpPost("setEmpleado")]
        public bool setEmpleado(EmpleadoVM empleados)
        {
            return empleado.setEmpleados(empleados);
        }
        [HttpPost("putEmpleado")]
        public bool putEmpleado(EmpleadoVM empleados)
        {
            return empleado.putEmpleados(empleados);
        }
        [HttpPost("deletEmpleado")]
        public bool deletEmpleado(int id)
        {
            return empleado.deleteEmpleados(id);
        }
        [HttpPost("GetUsuariosFiltros")]
        public IActionResult GetUsuariosFiltros(EmpleadoVM empleados)
        {
            if (empleados.idcargo != 0 && empleados.iddepartamento != 0)
            {
                var result = empleado.ObtenerEmpleado().Where(s => s.idcargo == empleados.idcargo && s.iddepartamento==empleados.iddepartamento);
                return new JsonResult(result);
            }
            else if  (empleados.iddepartamento != 0)
            {
                var result = empleado.ObtenerEmpleado().Where(x => x.iddepartamento == empleados.iddepartamento);
                return new JsonResult(result);
            }
            else
            {
                var result = empleado.ObtenerEmpleado().Where(x => x.idcargo == empleados.idcargo);
                return new JsonResult(result);
            }

        }

    }
}
