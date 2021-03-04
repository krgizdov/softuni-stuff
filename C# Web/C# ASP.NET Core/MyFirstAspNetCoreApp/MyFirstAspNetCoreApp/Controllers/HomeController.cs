using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MyFirstAspNetCoreApp.Services;
using MyFirstAspNetCoreApp.ViewModels;
using MyFirstAspNetCoreApp.ViewModels.Home;

namespace MyFirstAspNetCoreApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly IStringManipulation manipulation;

        public HomeController(IConfiguration configuration, IStringManipulation manipulation)
        {
            this.configuration = configuration;
            this.manipulation = manipulation;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel
            {
                Message = this.configuration["YouTube:ApiKey"],
                Year = DateTime.UtcNow.Year,
                Names = new List<string> { "Krasi", "Jenny" }
            };

            viewModel.Message = manipulation.MakeFirstLetterUpper(viewModel.Message);
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Test()
        {
            return this.Content(this.configuration["YouTube:ApiKey"]);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
