using System;
using System.Collections.Generic;
using System.Text;

namespace MemoryTrainer.Environment
{
    public class DeckConfiguration
    {
        private static int id = 1;

        public DeckConfiguration()
        {
            Id = "Deck_" + id;
            id++;
        }

        public string Id { get; private set; }

        public IEnumerable<PlayingCard> Cards { get; set; }

        public string Title { get; set; }
    }
}
