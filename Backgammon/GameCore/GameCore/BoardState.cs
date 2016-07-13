using System;
using System.Collections.Generic;

namespace GameCore
{
    class BoardState : IBoardState
    {
        public int BoardSize() => 24;
        private PointOnBoard[] pointsOnBoard = new PointOnBoard[24];
        internal List<GameCheckers> GameCheckersOnBar { get; set; }

        public BoardState()
        {
            InitializeBoardWithGameCharacters();
        }

        public PointOnBoard[] BoardPointsState => pointsOnBoard;

        List<GameCheckers> IBoardState.GameCheckersOnBar => GameCheckersOnBar;

        private void InitializeBoardWithGameCharacters()
        {
            for (int i = 0; i < BoardSize(); i++)
            {
                if (i == 0)
                {
                    pointsOnBoard[i] = new PointOnBoard(2,GameCheckers.Red);
                }

                else if (i == 5 || i == 12)
                {
                    pointsOnBoard[i] = new PointOnBoard(5,GameCheckers.White);
                }

                else if (i == 7)
                {
                    pointsOnBoard[i] = new PointOnBoard(3,GameCheckers.White);
                }

                else if (i == 11 || i == 18)
                {
                    pointsOnBoard[i] = new PointOnBoard(5, GameCheckers.Red);
                }

                else if (i == 16)
                {
                    pointsOnBoard[i] = new PointOnBoard(3, GameCheckers.Red);
                }

                else if (i == 23)
                {
                    pointsOnBoard[i] = new PointOnBoard(2, GameCheckers.White);
                }

                else
                {
                    pointsOnBoard[i] = new PointOnBoard();
                }
            }
        }
    }
}
