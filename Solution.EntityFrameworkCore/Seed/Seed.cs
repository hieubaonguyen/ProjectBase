using Microsoft.AspNetCore.Identity;
using Solution.Core.Authentication;
using Solution.EntityFrameworkCore.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solution.EntityFrameworkCore.Seed
{
    public class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<ApplicationUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var users = new List<ApplicationUser>
                {
                    new ApplicationUser
                    {
                        DisplayName = "Bob",
                        UserName = "bob",
                        Email = "bob@test.com"
                    },
                    new ApplicationUser
                    {
                        DisplayName = "Jane",
                        UserName = "jane",
                        Email = "jane@test.com"
                    },
                    new ApplicationUser
                    {
                        DisplayName = "Tom",
                        UserName = "tom",
                        Email = "tom@test.com"
                    },
                };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                }
            }
        }
    }
}
