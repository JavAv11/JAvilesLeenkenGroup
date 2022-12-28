using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class Empleado : Controller
    {
        
        [HttpGet]
        public ActionResult GetAll()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Form()
        {
            return View(new ML.Empleado());
        }

        [HttpGet]
        public JsonResult Delete(int IdEmpleado)
        {
            ML.Result result = BL.Empleado.Delete(IdEmpleado);

            return Json(result);
        }
    }
}


