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
    public class DetailsModel : PageModel
    {
        private readonly WEB_953504_KARMYZOW.Data.ApplicationDbContext _context;

        public DetailsModel(WEB_953504_KARMYZOW.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Game Game { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Game = await _context.Games
                .Include(g => g.Group).FirstOrDefaultAsync(m => m.Id == id);

            if (Game == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
