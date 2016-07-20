using System.Collections.Generic;

namespace GameCore
{
    class BoardState : IBoardState
    {
        public int BoardSize() => 24;
        private readonly PointOnBoard[] _pointsOnBoard = new PointOnBoard[24];
        internal List<GameCheckers> GameCheckersOnBar { get; set; }
        internal List<GameCheckers> RedGameCheckersOut { get; set; }
        internal List<GameCheckers> WhiteGameCheckersOut { get; set; }


        public BoardState()
        {
            InitializeBoardWithGameCharacters();
            GameCheckersOnBar = new List<GameCheckers>();
            RedGameCheckersOut = new List<GameCheckers>();
            WhiteGameCheckersOut = new List<GameCheckers>();
        }

        public PointOnBoard[] BoardPointsState => _pointsOnBoard;

        List<GameCheckers> IBoardState.GameCheckersOnBar => GameCheckersOnBar;

        List<GameCheckers> IBoardState.RedGameCheckersOut => RedGameCheckersOut;
        List<GameCheckers> IBoardState.WhiteGameCheckersOut => WhiteGameCheckersOut;

        private void InitializeBoardWithGameCharacters()
        {
            for (int i = 0; i < BoardSize(); i++)
            {
                if (i == 0)
                {
                    _pointsOnBoard[i] = new PointOnBoard(2,GameCheckers.Red);
                }

                else if (i == 5 || i == 12)
                {
                    _pointsOnBoard[i] = new PointOnBoard(5,GameCheckers.White);
                }

                else if (i == 7)
                {
                    _pointsOnBoard[i] = new PointOnBoard(3,GameCheckers.White);
                }

                else if (i == 11 || i == 18)
                {
                    _pointsOnBoard[i] = new PointOnBoard(5, GameCheckers.Red);
                }

                else if (i == 16)
                {
                    _pointsOnBoard[i] = new PointOnBoard(3, GameCheckers.Red);
                }

                else if (i == 23)
                {
                    _pointsOnBoard[i] = new PointOnBoard(2, GameCheckers.White);
                }

                else
                {
                    _pointsOnBoard[i] = new PointOnBoard();
                }
            }
        }
    }
}
