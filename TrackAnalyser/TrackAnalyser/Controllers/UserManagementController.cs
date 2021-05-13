using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;
using PasswordGenerator;
using System;
using System.Collections.Generic;
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
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailSender _emailSender;

        public UserManagementController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManeger,
            IUnitOfWork unitOfWork,
            IEmailSender emailSender
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManeger;
            _unitOfWork = unitOfWork;
            _emailSender = emailSender;
        }
        private async Task<UserManagementViewModel> GetUsers()
        {
            var users = await _userManager.GetUsersInRoleAsync(StaticDetails.ROLE_USER);
            List<string> usersEmail = new List<string>();

            foreach (var u in users)
                usersEmail.Add(u.Email);

            return new UserManagementViewModel() { UserEmails = usersEmail };
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(NewUserDetailsViewModel newUser)
        {
            if(ModelState.IsValid)
            {
                string password = new Password()
                    .IncludeSpecial()
                    .IncludeNumeric()
                    .IncludeUppercase()
                    .IncludeLowercase().Next();

                var user = new ApplicationUser() {Email = newUser.NewUserEmail, UserName = newUser.NewUserEmail};

                var result =  await _userManager.CreateAsync(user, password);

                if(result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, StaticDetails.ROLE_USER);
                    await _emailSender.SendEmailAsync(newUser.NewUserEmail, password);
                }
            }

            return View("Index",await GetUsers());
        }

        [HttpGet]
        public async Task<IActionResult> DeleteUser(string userEmail)
        {
            var tmpUser = _unitOfWork.ApplicationUsers.Find(p => p.Email == userEmail).FirstOrDefault();
            await _userManager.DeleteAsync(tmpUser);

            return View("Index",await GetUsers());
        }
        [HttpPost]
        public async Task<IActionResult> EditUser(string email, string newEmail)
        {
            var tmpUser = _unitOfWork.ApplicationUsers.Find(p => p.Email == email).FirstOrDefault();
            tmpUser.Email = newEmail;

            await _userManager.UpdateAsync(tmpUser);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index","Home");
        }
        public async Task<IActionResult> Index()
        {
            return View(await GetUsers());
        }

    }
}
