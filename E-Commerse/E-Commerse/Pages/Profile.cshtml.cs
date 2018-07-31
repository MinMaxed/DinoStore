using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ECommerse.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerse.Pages
{
    [Authorize]
    public class ProfileModel : PageModel
    {

        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private List<Order> Orders { get; set; }

        [BindProperty]
        public string FirstName { get; set; }
        [BindProperty]
        public string LastName { get; set; }
        [BindProperty]
        public string Email { get; set; }

        public ProfileModel(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task OnGet()
        {
            var user = await _userManager.GetUserAsync(User);

            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
        }

        public async Task<IActionResult> OnPost()
        {
            var user = await _userManager.GetUserAsync(User);

            user.FirstName = FirstName;
            user.LastName = LastName;

            await _userManager.UpdateAsync(user);

            Claim claim = User.Claims.First(c => c.Type == "FullName");
            Claim newClaim = new Claim("FullName", $"{user.FirstName} {user.LastName}");

            await _userManager.RemoveClaimAsync(user, claim);
            await _userManager.AddClaimAsync(user, newClaim);

            await _signInManager.SignOutAsync();
            await _signInManager.SignInAsync(user, false);

            return Page();
        }
    }
}