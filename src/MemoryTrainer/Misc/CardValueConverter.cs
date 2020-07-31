using MemoryTrainer.Environment;
using MemoryTrainer.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace MemoryTrainer.Misc
{
    /// <summary>
    /// Converts a card of type PlayingCard to an image
    /// </summary>
    public class CardValueConverter : IValueConverter
    {
        private Dictionary<PlayingCard, string> cardDict;
        private readonly string path = @"/Misc/Images/";

        public CardValueConverter()
        {
            // Build up the dictionary. 
            cardDict = new Dictionary<PlayingCard, string>();
            cardDict.Add(PlayingCard.Club_2, path + "2_of_clubs.png");
            cardDict.Add(PlayingCard.Club_3, path + "3_of_clubs.png");
            cardDict.Add(PlayingCard.Club_4, path + "4_of_clubs.png");
            cardDict.Add(PlayingCard.Club_5, path + "5_of_clubs.png");
            cardDict.Add(PlayingCard.Club_6, path + "6_of_clubs.png");
            cardDict.Add(PlayingCard.Club_7, path + "7_of_clubs.png");
            cardDict.Add(PlayingCard.Club_8, path + "8_of_clubs.png");
            cardDict.Add(PlayingCard.Club_9, path + "9_of_clubs.png");
            cardDict.Add(PlayingCard.Club_10, path + "10_of_clubs.png");
            cardDict.Add(PlayingCard.Club_Jack, path + "jack_of_clubs2.png");
            cardDict.Add(PlayingCard.Club_Queen, path + "queen_of_clubs2.png");
            cardDict.Add(PlayingCard.Club_King, path + "king_of_clubs2.png");
            cardDict.Add(PlayingCard.Club_Ace, path + "ace_of_clubs.png");

            cardDict.Add(PlayingCard.Diamond_2, path + "2_of_diamonds.png");
            cardDict.Add(PlayingCard.Diamond_3, path + "3_of_diamonds.png");
            cardDict.Add(PlayingCard.Diamond_4, path + "4_of_diamonds.png");
            cardDict.Add(PlayingCard.Diamond_5, path + "5_of_diamonds.png");
            cardDict.Add(PlayingCard.Diamond_6, path + "6_of_diamonds.png");
            cardDict.Add(PlayingCard.Diamond_7, path + "7_of_diamonds.png");
            cardDict.Add(PlayingCard.Diamond_8, path + "8_of_diamonds.png");
            cardDict.Add(PlayingCard.Diamond_9, path + "9_of_diamonds.png");
            cardDict.Add(PlayingCard.Diamond_10, path + "10_of_diamonds.png");
            cardDict.Add(PlayingCard.Diamond_Jack, path + "jack_of_diamonds2.png");
            cardDict.Add(PlayingCard.Diamond_Queen, path + "queen_of_diamonds2.png");
            cardDict.Add(PlayingCard.Diamond_King, path + "king_of_diamonds2.png");
            cardDict.Add(PlayingCard.Diamond_Ace, path + "ace_of_diamonds.png");

            cardDict.Add(PlayingCard.Heart_2, path + "2_of_hearts.png");
            cardDict.Add(PlayingCard.Heart_3, path + "3_of_hearts.png");
            cardDict.Add(PlayingCard.Heart_4, path + "4_of_hearts.png");
            cardDict.Add(PlayingCard.Heart_5, path + "5_of_hearts.png");
            cardDict.Add(PlayingCard.Heart_6, path + "6_of_hearts.png");
            cardDict.Add(PlayingCard.Heart_7, path + "7_of_hearts.png");
            cardDict.Add(PlayingCard.Heart_8, path + "8_of_hearts.png");
            cardDict.Add(PlayingCard.Heart_9, path + "9_of_hearts.png");
            cardDict.Add(PlayingCard.Heart_10, path + "10_of_hearts.png");
            cardDict.Add(PlayingCard.Heart_Jack, path + "jack_of_hearts2.png");
            cardDict.Add(PlayingCard.Heart_Queen, path + "queen_of_hearts2.png");
            cardDict.Add(PlayingCard.Heart_King, path + "king_of_hearts2.png");
            cardDict.Add(PlayingCard.Heart_Ace, path + "ace_of_hearts.png");

            cardDict.Add(PlayingCard.Spade_2, path + "2_of_spades.png");
            cardDict.Add(PlayingCard.Spade_3, path + "3_of_spades.png");
            cardDict.Add(PlayingCard.Spade_4, path + "4_of_spades.png");
            cardDict.Add(PlayingCard.Spade_5, path + "5_of_spades.png");
            cardDict.Add(PlayingCard.Spade_6, path + "6_of_spades.png");
            cardDict.Add(PlayingCard.Spade_7, path + "7_of_spades.png");
            cardDict.Add(PlayingCard.Spade_8, path + "8_of_spades.png");
            cardDict.Add(PlayingCard.Spade_9, path + "9_of_spades.png");
            cardDict.Add(PlayingCard.Spade_10, path + "10_of_spades.png");
            cardDict.Add(PlayingCard.Spade_Jack, path + "jack_of_spades2.png");
            cardDict.Add(PlayingCard.Spade_Queen, path + "queen_of_spades2.png");
            cardDict.Add(PlayingCard.Spade_King, path + "king_of_spades2.png");
            cardDict.Add(PlayingCard.Spade_Ace, path + "ace_of_spades.png");

            cardDict.Add(PlayingCard.Deck, path + "deck.png");
            cardDict.Add(PlayingCard.Blank, path + "blank_card.png");
            cardDict.Add(PlayingCard.Covered, path + "card_placeholder.png");
            cardDict.Add(PlayingCard.RedJoker, path + "red_joker.png");
            cardDict.Add(PlayingCard.BlackJoker, path + "black_joker.png");
        }



        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var playingCard = value as PlayingCard?;
            if (playingCard.HasValue)
            {
                // Convert the playing card to an image
                var uriString = cardDict[playingCard.Value];
                var uri = new Uri(uriString, UriKind.RelativeOrAbsolute);

                var imageStream = Application.GetResourceStream(uri);

                // https://docs.microsoft.com/en-us/dotnet/api/system.windows.media.imaging.bitmapdecoder?view=netcore-3.1
                BitmapDecoder decoder = BitmapDecoder.Create(imageStream.Stream, BitmapCreateOptions.None, BitmapCacheOption.Default);

                imageStream.Stream.Close();
                return decoder.Frames[0];
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
