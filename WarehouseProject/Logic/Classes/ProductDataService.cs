using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseProject.Logic.Classes;

namespace WarehouseProject.Logic.Interfaces
{
    public class ProductDataService : IDataSerivce
    {
        public Task<bool> Add(object obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(object obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(object obj)
        {
            throw new NotImplementedException();
        }

        public List<CategoryWithProducts> CategoryWithProducts()
        {
            using (var context = new WarehouseDataAccess.WarehouseDBContext())
            {
                var data = context.Categories.Join(context.Products,
                    c => c.Id,
                    p => p.CategoryId,
                    (c, p) => new CategoryWithProducts
                    {
                        CategoryName = c.CategoryName,
                        CategoryDescription = c.Description,
                        MadeIn = p.MadeIn,
                        ModelYear = p.ModelYear,
                        Price = p.UnitPrice,
                        ProductName = p.ProductName,
                        UnitsOnOrder = p.UnitsOnOrder

                    }).ToList();

                return data;
            }
        
        }
    }
}
