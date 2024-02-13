using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AplicatieProiect.Data;
using AplicatieProiect.Models;
using Microsoft.AspNetCore.Authorization;

namespace AplicatieProiect.Pages.Pachete
{
    [Authorize(Roles = "Admin")]

    public class DeleteModel : PageModel
    {
        private readonly AplicatieProiect.Data.AplicatieProiectContext _context;

        public DeleteModel(AplicatieProiect.Data.AplicatieProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Pachet Pachet { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Pachet == null)
            {
                return NotFound();
            }

            var pachet = await _context.Pachet.FirstOrDefaultAsync(m => m.ID == id);

            if (pachet == null)
            {
                return NotFound();
            }
            else 
            {
                Pachet = pachet;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Pachet == null)
            {
                return NotFound();
            }
            var pachet = await _context.Pachet.FindAsync(id);

            if (pachet != null)
            {
                Pachet = pachet;
                _context.Pachet.Remove(Pachet);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
