using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TrackAnalyser.Models.ViewModels;

namespace TrackAnalyser.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult ExceptionError()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("/Error/{statusCode}")]
        public IActionResult Error(int statusCode)
        {
            switch(statusCode)
            {
                case 404:
                    ViewData["ErrorMessage"] = "Page not found.";
                    break;
                default:
                    ViewData["ErrorMessage"] = "Unknown error occurred while processing your task.";
                    break;
            }
         
            return View();
        }
    }
}
