using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Palacian_Ioana_Teodora_proiect.Models
{
    public class Distribuitor
    {
        public int ID { get; set; }
        [Display(Name ="Nume Distribuitor")]
        public string NumeDistribuitor { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
