using Microsoft.AspNetCore.Mvc;
using MyFirstAspNetCoreApp.Services;
using MyFirstAspNetCoreApp.ViewModels.NavBar;

namespace MyFirstAspNetCoreApp.ViewComponents
{
    [ViewComponent(Name = "NavBar")]
    public class NavBarViewComponent : ViewComponent
    {
        private readonly IYearsService yearsService;

        public NavBarViewComponent(IYearsService yearsService)
        {
            this.yearsService = yearsService;
        }

        public IViewComponentResult Invoke(int count)
        {
            var viewModel = new NavBarViewModel
            {
                Years = yearsService.GetLastYears(count)
            };

            return this.View(viewModel);
        }
    }
}
