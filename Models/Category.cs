using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Palacian_Ioana_Teodora_proiect.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string NumeCategorie { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
