using System;
using System.Collections.Generic;

namespace GameCore
{
    class Move
    {
        Dice _dice = new Dice();
        private IBoardState _gameBoard;
        public Move(IBoardState gameBoard)
        {
            _gameBoard = gameBoard;
        }

        public bool IsMoveLegal(int x, int y)
        {
            //TODO generate this method
        }

        public bool IsMoveLegal(int x)
        {
            //TODO generate this method
        }

        public void makeMove()
        {
            
        }

        public List<Tuple<int, int>> PossibleMovies()
        {
            List<Tuple<int,int>> possibleMoves = new List<Tuple<int,int>>();

            //TODO generate this method

            return possibleMoves;
        }
    }
}
