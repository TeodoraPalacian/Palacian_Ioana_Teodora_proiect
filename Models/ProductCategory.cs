using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Palacian_Ioana_Teodora_proiect.Models
{
    public class ProductCategory
    {
        public int ID { get; set; }
        public int ProdusID { get; set; }
        public Product Produs { get; set; }
        public int CategoryID { get; set; }
        public Category Categorie { get; set; }
    }
}
