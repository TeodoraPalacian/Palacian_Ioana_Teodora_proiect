using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Palacian_Ioana_Teodora_proiect.Models;

namespace Palacian_Ioana_Teodora_proiect.Data
{
    public class Palacian_Ioana_Teodora_proiectContext : DbContext
    {
        public Palacian_Ioana_Teodora_proiectContext (DbContextOptions<Palacian_Ioana_Teodora_proiectContext> options)
            : base(options)
        {
        }

        public DbSet<Palacian_Ioana_Teodora_proiect.Models.Product> Product { get; set; }

        public DbSet<Palacian_Ioana_Teodora_proiect.Models.Distribuitor> Distribuitor { get; set; }

        public DbSet<Palacian_Ioana_Teodora_proiect.Models.Category> Category { get; set; }
    }
}
