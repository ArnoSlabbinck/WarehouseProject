using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseProject.Logic.Classes
{
    public class CategoryWithProduct
    {
        private string categoryName;

        public string CategoryName
        {
            get { return categoryName; }
            set { categoryName = value; }
        }

        private string categoryDescription;

        public string CategoryDescription
        {
            get { return categoryDescription; }
            set { categoryDescription = value; }
        }

        private string productName;

        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        private double price;

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        private DateTime modelyear;

        public DateTime ModelYear
        {
            get { return modelyear; }
            set { modelyear = value; }
        }

        private string madein;

        public string MadeIn
        {
            get { return madein; }
            set { madein = value; }
        }


    }
}
