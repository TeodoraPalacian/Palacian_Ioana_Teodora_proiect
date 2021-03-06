﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Palacian_Ioana_Teodora_proiect.Data;
using Palacian_Ioana_Teodora_proiect.Models;

namespace Palacian_Ioana_Teodora_proiect.Pages.Products
{
    public class CreateModel : ProductCategoriesPageModel
    {
        private readonly Palacian_Ioana_Teodora_proiect.Data.Palacian_Ioana_Teodora_proiectContext _context;

        public CreateModel(Palacian_Ioana_Teodora_proiect.Data.Palacian_Ioana_Teodora_proiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["DistribuitorID"] = new SelectList(_context.Set<Distribuitor>(), "ID", "NumeDistribuitor");
            var product = new Product();
            product.ProductCategories = new List<ProductCategory>();
            PopulateAssignedCategoryData(_context, product);
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newProduct = new Product();
            if (selectedCategories != null)
            {
                newProduct.ProductCategories = new List<ProductCategory>();
                foreach(var cat in selectedCategories)
                {
                    var catToAdd = new ProductCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newProduct.ProductCategories.Add(catToAdd);
                }
            }
            if(await TryUpdateModelAsync<Product>(
                newProduct, "Produs",
                i=>i.Nume, i=>i.Producator, i=>i.Pret, i=>i.ReleaseDate, i => i.DistribuitorID))
            {
                _context.Product.Add(newProduct);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newProduct);
            return Page();
            /*if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Product.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");*/
        }
    }
}
