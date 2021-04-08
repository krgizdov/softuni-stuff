using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SecurityAndIdentityDemo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityAndIdentityDemo.Controllers
{
    public class TestController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public TestController(
            UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        public async Task<IActionResult> Test()
        {
            //var result = await this.userManager.CreateAsync(new ApplicationUser
            //{
            //    Email = "test@abv.bg",
            //    UserName = "test",
            //    EmailConfirmed = true,
            //    PhoneNumber = "1234567890",
            //    FullName = "Test Testov",
            //}, "test123!");

            //await this.signInManager.SignOutAsync();

            //var result1 = await this.signInManager.PasswordSignInAsync("test@abv.bg", "test123!", true, true);

            var user = await this.userManager.GetUserAsync(this.User);

            var result = await this.roleManager.CreateAsync(new IdentityRole
            {
                Name = "Admin"
            });

            var addToRole = await this.userManager.AddToRoleAsync(user, "Admin");

            return Json(addToRole);
        }
    }
}
