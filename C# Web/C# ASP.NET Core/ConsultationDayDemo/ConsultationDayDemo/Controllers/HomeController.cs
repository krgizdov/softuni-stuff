using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using ConsultationDayDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ConsultationDayDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Cloudinary cloudinary;

        public HomeController(ILogger<HomeController> logger,
            Cloudinary cloudinary)
        {
            _logger = logger;
            this.cloudinary = cloudinary;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Upload()
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(@"D:\image-analysis.png")
            };

            var uploadResult = await cloudinary.UploadAsync(uploadParams);

            return Redirect("/");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
