using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Palacian_Ioana_Teodora_proiect.Data;
using Palacian_Ioana_Teodora_proiect.Models;

namespace Palacian_Ioana_Teodora_proiect.Pages.Distribuitors
{
    public class IndexModel : PageModel
    {
        private readonly Palacian_Ioana_Teodora_proiect.Data.Palacian_Ioana_Teodora_proiectContext _context;

        public IndexModel(Palacian_Ioana_Teodora_proiect.Data.Palacian_Ioana_Teodora_proiectContext context)
        {
            _context = context;
        }

        public IList<Distribuitor> Distribuitor { get;set; }

        public async Task OnGetAsync()
        {
            Distribuitor = await _context.Distribuitor.ToListAsync();
        }
    }
}
