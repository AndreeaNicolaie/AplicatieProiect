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

namespace AplicatieProiect.Pages.Detalii
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
      public Detali Detali { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Detali == null)
            {
                return NotFound();
            }

            var detali = await _context.Detali.FirstOrDefaultAsync(m => m.ID == id);

            if (detali == null)
            {
                return NotFound();
            }
            else 
            {
                Detali = detali;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Detali == null)
            {
                return NotFound();
            }
            var detali = await _context.Detali.FindAsync(id);

            if (detali != null)
            {
                Detali = detali;
                _context.Detali.Remove(Detali);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
