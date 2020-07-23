using Microsoft.AspNetCore.Mvc;

namespace AspNetCore_GraphQLDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}