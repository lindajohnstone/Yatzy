using System.Collections.Generic;

namespace Yatzy
{
    public interface IPlayer
    {
        int Id { get; }
        Scorecard Scorecard { get; }
        DiceController PlayOneTurn();
        void ScoreOneTurn(DiceController turn);
        KeyValuePair<string, int> GetFinalScore();
    }
}