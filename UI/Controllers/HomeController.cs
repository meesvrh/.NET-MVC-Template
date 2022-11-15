﻿using Microsoft.AspNetCore.Authorization;
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
            return View();
        }

        public IActionResult Dashboard()
        {   
            var dashboardVM = new DashboardViewModel
            {
                Users = _serviceManager.User.GetAll(),
            };

            return View(dashboardVM);
        }
    }
}