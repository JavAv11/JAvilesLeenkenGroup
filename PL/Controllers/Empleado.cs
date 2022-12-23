using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class Empleado : Controller
    {
        public ActionResult GetAll()
        {
            return View();
        }
    }
}
