using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TrackAnalyser.Models.DBModels;
using TrackAnalyser.Utilities;

namespace TrackAnalyser.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManeger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManeger;
        }
        public async Task<IActionResult> Index()
        {
            if (!await _roleManager.RoleExistsAsync(StaticDetails.ROLE_ADMIN))
            { 
                await _roleManager.CreateAsync(new IdentityRole(StaticDetails.ROLE_ADMIN));

                ApplicationUser admin = new ApplicationUser() {
                    Email = "admin@gmail.com",
                    UserName = "Admin"
                };

                await _userManager.CreateAsync(admin,"Admin123*");
                await _userManager.AddToRoleAsync(admin, StaticDetails.ROLE_ADMIN);


            }
            if (!await _roleManager.RoleExistsAsync(StaticDetails.ROLE_USER))
                await _roleManager.CreateAsync(new IdentityRole(StaticDetails.ROLE_USER));



            return RedirectToAction("Index","Home");
        }
    }
}
