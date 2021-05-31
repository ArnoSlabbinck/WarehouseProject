using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseProject.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public BaseViewModel CurrentViewModel { get; }

        public HomeViewModel()
        {
            CurrentViewModel = new HelloViewModel();
        }
    }
}
