using Microsoft.AspNetCore.Mvc;

namespace InternApp.Controllers
{
    public class FormController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
