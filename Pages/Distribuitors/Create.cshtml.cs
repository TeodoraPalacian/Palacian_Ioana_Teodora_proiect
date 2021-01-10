using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Palacian_Ioana_Teodora_proiect.Data;
using Palacian_Ioana_Teodora_proiect.Models;

namespace Palacian_Ioana_Teodora_proiect.Pages.Distribuitors
{
    public class CreateModel : PageModel
    {
        private readonly Palacian_Ioana_Teodora_proiect.Data.Palacian_Ioana_Teodora_proiectContext _context;

        public CreateModel(Palacian_Ioana_Teodora_proiect.Data.Palacian_Ioana_Teodora_proiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Distribuitor Distribuitor { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Distribuitor.Add(Distribuitor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
