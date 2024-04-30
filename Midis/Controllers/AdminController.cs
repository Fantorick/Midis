using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Midis.Abstract;
using Midis.Domains;
using Midis.Models;

namespace Midis.Controllers
{
    [Authorize(Roles = "Админ")]
    public class AdminController : Controller
    {
        private readonly IRepository<Item> _repositoryItem;
        private readonly IRepository<NumberGroup> _repositoryGroup;
        public AdminController(IRepository<Item> repositoryItem, IRepository<NumberGroup> repositoryGroup)
        {
            _repositoryItem = repositoryItem;
            _repositoryGroup = repositoryGroup;
        }

        public ActionResult Index() { return View(); }
        public IActionResult CreateUsers() { return View(); }
        public IActionResult CreateSchedules() { return View(); }
        public IActionResult ListItemsAndGroup()
        {            
            return View();
        }        
        public IActionResult ListUsersByGroups() { return View(); }
    }
}
    
