using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WEB_953504_KARMYZOW.Entities;

namespace WEB_953504_KARMYZOW.Data
{
    public class DbInitializer
    {
        public static async Task
        Seed(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager
        )
        {
            // создать БД, если она еще не создана
            context.Database.EnsureCreated();

            // проверка наличия ролей
            if (!context.Roles.Any())
            {
                var roleAdmin =
                    new IdentityRole {
                        Name = "admin",
                        NormalizedName = "admin"
                    };

                // создать роль admin
                await roleManager.CreateAsync(roleAdmin);
            }

            // проверка наличия пользователей
            if (!context.Users.Any())
            {
                // создать пользователя user@mail.ru
                var user =
                    new ApplicationUser {
                        Email = "user@mail.ru",
                        UserName = "user@mail.ru"
                    };
                await userManager.CreateAsync(user, "123456");

                // создать пользователя admin@mail.ru
                var admin =
                    new ApplicationUser {
                        Email = "admin@mail.ru",
                        UserName = "admin@mail.ru"
                    };
                await userManager.CreateAsync(admin, "123456");

                // назначить роль admin
                admin = await userManager.FindByEmailAsync("admin@mail.ru");
                await userManager.AddToRoleAsync(admin, "admin");
            }

            //проверка наличия групп объектов
            if (!context.GameGroups.Any())
            {
                context
                    .GameGroups
                    .AddRange(new List<GameGroup> {
                        new GameGroup { GroupName = "Thief" },
                        new GameGroup { GroupName = "Fallout" }
                    });
                await context.SaveChangesAsync();
            }

            // проверка наличия объектов
            if (!context.Games.Any())
            {
                context
                    .Games
                    .AddRange(new List<Game> {
                        new Game {
                            Name = "Thief Gold",
                            Description =
                                "Thief: The Dark Project is a 1998 first-person stealth video game developed by Looking Glass Studios and published by Eidos Interactive. ",
                            Rating = 10,
                            GameGroupId = 1,
                            Image = "thief1.jpg"
                        },
                        new Game {
                            Name = "Thief II: The Metal Age",
                            Description =
                                "Thief II: The Metal Age is a 2000 stealth video game developed by Looking Glass Studios and published by Eidos Interactive. ",
                            Rating = 9,
                            GameGroupId = 1,
                            Image = "thief2.jpg"
                        },
                        new Game {
                            Name = "Thief: Deadly Shadows",
                            Description =
                                "Thief: Deadly Shadows is a stealth video game developed by Ion Storm for Microsoft Windows and Xbox ",
                            Rating = 8,
                            GameGroupId = 1,
                            Image = "thief3.jpg"
                        },
                        new Game {
                            Name = "Fallout 1",
                            Description =
                                "Fallout: A Post Nuclear Role Playing Game, more commonly known as Fallout or Fallout 1, is a turn-based role-playing video game developed and published by Interplay Productions in 1997. ",
                            Rating = 9,
                            GameGroupId = 2,
                            Image = "fallout1.jpg"
                        },
                        new Game {
                            Name = "Fallout 2",
                            Description =
                                "Fallout 2: A Post Nuclear Role Playing Game is a turn-based role-playing open world video game developed by Black Isle Studios.",
                            Rating = 12,
                            GameGroupId = 2,
                            Image = "fallout2.jpg"
                        }
                    });
                await context.SaveChangesAsync();
            }
        }
    }
}
