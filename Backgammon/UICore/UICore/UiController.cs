using System;
using GameCore;

namespace UICore
{
    public class UiController : IUiController
    {
        private IGameController _gameController;
        private int _boardWidth = 60;
        private int _boardHeight = 60;
        
        public UiController(IGameController gameController)
        {
            _gameController = gameController;
        }

        public void PaintBoard()
        {
            for (int i = 0; i < _boardHeight; i++)
            {
                for (int j = 0; j < _boardWidth; j++)
                {
                    if ((i == 0 || i == _boardHeight -1) && j != 0 && j != _boardWidth -1)
                    {
                        //Console.BackgroundColor = ConsoleColor.Blue;
                        Console.Write("-");
                    }

                    if ((j == 0 || j == (_boardWidth - 1)) && (i != 0 && i != _boardHeight - 1))
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.Write("|");
                    }

                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }

        public void NextTurn()
        {
            throw new NotImplementedException();
        }

        public void StartGame()
        {
            Console.WriteLine("Starting new game - Good Luck");
            PaintBoard();

            //throw new NotImplementedException();
        }
    }
}
