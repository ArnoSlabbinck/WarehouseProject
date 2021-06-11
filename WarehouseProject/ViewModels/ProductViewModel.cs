using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseProject.Commands;
using WarehouseProject.Logic.Classes;
using WarehouseProject.Logic.Interfaces;

namespace WarehouseProject.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        public BindableCollection<CategoryWithProducts>  categoryWithProducts { get; set; }

        private CategoryWithProducts selectedProduct;
        public CategoryWithProducts SelectedProduct {
            get { return selectedProduct; }
            set { selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
            } 
        }

        public ProductDataService productDataService;

        public EditProductCommand EditProductCommand
        {
            get;
            set;
        }

        public DeleteProductCommand DeleteProductCommand
        {
            get;
            set;

        }


        public SearchProductCommand SearchProductCommand
        {
            get;
            set;
        }
        public ProductViewModel(ProductDataService productDataService, IEventAggregator eventAggregator)
        {
            this.productDataService = productDataService;
            SearchProductCommand = new SearchProductCommand(this);
            DeleteProductCommand = new DeleteProductCommand(this);
            EditProductCommand = new EditProductCommand(this);
            

        }

        public  void GetCategoryWithProducts()
        {
            productDataService.CategoryWithProducts();

            
        }

    
    }
}
