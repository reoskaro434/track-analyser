using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TrackAnalyser.DataAccess.RepositoryPattern;
using TrackAnalyser.Models.DBModels;
using TrackAnalyser.Models.ViewModels.LoginViewModel;
using TrackAnalyser.Utilities.DataInitializer;

namespace TrackAnalyser.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IDataInitializer<IUnitOfWork> _dataInitializer;
        public LoginController(
            IUnitOfWork unitOfWork,
            SignInManager<ApplicationUser> signInManager,
            IDataInitializer<IUnitOfWork> dataInitializer)
        {
            _unitOfWork = unitOfWork;
            _signInManager = signInManager;
            _dataInitializer = dataInitializer;
        }

        public IActionResult Index()
        {
            _dataInitializer.SetDatabase();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
               ApplicationUser user = _unitOfWork.ApplicationUsers.Find(p => p.Email == model.Email).FirstOrDefault();
               
               var result =  await _signInManager.PasswordSignInAsync(user,model.Password, isPersistent: false,false);

                if (result.Succeeded)
                    return RedirectToAction("Index", "BroadcastList");
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View("Index");
                }
            }
            return View("Index");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index");
        }
    }
}
