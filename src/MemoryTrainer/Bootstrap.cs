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

        public Bootstrap()
        {
            // Init the IoC Facade!
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

            InitDecks(settings);
            InitResultOverview(overview,ioService);

            // Finally add it to the IOC container
            var facade = FacadeFactory.Create();
            facade.AddUnique(settings, Settings);
            facade.AddUnique(overview, Results);
            facade.AddUnique(ioService, IoService);
        }

        private void InitResultOverview(ResultOverview overview,IIOService ioService)
        {
            // If the default source file exists, try to load the content

            var sourceFile = overview.Source;
            if (File.Exists(sourceFile))
            {
                try
                {
                    var results = ioService.LoadResult(sourceFile);
                    overview.Reload(results);
                }
                catch (IOException ioException)
                {
                    //TODO: What to do??
                }
            }
        }

        private void InitDecks(GameSetting settings)
        {
            // Add different set of cards
            var diamondCards = new List<PlayingCard>()
            {
                PlayingCard.Diamond_2,
                PlayingCard.Diamond_3,
                PlayingCard.Diamond_4,
                PlayingCard.Diamond_5,
                PlayingCard.Diamond_6,
                PlayingCard.Diamond_7,
                PlayingCard.Diamond_8,
                PlayingCard.Diamond_9,
                PlayingCard.Diamond_10,
                PlayingCard.Diamond_Jack,
                PlayingCard.Diamond_Queen,
                PlayingCard.Diamond_King,
                PlayingCard.Diamond_Ace,
            };
            var heartCards = new List<PlayingCard>()
            {
                PlayingCard.Heart_2,
                PlayingCard.Heart_3,
                PlayingCard.Heart_4,
                PlayingCard.Heart_5,
                PlayingCard.Heart_6,
                PlayingCard.Heart_7,
                PlayingCard.Heart_8,
                PlayingCard.Heart_9,
                PlayingCard.Heart_10,
                PlayingCard.Heart_Jack,
                PlayingCard.Heart_Queen,
                PlayingCard.Heart_King,
                PlayingCard.Heart_Ace,
            };
            var clubCards = new List<PlayingCard>()
            {
                PlayingCard.Club_2,
                PlayingCard.Club_3,
                PlayingCard.Club_4,
                PlayingCard.Club_5,
                PlayingCard.Club_6,
                PlayingCard.Club_7,
                PlayingCard.Club_8,
                PlayingCard.Club_9,
                PlayingCard.Club_10,
                PlayingCard.Club_Jack,
                PlayingCard.Club_Queen,
                PlayingCard.Club_King,
                PlayingCard.Club_Ace,
            };
            var spadeCards = new List<PlayingCard>()
            {
                PlayingCard.Spade_2,
                PlayingCard.Spade_3,
                PlayingCard.Spade_4,
                PlayingCard.Spade_5,
                PlayingCard.Spade_6,
                PlayingCard.Spade_7,
                PlayingCard.Spade_8,
                PlayingCard.Spade_9,
                PlayingCard.Spade_10,
                PlayingCard.Spade_Jack,
                PlayingCard.Spade_Queen,
                PlayingCard.Spade_King,
                PlayingCard.Spade_Ace
            };
            var faceCards = new List<PlayingCard>()
            {
                PlayingCard.Diamond_Jack,
                PlayingCard.Diamond_Queen,
                PlayingCard.Diamond_King,
                PlayingCard.Heart_Jack,
                PlayingCard.Heart_Queen,
                PlayingCard.Heart_King,
                PlayingCard.Club_Jack,
                PlayingCard.Club_Queen,
                PlayingCard.Club_King,
                PlayingCard.Spade_Jack,
                PlayingCard.Spade_Queen,
                PlayingCard.Spade_King,
            };

            var allCards = new List<PlayingCard>();
            allCards.AddRange(diamondCards);
            allCards.AddRange(heartCards);
            allCards.AddRange(clubCards);
            allCards.AddRange(spadeCards);

            var redCards = new List<PlayingCard>();
            redCards.AddRange(diamondCards);
            redCards.AddRange(heartCards);

            var blackCards = new List<PlayingCard>();
            blackCards.AddRange(clubCards);
            blackCards.AddRange(spadeCards);

            // Create new decks
            settings.Add("Complete", allCards);
            settings.Add("Only Diamond", diamondCards);
            settings.Add("Only Heart", heartCards);
            settings.Add("Only Club", clubCards);
            settings.Add("Only Spade", spadeCards);
            settings.Add("Diamond and Heart", redCards);
            settings.Add("Club and Spade", blackCards);
            settings.Add("Only Face Cards", faceCards);
        }
    }
}
