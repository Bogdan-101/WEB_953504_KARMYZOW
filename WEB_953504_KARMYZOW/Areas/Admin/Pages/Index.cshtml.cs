using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WEB_953504_KARMYZOW.Data;

namespace WEB_953504_KARMYZOW.Areas.Admin.Pages
{
    public class IndexModel : PageModel
    {
        private readonly WEB_953504_KARMYZOW.Data.ApplicationDbContext _context;

        public IndexModel(WEB_953504_KARMYZOW.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Game> Game { get;set; }

        public async Task OnGetAsync()
        {
            Game = await _context.Games
                .Include(g => g.Group).ToListAsync();
        }
    }
}
