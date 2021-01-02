using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using NutraZone.Models;
using NutraZone.ViewModels;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NutraZone.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private IEmailSender _emailSender;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }
        // GET: Account
        [HttpPost]
        public async Task<IActionResult> Login(LoginUser lvm)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(lvm.Email, lvm.Password, false, false);

                if (result.Succeeded)
                {                   
                    return RedirectToAction("Build", "Plan");
                }
            }
            ModelState.TryAddModelError(string.Empty, "Invalid Login Attempt");
            return View(lvm);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        // GET: Account/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Account/Create
        public ActionResult Create()
        {
            return View();
        }



        // GET: Account/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }


        // GET: Account/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUser rvm)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser()
                {

                    UserName = rvm.Email,
                    Email = rvm.Email,
                    FirstName = rvm.FirstName,
                    LastName = rvm.LastName,
                    Birthday = rvm.Birthday
                };

                var result = await _userManager.CreateAsync(user, rvm.Password);
                if (result.Succeeded)
                {
                    try
                    {
                        Claim fullNameClaim = new Claim("FullName", $"{user.FirstName} {user.LastName}");

                        Claim birthdayClaim = new Claim(ClaimTypes.DateOfBirth, new DateTime(user.Birthday.Year, user.Birthday.Month, user.Birthday.Day).ToString("u"),
                        ClaimValueTypes.DateTime);

                        Claim emailClaim = new Claim(ClaimTypes.Email, user.Email, ClaimTypes.Email);
                        List<Claim> claims = new List<Claim> { fullNameClaim, birthdayClaim, emailClaim };

                        await _userManager.AddClaimsAsync(user, claims);
                        await _signInManager.SignInAsync(user, isPersistent: false);

                        //Email edge
                        StringBuilder sb = new StringBuilder();
                        sb.Append("<h2>Congratulations on Registering, It is time to build an amazing body!</h2>");
                        sb.AppendLine("<p>This app is the new way of having recipes built for you at your convenience that fit your macros!</p>");
                        sb.AppendLine("<p>We hope this provides you an easy, new intuitive way to reach your goals!</p>");

                        await _emailSender.SendEmailAsync(rvm.Email, "Thank you for Registering with NutraZone!", sb.ToString());
                        var ourUser = await _userManager.FindByEmailAsync(rvm.Email);
                        string id = ourUser.Id;

                        //Adding Amanda to Admin role
                        if (user.Email == "regan.t.dufort@gmail.com")
                        {
                            await _userManager.AddToRoleAsync(user, ApplicationRoles.Admin);
                        }
                        //Will redirect to new page
                        return RedirectToAction("Build", "Plan");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return View(rvm);
                    }
                }
                else
                {
                    TempData["UserExists"] = "invalid";
                    return RedirectToAction("Landing", "Home");
                }

            }
           

            return View(rvm);
        }
    }
}