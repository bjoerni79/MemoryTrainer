using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace MemoryTrainer.Environment
{
    /// <summary>
    /// Enum of playing cards including blank, covered and jokers
    /// </summary>
    /// <remarks>https://docs.microsoft.com/en-us/dotnet/api/system.xml.serialization.xmlenumattribute?view=netcore-3.1 how to serialize them</remarks>
    public enum PlayingCard
    {
        [XmlEnum(Name="Deck")]
        Deck,
        [XmlEnum(Name="Blank")]
        Blank,
        [XmlEnum(Name="Covered")]
        Covered,
        [XmlEnum(Name = "Red_Joker")]
        RedJoker,
        [XmlEnum(Name = "Black_Joker")]
        BlackJoker,
        [XmlEnum(Name = "Diamond_2")]
        Diamond_2,
        [XmlEnum(Name = "Diamond_3")]
        Diamond_3,
        [XmlEnum(Name = "Diamond_4")]
        Diamond_4,
        [XmlEnum(Name = "Diamond_5")]
        Diamond_5,
        [XmlEnum(Name = "Diamond_6")]
        Diamond_6,
        [XmlEnum(Name = "Diamond_7")]
        Diamond_7,
        [XmlEnum(Name = "Diamond_8")]
        Diamond_8,
        [XmlEnum(Name = "Diamond_9")]
        Diamond_9,
        [XmlEnum(Name = "Diamond_10")]
        Diamond_10,
        [XmlEnum(Name = "Diamond_Jack")]
        Diamond_Jack,
        [XmlEnum(Name = "Diamond_Queen")]
        Diamond_Queen,
        [XmlEnum(Name = "Diamond_King")]
        Diamond_King,
        [XmlEnum(Name = "Diamond_Ace")]
        Diamond_Ace,
        [XmlEnum(Name = "Heart_2")]
        Heart_2,
        [XmlEnum(Name = "Heart_3")]
        Heart_3,
        [XmlEnum(Name = "Heart_4")]
        Heart_4,
        [XmlEnum(Name = "Heart_5")]
        Heart_5,
        [XmlEnum(Name = "Heart_6")]
        Heart_6,
        [XmlEnum(Name = "Heart_7")]
        Heart_7,
        [XmlEnum(Name = "Heart_8")]
        Heart_8,
        [XmlEnum(Name = "Heart_9")]
        Heart_9,
        [XmlEnum(Name = "Heart_10")]
        Heart_10,
        [XmlEnum(Name = "Heart_Jack")]
        Heart_Jack,
        [XmlEnum(Name = "Heart_Queen")]
        Heart_Queen,
        [XmlEnum(Name = "Heart_King")]
        Heart_King,
        [XmlEnum(Name = "Heart_Ace")]
        Heart_Ace,
        [XmlEnum(Name = "Spade_2")]
        Spade_2,
        [XmlEnum(Name = "Spade_3")]
        Spade_3,
        [XmlEnum(Name = "Spade_4")]
        Spade_4,
        [XmlEnum(Name = "Spade_5")]
        Spade_5,
        [XmlEnum(Name = "Spade_6")]
        Spade_6,
        [XmlEnum(Name = "Spade_7")]
        Spade_7,
        [XmlEnum(Name = "Spade_8")]
        Spade_8,
        [XmlEnum(Name = "Spade_9")]
        Spade_9,
        [XmlEnum(Name = "Spade_10")]
        Spade_10,
        [XmlEnum(Name = "Spade_Jack")]
        Spade_Jack,
        [XmlEnum(Name = "Spade_Queen")]
        Spade_Queen,
        [XmlEnum(Name = "Spade_King")]
        Spade_King,
        [XmlEnum(Name = "Spade_Ace")]
        Spade_Ace,
        [XmlEnum(Name = "Club_2")]
        Club_2,
        [XmlEnum(Name = "Club_3")]
        Club_3,
        [XmlEnum(Name = "Club_4")]
        Club_4,
        [XmlEnum(Name = "Club_5")]
        Club_5,
        [XmlEnum(Name = "Club_6")]
        Club_6,
        [XmlEnum(Name = "Club_7")]
        Club_7,
        [XmlEnum(Name = "Club_8")]
        Club_8,
        [XmlEnum(Name = "Club_9")]
        Club_9,
        [XmlEnum(Name = "Club_10")]
        Club_10,
        [XmlEnum(Name = "Club_Jack")]
        Club_Jack,
        [XmlEnum(Name = "Club_Queen")]
        Club_Queen,
        [XmlEnum(Name = "Club_King")]
        Club_King,
        [XmlEnum(Name = "Club_Ace")]
        Club_Ace
    }
}
