using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseProject.Logic.Classes
{
    public class CategoryWithProducts
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

        private string productname;

        public string ProductName
        {
            get { return productname; }
            set { productname = value; }
        }

        private string madin;

        public string MadeIn
        {
            get { return madin; }
            set { madin = value; }
        }

        private DateTime modelyear;

        public DateTime ModelYear
        {
            get { return modelyear; }
            set { modelyear = value; }
        }

        private int unitsonorder;

        public int UnitsOnOrder
        {
            get { return unitsonorder; }
            set { unitsonorder = value; }
        }


        private double price;

        public double Price
        {
            get { return price; }
            set { price = value; }
        }


    }
}
