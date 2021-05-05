using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackAnalyser.Models;

namespace TrackAnalyser.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly RoleManager<ApplicationUser> _roleManager;

        public AdministrationController(RoleManager<ApplicationUser> roleManager)
        {
            _roleManager = roleManager;
        }   
        public IActionResult Index()
        {
            return View();
        }
    }
}
