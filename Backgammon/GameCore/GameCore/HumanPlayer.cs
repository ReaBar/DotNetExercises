using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore
{
    public class HumanPlayer : IPlayer
    {
        public GameCheckers PlayerColor { get; private set; }

        public HumanPlayer(string checkerColor)
        {
            if (!string.IsNullOrWhiteSpace(checkerColor))
            {
                var color = checkerColor.ToLower();
                if (color.Equals("white"))
                {
                    PlayerColor = GameCheckers.White;
                }
                else if (color.Equals("red"))
                {
                    PlayerColor = GameCheckers.Red;
                }
            }
            else
            {
                PlayerColor = GameCheckers.Empty;
            }
        }
        public void MakeMove(int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}
