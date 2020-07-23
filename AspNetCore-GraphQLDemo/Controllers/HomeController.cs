using AspNetCore_GraphQLDemo.GraphQL.Messaging;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore_GraphQLDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly MountainDetailsDisplayedMessageService _mountainDetailsDisplayedMessageService;

        public HomeController(MountainDetailsDisplayedMessageService mountainDetailsDisplayedMessageService)
        {
            _mountainDetailsDisplayedMessageService = mountainDetailsDisplayedMessageService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MountainDetails()
        {
            _mountainDetailsDisplayedMessageService.AddMountainDetailsMessage(123);
            return View();
        }
    }
}