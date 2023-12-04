using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AplicatieProiect.Data;
using AplicatieProiect.Models;

namespace AplicatieProiect.Pages.Detalii
{
    public class DetailsModel : PageModel
    {
        private readonly AplicatieProiect.Data.AplicatieProiectContext _context;

        public DetailsModel(AplicatieProiect.Data.AplicatieProiectContext context)
        {
            _context = context;
        }

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
    }
}
