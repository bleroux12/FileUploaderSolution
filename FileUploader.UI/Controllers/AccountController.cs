using FileUploader.Core.Domain.RepositoryContracts;
using FileUploader.Core.DTO;
using FileUploader.Core.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace FileUploader.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _um;
        private readonly SignInManager<IdentityUser> _sm;

        public AccountController(UserManager<IdentityUser> um, SignInManager<IdentityUser> sm)
        {
            _um = um;
            _sm = sm;
        }

        [HttpGet]
        public IActionResult Login(string ReturnUrl)
        {
            var model = new LoginViewModel
            {
                ReturnUrl = ReturnUrl,
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var signinResult = await _sm.PasswordSignInAsync(login.Username, login.Password, false, false);

            if (signinResult != null && signinResult.Succeeded)
            {
                if (!string.IsNullOrEmpty(login.ReturnUrl))
                {
                    return Redirect(login.ReturnUrl);
                }

                return RedirectToAction("Dashboard", "UploadFile");
            }
            ViewBag.Error = "Username or password is incorrect";
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _sm.SignOutAsync();
            return RedirectToAction("Dashboard", "UploadFile");
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> ViewProfile()
        {
            var user = await _um.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewProfileViewModel vpvm = new ViewProfileViewModel
            {
                Id = Guid.Parse(user.Id),
                Username = user.UserName,
                Email = user.Email
            };

            return View(vpvm);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ViewProfile(ViewProfileViewModel vpvm)
        {
            var existingUser = await _um.FindByIdAsync(vpvm.Id.ToString());
            if (existingUser != null)
            {
                existingUser.UserName = vpvm.Username;
                existingUser.Email = vpvm.Email;
                var result = await _um.UpdateAsync(existingUser);
                if (result.Succeeded)
                {
                    return RedirectToAction("Dashboard", "UploadFile");
                }
            }

            return View(vpvm);
        }

        [Authorize]
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ChangePassword(AccountChangePasswordViewModel acpvm)
        {
            if (!ModelState.IsValid)
            {
                return View(acpvm);
            }

            var user = await _um.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var result = await _um.ChangePasswordAsync(user, acpvm.OldPassword, acpvm.NewPassword);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }

            await _sm.RefreshSignInAsync(user);

            return RedirectToAction("Dashboard", "UploadFile");
        }
    }
}
