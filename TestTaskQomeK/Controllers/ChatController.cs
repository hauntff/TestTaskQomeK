using Microsoft.AspNetCore.Mvc;

namespace TestTaskQomeK.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
