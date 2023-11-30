using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DechkoWebApp.Data;
using DechkoWebApp.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace DechkoWebApp.Infrastructure
{
    public static class ApplicationBuilderExtension
    {
        public static async Task<IApplicationBuilder> PrepareDatabase(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();

            var services = serviceScope.ServiceProvider;

            await RoleSeeder(services);
            await SeedAdministrator(services);

            var dataCategory = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            SeedCategories(dataCategory);

            var dataBrand = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            SeedBrands(dataBrand);

            return app;
        }

        private static void SeedBrands(ApplicationDbContext dataBrand)
        {
            if (dataBrand.Brands.Any())
            {
                return;
            }
            dataBrand.Brands.AddRange(new[]
            {
                new Brand {Name= "Barbie"},
                new Brand {Name= "Lego"},
                new Brand {Name= "Disney"},
                new Brand {Name= "Fisher price"},
                new Brand {Name= "Thinkle stars"},
                new Brand {Name= "Hot wheels"}
            });
            dataBrand.SaveChanges();
        }

        private static void SeedCategories(ApplicationDbContext dataCategory)
        {
            if (dataCategory.Categories.Any())
            {
                return;
            }
            dataCategory.Categories.AddRange(new[]
            {
                new Category {Name = "Dolls"},
                new Category {Name = "Constructors"},
                new Category {Name = "Stuff toys"},
                new Category {Name = "Baby toys"},
                new Category {Name = "Interactive toys"},
                new Category {Name = "Board games"},
                new Category {Name = "Cars"},
                new Category {Name = "Balls"}
            });
            dataCategory.SaveChanges();
        }

        private static async Task SeedAdministrator(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            if (await userManager.FindByNameAsync("admin") == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.FirstName = "admin";
                user.LastName = "admin";
                user.PhoneNumber = "09994573219";
                user.UserName = "admin";
                user.Email = "stankova.mail@mail.bg";

                var result = await userManager.CreateAsync(user, "Admin123456");


                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }

            }
        }

        private static async Task RoleSeeder(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string[] roleNames = {"Administrator", "Client" };

            IdentityResult roleResult;
            foreach (var role in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(role);

                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
    }
}
