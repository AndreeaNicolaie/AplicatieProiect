using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AplicatieProiect.Data;
using AplicatieProiect.Models;
using Microsoft.AspNetCore.Authorization;

namespace AplicatieProiect.Pages.Restaurante
{
    [Authorize(Roles = "Admin")]

    public class CreateModel : PageModel
    {
        private readonly AplicatieProiect.Data.AplicatieProiectContext _context;

        public CreateModel(AplicatieProiect.Data.AplicatieProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Restaurant Restaurant { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Restaurant == null || Restaurant == null)
            {
                return Page();
            }

            _context.Restaurant.Add(Restaurant);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
