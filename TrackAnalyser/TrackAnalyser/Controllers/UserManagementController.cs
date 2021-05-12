using MailKit.Net.Smtp;
using MailKit.Security;
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


namespace TrackAnalyser.Controllers
{
    public class UserManagementController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUnitOfWork _unitOfWork;

        public UserManagementController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManeger,
            IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManeger;
            _unitOfWork = unitOfWork;
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

                    // create email message
                    var email = new MimeMessage();
                    email.From.Add(MailboxAddress.Parse("ostroznykupiec@gmail.com"));
                    email.To.Add(MailboxAddress.Parse(newUser.NewUserEmail));
                    email.Subject = "Track Analyser Password";
                    email.Body = new TextPart(TextFormat.Plain) {
                        Text = "Thank you for registering, here's your password: "+
                        password
                    };

                    // send email
                    using var smtp = new SmtpClient();
                    smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                    smtp.Authenticate("trackanalyser21@gmail.com", "AAxwyz*hH");
                    smtp.Send(email);
                    smtp.Disconnect(true);
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
