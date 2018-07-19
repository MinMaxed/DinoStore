using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ECommerse.Models;
using ECommerse.Models.Interfaces;
using ECommerse.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerse.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private IBasket _basketContext;


        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IBasket basketContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _basketContext = basketContext;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel rvm)
        {
            if (ModelState.IsValid)
            {

                List<Claim> claims = new List<Claim>();
                var user = new ApplicationUser
                {
                    UserName = rvm.Email,
                    Email = rvm.Email,
                    FirstName = rvm.FirstName,
                    LastName = rvm.LastName,
                    Birthday = rvm.Birthday
                };

                var result = await _userManager.CreateAsync(user, rvm.Password);

                ///if an account is successfully created, then this next chunk of code
                /// will make Claims for the user data to be used later
                /// for things like birthday discounts 
                if (result.Succeeded)
                {
                    Claim nameClaim = new Claim("FirstName", user.FirstName);
                    Claim birthdayClaim = new Claim(ClaimTypes.DateOfBirth,
                        new DateTime(user.Birthday.Year,
                        user.Birthday.Month,
                        user.Birthday.Day)
                        .ToString("u"),
                        ClaimValueTypes.DateTime);
                    Claim emailClaim = new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.Email);

                    claims.Add(nameClaim);
                    claims.Add(birthdayClaim);
                    claims.Add(emailClaim);

                    if (user.FirstName == "Amanda" && user.LastName == "Iverson")
                    {
                        claims.Add(new Claim("IsAmanda", "true"));
                    }

                    await _userManager.AddClaimsAsync(user, claims);

                    if (user.Email.Substring(user.Email.IndexOf('@')) == "@dinostore.com")
                    {
                        await _userManager.AddToRoleAsync(user, ApplicationRoles.Admin);
                    }

                    await _userManager.AddToRoleAsync(user, ApplicationRoles.Member);

                    await _signInManager.SignInAsync(user, false);
                     _basketContext.CreateBasket(user.Email);

                    return RedirectToAction("Index", "Home");
                }
            }
            return View(rvm);
        }


        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel lvm)
        {
            if(ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(lvm.Email, lvm.Password, false, false);

                if (result.Succeeded)
                {
                    bool test = _signInManager.IsSignedIn(User);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Enter in your credentials");
                }

            }
            return View(lvm);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            TempData["LoggedOut"] = "User has successfully logged out";

            return RedirectToAction("Index", "Home");
        }

        //public IActionResult ExternalLogin(string provider)
        //{
        //    var redirectUrl = Url.Action(nameof(ExternalLoginCallback), "Account");
        //    var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
        //    return Challenge(properties, provider);
        //}

        //[HttpGet]
        //[AllowAnonymous]
        //public async Task<IActionResult> ExternalLoginCallback(string remoteError = null)
        //{
        //    if (remoteError != null)
        //    {
        //        TempData["ErrorMessage"] = "Error from provider";
        //        return RedirectToAction(nameof(Login));
        //    }

        //    //check if the web supports external async
        //    var info = await _signInManager.GetExternalLoginInfoAsync();

        //    if (info == null)
        //    {
        //        return RedirectToAction(nameof(Login));
        //    }

        //    //if the above isnt true, use external log in
        //    var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey,
        //        isPersistent: false, bypassTwoFactor: true);

        //    if(result.Succeeded)
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }

        //    var email = info.Principal.FindFirstValue(ClaimTypes.Email);

        //    return View("ExternalLogin", new ExternalLoginViewModel { Email = email });
        //}



    }
}