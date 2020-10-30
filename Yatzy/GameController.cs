using System;
using System.Linq;

namespace Yatzy
{
    public class GameController
    {
        private IInputReader _reader;
        private IOutputWriter _writer;
        private Scorecard _player;

        public GameController(IInputReader reader, IOutputWriter writer)
        {
            _reader = reader;
            _writer = writer;
            _player = new Scorecard();
        }

        public void RunGame()
        {
            var turn = new DiceController();
            turn.RollAllDice();
            Choice choice;
            var turnCount = 1; 
            while(turnCount < 3)
            {
                choice = _reader.GetPlayerRollChoice();
                if(choice == Choice.End) break;
                var heldDice = _reader.GetDiceToHold();
                for(int diceNum = 1; diceNum < 6; diceNum++)
                {
                    if(!heldDice.Contains(diceNum))
                    {
                        turn.RollOneDie(diceNum - 1);
                    }
                }
                turnCount++;
            }

            
        }
    }
}