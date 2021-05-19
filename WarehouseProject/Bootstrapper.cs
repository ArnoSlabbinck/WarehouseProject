using System.Windows;
using Caliburn.Micro;
using WarehouseProject.ViewModels;
using WarehouseProject.Views;
using WarehouseProject.Data;


namespace WarehouseProject
{
    public class BootStrapper : BootstrapperBase
    {

        private readonly SimpleContainer _container = new SimpleContainer();

        public BootStrapper()
        {
            Initialize();
        }
        protected override void Configure()
        {
            _container.Singleton<IWindowManager, WindowManager>();
            _container.Singleton<IEventAggregator, EventAggregator>();
            _container.RegisterPerRequest(typeof(LoginViewModel), null, typeof(LoginViewModel));
        }
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
           
            DisplayRootViewFor<LoginViewModel>();
        }
    }
}
