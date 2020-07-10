using SIS.HTTP;
using SIS.MvcFramework;
using SulsApp.Models;
using SulsApp.Services;
using System;
using System.Net.Mail;

namespace SulsApp.Controllers
{
    public class UsersController : Controller
    {
        private IUsersService usersService;
        public UsersController()
        {
            this.usersService = new UsersService(new ApplicationDbContext());
        }
        public HttpResponse Login()
        {
            return this.View();
        }

        [HttpPost("/Users/Login")]
        public HttpResponse DoLogin()
        {
            return this.View();
        }

        public HttpResponse Register()
        {
            return this.View();
        }

        [HttpPost("/Users/Register")]
        public HttpResponse DoRegister()
        {
            var username = this.Request.FormData["username"];
            var email = this.Request.FormData["email"];
            var password = this.Request.FormData["password"];
            var confirmPassword = this.Request.FormData["confirmPassword"];

            if (password != confirmPassword)
            {
                return this.Error("Passwords should be the same!");
            }

            if (username?.Length < 5 || username?.Length > 20)
            {
                return this.Error("Username should be between 5 and 20 characters!");
            }

            if (password?.Length < 6 || password?.Length > 20)
            {
                return this.Error("Password should be between 6 and 20 characters!");
            }

            if (!IsValid(email))
            {
                return this.Error("Invalid email!");
            }

            this.usersService.CreateUser(username, email, password);
            var userId = this.usersService.GetUserId(username, password);
            this.SignIn(userId);

            return this.Redirect("/");
        }
        private bool IsValid(string emailaddress)
        {
            try
            {
                new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
