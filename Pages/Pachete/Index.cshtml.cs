using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AplicatieProiect.Data;
using AplicatieProiect.Models;

namespace AplicatieProiect.Pages.Pachete
{
    public class IndexModel : PageModel
    {
        private readonly AplicatieProiect.Data.AplicatieProiectContext _context;

        public IndexModel(AplicatieProiect.Data.AplicatieProiectContext context)
        {
            _context = context;
        }

        public IList<Pachet> Pachet { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Pachet != null)
            {
                Pachet = await _context.Pachet.ToListAsync();
            }
        }
    }
}
