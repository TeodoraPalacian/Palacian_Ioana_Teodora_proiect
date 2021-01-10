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
    public class IndexModel : PageModel
    {
        private readonly Palacian_Ioana_Teodora_proiect.Data.Palacian_Ioana_Teodora_proiectContext _context;

        public IndexModel(Palacian_Ioana_Teodora_proiect.Data.Palacian_Ioana_Teodora_proiectContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; }
        public ProductData ProductD { get; set; }
        public int ProductID { get; set; }
        public int CategoryID { get; set; }

        public async Task OnGetAsync(int? id, int? categoryID)
        {
            ProductD = new ProductData();
            ProductD.Produse = await _context.Product.Include(b => b.Distribuitor).Include(b => b.ProductCategories).ThenInclude(b => b.Categorie).AsNoTracking().OrderBy(b => b.Nume).ToListAsync();
            if (id != null)
            {
                ProductID = id.Value;
                Product product = ProductD.Produse.Where(i => i.ID == id.Value).Single();
                ProductD.Categorii = product.ProductCategories.Select(s => s.Categorie);
            }
            //Product = await _context.Product.Include(b=>b.Distribuitor).ToListAsync();
        }
    }
}
