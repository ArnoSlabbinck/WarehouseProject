using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WarehouseProject.ViewModels;

namespace WarehouseProject.Views
{
    /// <summary>
    /// Interaction logic for RegisterView.xaml
    /// </summary>
    public partial class RegisterView : Window
    {
        public RegisterView()
        {
            InitializeComponent();
            DataContext = new RegistrationViewModel();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (((RegistrationViewModel)DataContext).Validation())
            {

                MessageBox.Show("The new Employee has been added");
            }
            else
            {
                MessageBox.Show("Something went wrong. Contact SystemAdministrator");
            }
        }
    }


   
}
