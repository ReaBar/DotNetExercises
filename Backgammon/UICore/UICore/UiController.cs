using System;
using GameCore;

namespace UICore
{
    public class UiController : IUiController
    {
        private IGameController _gameController;
        private readonly UiDice _dice;
        private IPaintBoard _paintBoard;

        public UiController(IGameController gameController)
        {
            _gameController = gameController;
            _dice = new UiDice();
            _paintBoard = new PaintBoard();
        }

        public void NextTurn()
        {
            throw new NotImplementedException();
        }

        public void StartGame()
        {
            Console.WriteLine("Starting new game - Good Luck");
            _paintBoard.Paint(_gameController.GameBoardState);
            while (true)
            {
                string input;

                do
                {
                    Console.WriteLine("White player please roll the first dice using !roll");
                    input = Console.ReadLine();

                } while (string.IsNullOrWhiteSpace(input) || !input.Equals("!roll"));
                int firstDice = _gameController.RollFirstDice();
                _dice.PrintDice(firstDice);

                do
                {
                    Console.WriteLine("Red player 2 please roll the first dice using !roll");
                    input = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(input) || !input.Equals("!roll"));

                int secondDice = _gameController.RollSecondDice();
                _dice.PrintDice(secondDice);

                if (firstDice > secondDice)
                {
                    Console.WriteLine("Player 1 starts the game");
                    _gameController.WhosTurn = GameCheckers.White;
                    break;
                }

                if (firstDice < secondDice)
                {
                    Console.WriteLine("Player 2 starts the game");
                    _gameController.WhosTurn = GameCheckers.Red;
                    break;
                }

                else
                {
                    Console.WriteLine("its a tie, let's try again");
                }
            }
        }
    }
}
