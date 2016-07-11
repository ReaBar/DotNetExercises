using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore
{
    public class HumanPlayer : IPlayer
    {
        public GameCheckers GameCheckerColor { get; private set; }
        public ConsoleColor GameCheckerConsoleColor { get; private set; }
        public HumanPlayer(GameCheckers checkerColor)
        {
            switch (checkerColor)
            {
                case GameCheckers.White:
                    GameCheckerColor = GameCheckers.White;
                    GameCheckerConsoleColor = ConsoleColor.White;
                    break;
                case GameCheckers.Red:
                    GameCheckerColor = GameCheckers.Red;
                    GameCheckerConsoleColor = ConsoleColor.Red;
                    break;
                default:
                    GameCheckerColor = GameCheckers.Empty;
                    //TODO think about throwing an exception in this case
                    break;
            }
        }
        public void MakeMove(int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}
