using System.Collections.Generic;

namespace Yatzy
{
    public interface IPlayer
    {
        int Id { get; }
        Scorecard Scorecard { get; }
        DiceController PlayOneTurn(DiceController diceController);
        void ScoreOneTurn(DiceController turn);
        KeyValuePair<string, int> GetFinalScore();
    }
}