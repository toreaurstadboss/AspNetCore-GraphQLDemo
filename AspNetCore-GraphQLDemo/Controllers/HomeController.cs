using AspNetCore_GraphQLDemo.GraphQL.Messaging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore_GraphQLDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly MountainDetailsDisplayedMessageService _mountainDetailsDisplayedMessageService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(MountainDetailsDisplayedMessageService mountainDetailsDisplayedMessageService, IHttpContextAccessor httpContextAccessor)
        {
            _mountainDetailsDisplayedMessageService = mountainDetailsDisplayedMessageService;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MountainDetails([FromQuery] string id)
        {
            int mountainId;
            int.TryParse(id, out mountainId);
            _mountainDetailsDisplayedMessageService.AddMountainDetailsMessage(mountainId);
            return View();
        }
    }
}