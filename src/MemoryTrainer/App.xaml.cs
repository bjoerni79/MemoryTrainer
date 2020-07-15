using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MemoryTrainer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // Call the Bootstrapper code 
            var bootstrap = FindResource("ViewModelLocator") as Bootstrap;
            if (bootstrap != null)
            {
                bootstrap.InitSettings();
            }
        }
    }
}
