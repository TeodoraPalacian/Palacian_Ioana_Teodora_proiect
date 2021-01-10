using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Palacian_Ioana_Teodora_proiect.Models
{
    public class Product
    {
        public int ID { get; set; }
        [Required, StringLength(200, MinimumLength =10)]
        [Display(Name ="Nume Produs")]
        public string Nume { get; set; }
        [RegularExpression(@"^[A-Z][a-z]+$"),Required,StringLength(50,MinimumLength =3)]
        public string Producator { get; set; }
        [Range(1,1000000)]
        [Column(TypeName ="decimal(6,2)")]
        public decimal Pret { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Data Lansarii")]
        public DateTime ReleaseDate { get; set; }
        public int DistribuitorID { get; set; }
        public Distribuitor Distribuitor { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
