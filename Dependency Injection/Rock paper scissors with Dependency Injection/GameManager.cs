using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock_paper_scissors_with_Dependency_Injection
{
    public class GameManager
    {

        private IPlayer _player1;
        private IPlayer _player2;

        public GameManager(IPlayer player1, IPlayer player2) 
        {
            _player1 = player1;
            _player2 = player2;
        }
        public roundResult PlayRound()
        {
            Choice p1 = _player1.GetChoice();
            Choice p2 = _player2.GetChoice();
           

            if (p1 == p2)
            {
                return roundResult.Draw;
            }
            if (p1 == Choice.Rock && p2 == Choice.Scissors ||
                p1 == Choice.Scissors && p2 == Choice.Paper ||
                p1 == Choice.Paper && p2 == Choice.Rock)
            {
                return roundResult.Player1Win;
            }
            else
            {
                return roundResult.Player2Win;
            }
        }
    }

    public enum Choice
    {
        Rock,
        Paper,
        Scissors
    }

    public enum roundResult
    {
        Player1Win,
        Player2Win,
        Draw
    }
}
