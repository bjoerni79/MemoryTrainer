using System;
using System.Collections.Generic;
using System.Text;

namespace MemoryTrainer.Environment
{
    public class GameSetting
    {
        private List<DeckConfiguration> deckConfigurationList;

        public GameSetting()
        {
            deckConfigurationList = new List<DeckConfiguration>();
        }

        public IEnumerable<DeckConfiguration> AvailableDecks 
        {
            get
            {
                return deckConfigurationList;
            }
        }

        public void Add(string title, IEnumerable<PlayingCard> cards)
        {
            var deckConfig = new DeckConfiguration() { Cards = cards, Title = title };
            deckConfigurationList.Add(deckConfig);
        }
    }
}
