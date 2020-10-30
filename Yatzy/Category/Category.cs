using System.ComponentModel;

namespace Yatzy
{
    public enum Category
    {
        Ones = 1, 
        Twos,
        Threes,
        Fours,
        Fives,
        Sixes,
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
        Yatzee,
        Chance
    }
}