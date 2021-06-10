using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseProject.Logic.Classes;

namespace WarehouseProject.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        public BindableCollection<CategoryWithProducts>  categoryWithProducts { get; set; }
    }
}
