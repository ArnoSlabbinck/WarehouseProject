using System.Windows;
using Caliburn.Micro;
using WarehouseProject.ViewModels;
using WarehouseProject.Views;
using WarehouseProject.Data;
using System.Windows.Threading;
using System.Collections.Generic;
using System;
using System.Linq;

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
            

            _container.Instance(_container);
            //Create a single instance of the windowManager should in every other viewmodel
            _container.Singleton<IWindowManager, WindowManager>();
            _container.Singleton<IEventAggregator, EventAggregator>();



            GetType().Assembly.GetTypes()
                .Where(type => type.IsClass)
                .Where(type => type.Name.EndsWith("ViewModel"))
                .ToList()
                .ForEach(viewModelType => _container.RegisterPerRequest(
                        viewModelType, viewModelType.ToString(), viewModelType));


        }
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
           
            DisplayRootViewFor<WorkersViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }
        protected override void OnUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            MessageBox.Show(e.Exception.Message, "An error as occurred", MessageBoxButton.OK);
        }
    }
}
