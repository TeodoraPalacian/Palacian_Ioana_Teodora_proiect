using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Palacian_Ioana_Teodora_proiect.Data;

namespace Palacian_Ioana_Teodora_proiect.Models
{
    public class ProductCategoriesPageModel:PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(Palacian_Ioana_Teodora_proiectContext context, Product product)
        {
            var allCategories = context.Category;
            var productCategories = new HashSet<int>(product.ProductCategories.Select(c => c.ProdusID));
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach(var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.NumeCategorie,
                    Assigned=productCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateProductCategories(Palacian_Ioana_Teodora_proiectContext context, string[] selectedCategories, Product productToUpdate)
        {
            if (selectedCategories == null)
            {
                productToUpdate.ProductCategories = new List<ProductCategory>();
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var productCategories = new HashSet<int>(productToUpdate.ProductCategories.Select(c => c.Categorie.ID));
            foreach(var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!productCategories.Contains(cat.ID))
                    {
                        productToUpdate.ProductCategories.Add(new ProductCategory
                        {
                            ProdusID = productToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (productCategories.Contains(cat.ID))
                    {
                        ProductCategory courseToRemove = productToUpdate.ProductCategories.SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
