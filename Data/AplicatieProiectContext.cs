using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AplicatieProiect.Models;

namespace AplicatieProiect.Data
{
    public class AplicatieProiectContext : DbContext
    {
        public AplicatieProiectContext (DbContextOptions<AplicatieProiectContext> options)
            : base(options)
        {
        }

        public DbSet<AplicatieProiect.Models.Client> Client { get; set; } = default!;

        public DbSet<AplicatieProiect.Models.Contact>? Contact { get; set; }

        public DbSet<AplicatieProiect.Models.Detali>? Detali { get; set; }

        public DbSet<AplicatieProiect.Models.Pachet>? Pachet { get; set; }

        public DbSet<AplicatieProiect.Models.Restaurant>? Restaurant { get; set; }
    }
}
