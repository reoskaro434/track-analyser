using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PasswordGenerator;
using System.Linq;
using System.Threading.Tasks;
using TrackAnalyser.DataAccess.RepositoryPattern;
using TrackAnalyser.Models.DBModels;
using TrackAnalyser.Models.ViewModels.UserManagementViewModel;
using TrackAnalyser.Utilities;
using TrackAnalyser.Utilities.EmailSender;

namespace TrackAnalyser.Controllers
{
    [Authorize(Roles = StaticDetails.ROLE_ADMIN)]
    public class UserManagementController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailSender _emailSender;

        public UserManagementController(
            UserManager<ApplicationUser> userManager,
            IUnitOfWork unitOfWork,
            IEmailSender emailSender
            )
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _emailSender = emailSender;
        }

        private async Task<UserManagementViewModel> GetUsers()
        {
            var users = await _userManager.GetUsersInRoleAsync(StaticDetails.ROLE_USER);

            return new UserManagementViewModel() {
                UserEmails = users.Select(p => p.Email).ToList()
            };
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(string newUserEmail)
        {
            if(ModelState.IsValid)
            {
                string password = new Password()
                    .IncludeSpecial()
                    .IncludeNumeric()
                    .IncludeUppercase()
                    .IncludeLowercase().Next();

                var user = new ApplicationUser() {Email = newUserEmail, UserName = newUserEmail};

                //user with fake email will also be created
                var result =  await _userManager.CreateAsync(user, password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, StaticDetails.ROLE_USER);
                    await _emailSender.SendEmailAsync(newUserEmail, password);

                    TempData["Message"] = StaticDetails.MESSAGE;

                }
                else
                { 
                    ModelState.AddModelError(string.Empty, "Cannot add user, try different email.");
                    return View("Index",await GetUsers());
                }
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteUser(string userEmail)
        {
            var tmpUser = _unitOfWork.ApplicationUsers.Find(p => p.Email == userEmail).FirstOrDefault();
            await _userManager.DeleteAsync(tmpUser);

            return RedirectToAction("Index");

        }
        [HttpPost]
        public async Task<IActionResult> EditUser(string email, string newEmail)
        {
            var tmpUser = _unitOfWork.ApplicationUsers.Find(p => p.Email == email).FirstOrDefault();
            tmpUser.Email = newEmail;
            tmpUser.UserName = newEmail;

            await _userManager.UpdateAsync(tmpUser);

            return RedirectToAction("Index");
           
        }
        public async Task<IActionResult> Index()
        {   
            return View(await GetUsers());
        }

    }
}
