using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseProject.Data
{
    public interface IDialogWindowService<T>
    {
        void Show();
        void ShowDialog();
    }
}
