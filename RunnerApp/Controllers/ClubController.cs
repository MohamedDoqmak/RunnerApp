using Microsoft.AspNetCore.Mvc;

namespace RunnerApp.Controllers
{
    public class ClubController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
