using Microsoft.AspNetCore.Mvc;
using Midis.BlazorServices;
using Midis.Domains;
using Midis.Models;
using System.Diagnostics;

namespace Midis.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private UserContentService _contentService;
        public HomeController(ILogger<HomeController> logger, UserContentService contentService)
        {
            _logger = logger;
            _contentService = contentService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ScheduleForUser()
        {
            var user = _contentService.GetRepositoryUser().Users.FirstOrDefault(u => u.UserName == HttpContext.User.Identity.Name);
            var userGroup = _contentService.GetRepositoryUserGroup().ReadList().Where(ug => ug.User.Id == user.Id).FirstOrDefault();
            var schedule = _contentService.GetRepositorySchedule().ReadList().Where(s => s.Group.Name == userGroup.Group.Name);

            //IEnumerable<Schedule> schedule = (_contentService.GetRepositorySchedule().ReadList());
            return View(schedule);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
