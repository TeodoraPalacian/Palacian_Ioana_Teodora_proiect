using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Palacian_Ioana_Teodora_proiect.Data;
using Palacian_Ioana_Teodora_proiect.Models;

namespace Palacian_Ioana_Teodora_proiect.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly Palacian_Ioana_Teodora_proiect.Data.Palacian_Ioana_Teodora_proiectContext _context;

        public DetailsModel(Palacian_Ioana_Teodora_proiect.Data.Palacian_Ioana_Teodora_proiectContext context)
        {
            _context = context;
        }

        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Product.FirstOrDefaultAsync(m => m.ID == id);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
