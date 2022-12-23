using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            ML.Empleado empleado = new ML.Empleado();

            empleado.Estado = new ML.Estado();
            ML.Result result = BL.Empleado.GetAll();
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpGet("GetById/{IdEmpleado}")]
        public IActionResult Get(int IdEmpleado)
        {
            ML.Empleado empleado = new ML.Empleado();

            empleado.Estado = new ML.Estado();
            ML.Result result = BL.Empleado.GetById(IdEmpleado);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete ("Delete/{idUsuario}")]
        public IActionResult Delete(int IdEmpleado)
        {
            ML.Result result = new ML.Result();

            result = BL.Empleado.Delete(IdEmpleado);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("Add")]
        public ActionResult Add(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();


            result = BL.Empleado.Add(empleado);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("Update")]
        public ActionResult Update(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();

            result = BL.Empleado.Update(empleado);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

    }
}
