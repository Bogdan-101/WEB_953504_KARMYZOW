using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WEB_953504_KARMYZOW.Data;
using WEB_953504_KARMYZOW.Entities;
using WEB_953504_KARMYZOW.Extensions;
using WEB_953504_KARMYZOW.Models;

namespace WEB_953504_KARMYZOW.Controllers
{
    public class ProductController : Controller
    {
        ApplicationDbContext _context;

        int _pageSize;

        public ProductController(ApplicationDbContext context)
        {
            _pageSize = 3;
            _context = context;
        }

        [Route("Catalog")]
        [Route("Catalog/Page_{pageNo}")]
        public IActionResult Index(int? group, int pageNo = -1)
        {
            var gamesFiltered =
                _context
                    .Games
                    .Where(d =>
                        !group.HasValue || d.GameGroupId == group.Value);

            // Поместить список групп во ViewData
            ViewData["Groups"] = _context.GameGroups;
            ViewData["CurrentGroup"] = group ?? 0;

            var model =
                ListViewModel<Game>.GetModel(gamesFiltered, pageNo, _pageSize);
            if (Request.IsAjaxRequest())
                return PartialView("_listpartial", model);
            else
                return View(model);
        }
    }
}
