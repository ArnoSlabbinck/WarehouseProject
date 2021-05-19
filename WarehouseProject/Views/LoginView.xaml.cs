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
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (((LoginViewModel) DataContext).CheckCredentials())
            {
                MessageBox.Show("You have been succesfully logged in");
                
            }

            else
            {
                MessageBox.Show("Invalid credentials. Try to enter the right credentials");
            }

        }
    }
}
