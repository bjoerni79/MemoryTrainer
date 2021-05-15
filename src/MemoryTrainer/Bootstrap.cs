using Generic.MVVM.Event;
using MemoryTrainer.Environment;
using MemoryTrainer.MVVM;
using MemoryTrainer.Service;
using MemoryTrainer.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MemoryTrainer
{
    /// <summary>
    /// Bootstrapper Code for the intial MVVM set up. See also App.xaml content for more.
    /// </summary>
    public class Bootstrap
    {
        public static string Settings = "SETTINGS";
        public static string Results = "RESULTS";
        public static string IoService = "IOSERVICE";
        public static string EventManager = "EVENTMANAGER";

        public static string EventNewCardGame = "NewCardGame";

        private ComponentLoader loader;

        public Bootstrap()
        {
            // Init the IoC Facade!
            loader = new ComponentLoader();
            FacadeFactory.InitFactory();

            // Create a view model for the main windows
            Main = new MainWindowViewModel();
        }

        public MainWindowViewModel Main { get; }

        public void InitSettings()
        {
            var settings = new GameSetting();
            var overview = new ResultOverview();
            var ioService = new IoService();
            var eventManager = new EventController();

            // Init the environment
            loader.InitDecks(settings);
            loader.InitResultOverview(overview,ioService);

            // Adds internal events for the app
            eventManager.Add(new Event(EventNewCardGame));

            // Finally add it to the IOC container
            var facade = FacadeFactory.Create();
            facade.AddUnique(settings, Settings);
            facade.AddUnique(overview, Results);
            facade.AddUnique(ioService, IoService);
            facade.AddUnique(eventManager, EventManager);
        }

    }
}
