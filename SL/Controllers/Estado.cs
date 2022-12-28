using Microsoft.AspNetCore.Mvc;

namespace SL.Controllers
{
    public class Estado : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult GetAll()
        {
            ML.Result result = BL.Estado.EstadoGetAll();
            return Json(result);
        }
    }
}
