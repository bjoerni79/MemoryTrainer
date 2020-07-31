using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MemoryTrainer.Environment
{
    public class Deck
    {
        private List<PlayingCard> cardList;
        private int currentIndex;

        public Deck(IEnumerable<PlayingCard> cards)
        {
            if (cards == null)
            {
                throw new ArgumentNullException("cards");
            }

            if (!cards.Any())
            {
                throw new ArgumentException("Empty card collection", "cards");
            }

            cardList = new List<PlayingCard>(cards);

            currentIndex = 0;
        }

        public Deck()
        {
            cardList = new List<PlayingCard>() {
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

            currentIndex = 0;
        }

        public void Shuffle()
        {
            if (cardList.Count > 1)
            {
                var rnd = new Random();
                var count = cardList.Count;

                for (var curIndex=0; curIndex < count; curIndex++)
                {
                    var swapIndex = rnd.Next(count);

                    var temp = cardList[curIndex];
                    cardList[curIndex] = cardList[swapIndex];
                    cardList[swapIndex] = temp;
                }
            }
        }

        public void ResetIndex()
        {
            currentIndex = 0;
        }

        public bool IsEndOfDeck()
        {
            return (currentIndex >= cardList.Count);
        }

        public PlayingCard GetNext()
        {
            PlayingCard next;

            if (IsEndOfDeck())
            {
                next = PlayingCard.Blank;
            }
            else
            {
                next = cardList.ElementAt(currentIndex);
                currentIndex++;
            }



            return next;
        }
    }
}
