using System;

namespace GameCore
{
    public class PointOnBoard
    {
        public int AmountOfCheckers { get; private set; }
        public GameCheckers GameCheckersOnSpot { get; private set; }

        public PointOnBoard(int amountOfCheckers, GameCheckers gameCheckersColor)
        {
            AmountOfCheckers = amountOfCheckers;
            GameCheckersOnSpot = gameCheckersColor;
        }

        public PointOnBoard()
        {
            AmountOfCheckers = 0;
            GameCheckersOnSpot = GameCheckers.Empty;
        }

        public bool RemoveCheckerFromSpot()
        {
            if (AmountOfCheckers > 0)
            {
                AmountOfCheckers--;
                if (AmountOfCheckers == 0)
                {
                    GameCheckersOnSpot = GameCheckers.Empty;
                }

                return true;
            }

            return false;
        }

        public void IncreaseAmountOfCheckers()
        {
            AmountOfCheckers++;
        }

        public void IncreaseAmountOfCheckers(GameCheckers color)
        {
            GameCheckersOnSpot = color;
            AmountOfCheckers = 1;
        }
    }
}
