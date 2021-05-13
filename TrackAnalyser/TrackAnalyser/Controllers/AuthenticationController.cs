using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrackAnalyser.Controllers
{
    public class AuthenticationController : Controller
    {
        public IActionResult RedirectToLoginPage()
        {
            return RedirectToAction("Index","Login");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
