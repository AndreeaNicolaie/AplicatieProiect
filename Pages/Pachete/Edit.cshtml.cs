using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AplicatieProiect.Data;
using AplicatieProiect.Models;
using Microsoft.AspNetCore.Authorization;

namespace AplicatieProiect.Pages.Pachete
{
    [Authorize(Roles = "Admin")]

    public class EditModel : PageModel
    {
        private readonly AplicatieProiect.Data.AplicatieProiectContext _context;

        public EditModel(AplicatieProiect.Data.AplicatieProiectContext context)
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

            var pachet =  await _context.Pachet.FirstOrDefaultAsync(m => m.ID == id);
            if (pachet == null)
            {
                return NotFound();
            }
            Pachet = pachet;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Pachet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PachetExists(Pachet.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PachetExists(int id)
        {
          return (_context.Pachet?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
