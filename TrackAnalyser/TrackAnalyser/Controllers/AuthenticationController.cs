using Microsoft.AspNetCore.Mvc;

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
