using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseModels;
using WarehouseProject.Logic.Classes;
using WarehouseProject.Logic.Interfaces;

namespace WarehouseProject.Logic.Services
{
    public class ProductDataService : IDataService
    {
        private List<Category> categories;
        private List<Products> products;
        public ProductDataService()
        {
            categories = new List<Category>();
            products = new List<Products>();
        }
        public Task<bool> Add(Object obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Object obj)
        {
            throw new NotImplementedException();
        }

        public List<object> getData()
        {
            throw new NotImplementedException();
            // Of van category of van producten

        }

        public Task<bool> Update(Object obj)
        {
            throw new NotImplementedException();
        }


        public List<CategoryWithProducts> getCategoriesWithProducts()
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
                        ProductName = p.ProductName, 
                        MadeIn = p.MadeIn,
                        ModelYear = p.ModelYear,
                        Price = p.UnitPrice,
                        UnitsOnOrder = p.UnitsOnOrder, 
                        

                    }).ToList();

              return data;
            }
            

        }


    }
}
