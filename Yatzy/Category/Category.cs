using System.ComponentModel;

namespace Yatzy
{
    public enum Category
    {
        [Description("Ones")]
        Ones = 1, 
        [Description("Twos")]
        Twos,
        [Description("Threes")]
        Threes,
        [Description("Fours")]
        Fours,
        [Description("Fives")]
        Fives,
        [Description("Sixes")]
        Sixes,
        [Description("Pairs")]
        Pairs,
        [Description("Two Pairs")]
        TwoPairs,
        [Description("Three of a Kind")]
        ThreeOfAKind,
        [Description("Four of a Kind")]
        FourOfAKind,
        [Description("Full House")]
        FullHouse,
        [Description("Small Straight")]
        SmallStraight,
        [Description("Large Straight")]
        LargeStraight,
        [Description("Yatzee")]
        Yatzee,
        [Description("Chance")]
        Chance
    }
}