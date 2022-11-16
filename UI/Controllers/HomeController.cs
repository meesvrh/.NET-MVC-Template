using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System.Diagnostics;
using UI.Models;

namespace UI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public HomeController(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [AllowAnonymous]
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var dashboardVM = new DashboardViewModel
                {
                    Users = _serviceManager.UserData.GetAll(),
                };

                return View("Dashboard", dashboardVM);
            }

            return View();
        }
    }
}