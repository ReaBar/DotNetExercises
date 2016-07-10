using System;

namespace GameCore
{
    public class PointOnBoard
    {
        public int AmountOfCheckers { get; private set; }
        public GameCharacter GameCharacterOnSpot { get; private set; }

        public PointOnBoard(int amountOfCheckers, GameCharacter gameCharacterColor)
        {
            AmountOfCheckers = amountOfCheckers;
            GameCharacterOnSpot = gameCharacterColor;
        }

        public PointOnBoard()
        {
            AmountOfCheckers = 0;
            GameCharacterOnSpot = GameCharacter.Empty;
        }

        public bool RemoveCheckerFromSpot()
        {
            if (AmountOfCheckers > 0)
            {
                AmountOfCheckers--;
                if (AmountOfCheckers == 0)
                {
                    GameCharacterOnSpot = GameCharacter.Empty;
                }

                return true;
            }

            return false;
        }

        public void IncreaseAmountOfCheckers()
        {
            AmountOfCheckers++;
        }

        public void IncreaseAmountOfCheckers(GameCharacter color)
        {
            GameCharacterOnSpot = color;
            AmountOfCheckers = 1;
        }
    }
}
