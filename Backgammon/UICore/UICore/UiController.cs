using System;
using GameCore;

namespace UICore
{
    public class UiController : IUiController
    {
        private IGameController _gameController;

        public UiController(IGameController gameController)
        {
            _gameController = gameController;
        }

        public void PrintBoard()
        {
            
        }

        public void NextTurn()
        {
            throw new NotImplementedException();
        }

        public void StartGame()
        {
            Console.WriteLine("Starting new game - Good Luck");

            throw new NotImplementedException();
        }
    }
}
