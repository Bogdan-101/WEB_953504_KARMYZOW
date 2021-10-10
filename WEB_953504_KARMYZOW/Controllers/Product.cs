using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WEB_953504_KARMYZOW.Models;

namespace WEB_953504_KARMYZOW.Controllers
{
    public class ProductController : Controller
    {
        List<Game> _games;

        List<GameGroup> _gameGroups;

        int _pageSize;

        public ProductController()
        {
            _pageSize = 3;
            SetupData();
        }

        public IActionResult Index(int? group, int pageNo = -1)
        {
            var gamesFiltered =
                _games
                    .Where(d =>
                        !group.HasValue || d.GameGroupId == group.Value);
            ViewData["Groups"] = _gameGroups;
            ViewData["CurrentGroup"] = group ?? 0;
            return View(ListViewModel<Game>
                .GetModel(gamesFiltered, pageNo, _pageSize));
        }

        /// <summary>
        /// Инициализация списков
        /// </summary>
        private void SetupData()
        {
            _gameGroups =
                new List<GameGroup> {
                    new GameGroup { GameGroupId = 1, GroupName = "Thief" },
                    new GameGroup { GameGroupId = 2, GroupName = "Fallout" }
                };

            _games =
                new List<Game> {
                    new Game {
                        Id = 1,
                        Name = "Thief Gold",
                        Description =
                            "Thief: The Dark Project is a 1998 first-person stealth video game developed by Looking Glass Studios and published by Eidos Interactive. ",
                        Rating = 10,
                        GameGroupId = 1,
                        Image = "thief1.jpg"
                    },
                    new Game {
                        Id = 2,
                        Name = "Thief II: The Metal Age",
                        Description =
                            "Thief II: The Metal Age is a 2000 stealth video game developed by Looking Glass Studios and published by Eidos Interactive. ",
                        Rating = 9,
                        GameGroupId = 1,
                        Image = "thief2.jpg"
                    },
                    new Game {
                        Id = 3,
                        Name = "Thief: Deadly Shadows",
                        Description =
                            "Thief: Deadly Shadows is a stealth video game developed by Ion Storm for Microsoft Windows and Xbox ",
                        Rating = 8,
                        GameGroupId = 1,
                        Image = "thief3.jpg"
                    },
                    new Game {
                        Id = 4,
                        Name = "Fallout 1",
                        Description =
                            "Fallout: A Post Nuclear Role Playing Game, more commonly known as Fallout or Fallout 1, is a turn-based role-playing video game developed and published by Interplay Productions in 1997. ",
                        Rating = 9,
                        GameGroupId = 2,
                        Image = "fallout1.jpg"
                    },
                    new Game {
                        Id = 5,
                        Name = "Fallout 2",
                        Description =
                            "Fallout 2: A Post Nuclear Role Playing Game is a turn-based role-playing open world video game developed by Black Isle Studios.",
                        Rating = 12,
                        GameGroupId = 2,
                        Image = "fallout2.jpg"
                    }
                };
        }
    }
}
