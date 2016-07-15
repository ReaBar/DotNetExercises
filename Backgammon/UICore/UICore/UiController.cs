using System;
using GameCore;

namespace UICore
{
    public class UiController : IUiController
    {
        private readonly IGameController _gameController;
        private readonly UiDice _dice;
        private readonly IPaintBoard _paintBoard;

        public UiController(IGameController gameController)
        {
            _dice = new UiDice();
            _paintBoard = new PaintBoard();
            _gameController = gameController;
        }

        public void NextTurn()
        {
            string input,moves;
            string[] movesArr = new string[] {};
            int source = 0, destination = 0;
            int numOfTurns = 2;
            bool success = false;
            do
            {
                Console.WriteLine(_gameController.CurrentPlayer.GameCheckerColor.Equals(GameCheckers.White)
                    ? "Player 1 (white) please !roll the dices"
                    : "Player 2 (red) please !roll the dices");
                input = Console.ReadLine();

            } while (string.IsNullOrWhiteSpace(input) || !input.Equals("!roll"));

            _dice.PrintDice(_gameController.RollFirstDice);
            Console.WriteLine();
            _dice.PrintDice(_gameController.RollSecondDice);

            if (_gameController.FirstDice == _gameController.SecondDice)
            {
                Console.WriteLine(" ************ you got double, you get to play the dice four times ************");
                Console.WriteLine();
                _dice.PrintDice(_gameController.FirstDice);
                Console.WriteLine();
                _dice.PrintDice(_gameController.FirstDice);
                numOfTurns = 4;
            }

            while (numOfTurns > 0)
            {
                do
                {
                    Console.WriteLine("From where would you like to move and where to (please write source, destination for example 1, 4)");
                    moves = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(moves))
                    {
                        movesArr = moves.Split(',');

                        success = int.TryParse(movesArr[0], out source) && int.TryParse(movesArr[1], out destination);

                    }
                } while (movesArr.Length != 2 && !success);

                if (_gameController.MakeMove(_gameController.CurrentPlayer, source, destination))
                {
                    numOfTurns--;
                    _paintBoard.Paint(_gameController.GameBoardState);
                }
            }    
        }

        private void WhosGonnaStart()
        {
            while (true)
            {
                string input;

                do
                {
                    Console.WriteLine("White player please roll the first dice using !roll");
                    input = Console.ReadLine();

                } while (string.IsNullOrWhiteSpace(input) || !input.Equals("!roll"));
                int firstDice = _gameController.RollFirstDice;
                _dice.PrintDice(firstDice);

                do
                {
                    Console.WriteLine("Red player please roll the first dice using !roll");
                    input = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(input) || !input.Equals("!roll"));

                int secondDice = _gameController.RollSecondDice;
                _dice.PrintDice(secondDice);

                if (firstDice > secondDice)
                {
                    Console.WriteLine("Player 1 (white) starts the game");
                    _gameController.SetFirstPlayer(GameCheckers.White);
                    break;
                }

                if (firstDice < secondDice)
                {
                    Console.WriteLine("Player 2 (red) starts the game");
                    _gameController.SetFirstPlayer(GameCheckers.Red);
                    break;
                }

                else
                {
                    Console.WriteLine("its a tie, let's try again");
                }
            }
        }

        public void StartGame()
        {
            Console.WriteLine("Starting new game - Good Luck");
            _paintBoard.Paint(_gameController.GameBoardState);
            WhosGonnaStart();
            while (true)
            {
                NextTurn();
            }
        }
    }
}

