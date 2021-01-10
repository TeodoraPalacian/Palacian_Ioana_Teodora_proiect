using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Palacian_Ioana_Teodora_proiect.Models
{
    public class ProductData
    {
        public IEnumerable<Product> Produse { get; set; }
        public IEnumerable<Category> Categorii { get; set; }
        public IEnumerable<ProductCategory> CategoriiProduse { get; set; }
    }
}
