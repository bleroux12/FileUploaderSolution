using FileUploader.Core.Domain.Entities;
using FileUploader.Core.Domain.RepositoryContracts;
using FileUploader.Core.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FileUploader.UI.Controllers
{
    [Authorize(Roles = "Admin,SuperUser")]
    public class UserManagementController : Controller
    {

        private readonly IUserRepository _ur;
        private readonly UserManager<IdentityUser> _um;

        public UserManagementController(IUserRepository ur, UserManager<IdentityUser> um)
        {
            _ur = ur;
            _um = um;
        }
        
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var users = await _ur.GetAll();
            var usersViewModel = new UserViewModel();
            usersViewModel.Users = new List<User>();

            foreach (var user in users)
            {
                usersViewModel.Users.Add(new User
                {
                    Id = Guid.Parse(user.Id),
                    Username = user.UserName,
                    Email = user.Email
                });
            }

            return View(usersViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> List(UserViewModel request)
        {
            var identityUser = new IdentityUser
            {
                UserName = request.Username,
                Email = request.Email,
            };

            var identityResult = await _um.CreateAsync(identityUser, request.Password);

            if (identityResult != null)
            {
                if (identityResult.Succeeded)
                {
                    var roles = new List<string> { "User" };
                    if (request.IsAdmin)
                    {
                        roles.Add("Admin");
                        roles.Add("SuperUser");
                    }
                    else if (request.IsSuperUser)
                    {
                        roles.Add("SuperUser");
                    }

                    identityResult = await _um.AddToRolesAsync(identityUser, roles);

                    if (identityResult != null && identityResult.Succeeded)
                    {
                        return RedirectToAction("List", "Account");
                    }
                }
            }

            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var user = await _um.FindByIdAsync(id.ToString());

            if (user != null)
            {
                var identityResult = await _um.DeleteAsync(user);

                if (identityResult != null && identityResult.Succeeded)
                {
                    return RedirectToAction("List", "UserManagement");
                }
            }
            
            return RedirectToAction("List", "UserManagement");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            bool isAdmin = false;
            bool isSuperUser = false;
            var user = await _um.FindByIdAsync(id.ToString());
            if (user != null)
            {
                var userRoles = await _um.GetRolesAsync(user);
                if (userRoles != null)
                {
                    foreach(var role in userRoles)
                    {
                        if (role == "Admin")
                        {
                            isSuperUser = true;
                            isAdmin = true;
                        }
                        else if (role == "SuperUser")
                        {
                            isSuperUser = true;
                        }
                    }
                }

                var userEditResponse = new UserEditResponse
                {
                    Id = id,
                    Username = user.UserName,
                    Email = user.Email,
                    IsAdmin = isAdmin,
                    IsSuperUser = isSuperUser
                };

                return View(userEditResponse);
            }

            return RedirectToAction("List", "UserManagement");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserEditResponse userEditResponse)
        {
            var existingUser = await _um.FindByIdAsync(userEditResponse.Id.ToString());
            if (existingUser != null)
            {
                //Update user record
                existingUser.UserName = userEditResponse.Username;
                existingUser.Email = userEditResponse.Email;
                await _um.UpdateAsync(existingUser);

                //Update user roles
                var roles = await _um.GetRolesAsync(existingUser);
                List<string> rolesToBeAdded = new List<string>();
                rolesToBeAdded.Add("User");

                var result = await _um.RemoveFromRolesAsync(existingUser, roles);

                if (!result.Succeeded)
                {
                    return View(userEditResponse);
                }

                if (userEditResponse.IsAdmin)
                {
                    rolesToBeAdded.Add("SuperUser");
                    rolesToBeAdded.Add("Admin");
                }
                else if (userEditResponse.IsSuperUser && !userEditResponse.IsAdmin)
                {
                    rolesToBeAdded.Add("SuperUser");
                }

                result = await _um.AddToRolesAsync(existingUser, rolesToBeAdded);
                if (!result.Succeeded)
                {
                    return View(userEditResponse);
                }

                return RedirectToAction("List", "UserManagement");
            }
            
            return View(userEditResponse);
        }

        [HttpGet]
        public IActionResult ChangePassword(Guid id)
        {
            UserManagementChangePasswordViewModel cpvm = new UserManagementChangePasswordViewModel()
            {
                Id = id
            };
            return View(cpvm);
        }
        
        [HttpPost]
        public async Task<IActionResult> ChangePassword(UserManagementChangePasswordViewModel cpvm)
        {
            if (ModelState.IsValid)
            {
                var user = await _um.FindByIdAsync(cpvm.Id.ToString());
                if (user == null)
                {
                    return View(cpvm);
                }
                string resetToken = await _um.GeneratePasswordResetTokenAsync(user);
                IdentityResult passwordChangeResult = await _um.ResetPasswordAsync(user, resetToken, cpvm.Password);
                if (passwordChangeResult.Succeeded)
                {
                    TempData["Message"] = "Password changed successfully";
                    return RedirectToAction("Edit", "UserManagement", new { id = user.Id });
                }
                ViewBag.Error = "Password entered was invalid please ensure that password is at least 6 characters in length, " +
                    "has 1 wild card character, 1 upper case character and one lower case character";
            }

            return View(cpvm);
        }
    }
}
