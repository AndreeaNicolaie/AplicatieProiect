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

namespace AplicatieProiect.Pages.Detalii
{
    public class EditModel : PageModel
    {
        private readonly AplicatieProiect.Data.AplicatieProiectContext _context;

        public EditModel(AplicatieProiect.Data.AplicatieProiectContext context)
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

            var detali =  await _context.Detali.FirstOrDefaultAsync(m => m.ID == id);
            if (detali == null)
            {
                return NotFound();
            }
            Detali = detali;
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

            _context.Attach(Detali).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetaliExists(Detali.ID))
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

        private bool DetaliExists(int id)
        {
          return (_context.Detali?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
