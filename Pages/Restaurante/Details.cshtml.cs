using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AplicatieProiect.Data;
using AplicatieProiect.Models;

namespace AplicatieProiect.Pages.Restaurante
{
    public class DetailsModel : PageModel
    {
        private readonly AplicatieProiect.Data.AplicatieProiectContext _context;

        public DetailsModel(AplicatieProiect.Data.AplicatieProiectContext context)
        {
            _context = context;
        }

      public Restaurant Restaurant { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Restaurant == null)
            {
                return NotFound();
            }

            var restaurant = await _context.Restaurant.FirstOrDefaultAsync(m => m.ID == id);
            if (restaurant == null)
            {
                return NotFound();
            }
            else 
            {
                Restaurant = restaurant;
            }
            return Page();
        }
    }
}
