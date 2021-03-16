using ConsultationDayDemo.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace ConsultationDayDemo.SeedData
{
    public class ApplicationDbContextSeeder
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;


        public ApplicationDbContextSeeder(IServiceProvider serviceProvider, ApplicationDbContext dbContext)
        {
            userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            this.dbContext = dbContext;
        }

        public async Task SeedDataAsync()
        {
            await SeedRolesAsnyc();
            await SeedUsersAsnyc();
            await SeedUserToRolesAsnyc();
        }

        private async Task SeedUserToRolesAsnyc()
        {
            var user = await userManager.FindByNameAsync("Pesho");
            var role = await roleManager.FindByNameAsync("Admin");

            var exists = await dbContext.UserRoles.AnyAsync(x => x.UserId == user.Id && x.RoleId == role.Id);

            if (exists)
            {
                return;
            }

            await dbContext.UserRoles.AddAsync(new IdentityUserRole<string>
            {
                UserId = user.Id,
                RoleId = role.Id
            });

            await dbContext.SaveChangesAsync();
        }

        private async Task SeedUsersAsnyc()
        {
            var exists = await userManager.FindByNameAsync("Pesho");

            if (exists != null)
            {
                return;
            }

            await userManager.CreateAsync(new IdentityUser
            {
                UserName = "Pesho",
                Email = "pesho@abv.bg",
                EmailConfirmed = true
            },
             "123456");
        }

        private async Task SeedRolesAsnyc()
        {
            var role = await roleManager.FindByNameAsync("Admin");

            if (role != null)
            {
                return;
            }

            await roleManager.CreateAsync(new IdentityRole
            {
                Name = "Admin"
            });
        }
    }
}
