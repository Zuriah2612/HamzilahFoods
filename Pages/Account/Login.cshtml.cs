using HamzilahFoods.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HamzilahFoods.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public LoginUser Input { get; set; }
        private readonly SignInManager<ApplicationUser> _signInManager;
        public LoginModel(SignInManager<ApplicationUser> signInManager)
        {
         _signInManager = signInManager;
        }
        public async Task<IActionResult> OnPostAsync()

        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    if (User.IsInRole("Admin"))
                    {
                        return RedirectToPage("/Admin/Index");
                    }
                    else 
                    { 
                        return RedirectToPage("/Menu");
                    }           
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
            }
            // If we got this far, something failed, redisplay form

            return Page();

        }
    }
}