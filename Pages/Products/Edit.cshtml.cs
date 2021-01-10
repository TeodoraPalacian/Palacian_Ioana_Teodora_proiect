using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Palacian_Ioana_Teodora_proiect.Data;
using Palacian_Ioana_Teodora_proiect.Models;

namespace Palacian_Ioana_Teodora_proiect.Pages.Products
{
    public class EditModel : ProductCategoriesPageModel
    {
        private readonly Palacian_Ioana_Teodora_proiect.Data.Palacian_Ioana_Teodora_proiectContext _context;

        public EditModel(Palacian_Ioana_Teodora_proiect.Data.Palacian_Ioana_Teodora_proiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Product.Include(b=>b.Distribuitor).Include(b=>b.ProductCategories).ThenInclude(b=>b.Categorie).AsNoTracking().FirstOrDefaultAsync(m => m.ID == id);

            if (Product == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, Product);
            ViewData["DistribuitorID"] = new SelectList(_context.Set<Distribuitor>(), "ID", "NumeDistribuitor");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var productToUpdate = await _context.Product.Include(i => i.Distribuitor).Include(i => i.ProductCategories).ThenInclude(i => i.Categorie).FirstOrDefaultAsync(s => s.ID == id);
            if (productToUpdate == null)
            {
                return NotFound();
            }
            if(await TryUpdateModelAsync<Product>(
                productToUpdate,"Produs", i=>i.Nume, i=>i.Producator, i=>i.Pret, i=>i.ReleaseDate, i => i.Distribuitor))
            {
                UpdateProductCategories(_context, selectedCategories, productToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateProductCategories(_context, selectedCategories, productToUpdate);
            PopulateAssignedCategoryData(_context, productToUpdate);
            return Page();
           /* if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(Product.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");*/
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.ID == id);
        }
    }
}
