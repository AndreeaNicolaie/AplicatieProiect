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
    public class IndexModel : PageModel
    {
        private readonly AplicatieProiect.Data.AplicatieProiectContext _context;

        public IndexModel(AplicatieProiect.Data.AplicatieProiectContext context)
        {
            _context = context;
        }

        public IList<Detali> Detali { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Detali != null)
            {
                Detali = await _context.Detali.ToListAsync();
            }
        }
    }
}
