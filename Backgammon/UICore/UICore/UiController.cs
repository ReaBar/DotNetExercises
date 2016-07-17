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
            string input;
            string[] movesArr = new string[] {};
            int intSource = 0, intDestination = 0;
            string strSource = null, strDestination = null;
            bool ingameBoardMoves = false;
            bool bearoffMove = false;
            bool barMove = false;

            do
            {
                Console.WriteLine(_gameController.CurrentPlayer.GameCheckerColor.Equals(GameCheckers.White)
                    ? "Player 1 (white) please !roll the dices"
                    : "Player 2 (red) please !roll the dices");
                input = Console.ReadLine();

            } while (string.IsNullOrWhiteSpace(input) || !input.Equals("!roll"));
            _gameController.TurnStarts();

            _dice.PrintDice(_gameController.FirstDice);
            Console.WriteLine();
            _dice.PrintDice(_gameController.SecondDice);

            if (_gameController.FirstDice == _gameController.SecondDice)
            {
                Console.WriteLine(" ************ you got double, you get to play the dice four times ************");
                Console.WriteLine();
                _dice.PrintDice(_gameController.FirstDice);
                Console.WriteLine();
                _dice.PrintDice(_gameController.FirstDice);
            }

            while (_gameController.NumOfTurnsLeft > 0)
            {
                do
                {
                    Console.WriteLine("From where would you like to move and where to (please write source, destination for example 1, 4)");
                    var moves = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(moves))
                    {
                        movesArr = moves.Split(',');

                        ingameBoardMoves = int.TryParse(movesArr[0], out intSource) && int.TryParse(movesArr[1], out intDestination);
                        if (!ingameBoardMoves && (!string.IsNullOrWhiteSpace(movesArr[0]) || !string.IsNullOrWhiteSpace(movesArr[1])))
                        {
                            if (movesArr[0].ToLower().Equals("bar") && int.TryParse(movesArr[1], out intDestination))
                            {
                                barMove = true;
                                strSource = movesArr[0];
                            }

                            else if (int.TryParse(movesArr[0], out intSource) && movesArr[1].ToLower().Equals("out"))
                            {
                                bearoffMove = true;
                                strDestination = movesArr[1];
                            }
                        }

                    }
                } while (movesArr.Length != 2 && (!ingameBoardMoves || !barMove || !bearoffMove) );

                if (_gameController.AnyPossibleMoves)
                {
                    if (ingameBoardMoves == true &&
                        _gameController.MakeMove(_gameController.CurrentPlayer, intSource, intDestination))
                    {
                        _paintBoard.Paint(_gameController.GameBoardState);
                    }

                    else if (barMove == true &&
                             _gameController.MakeMove(_gameController.CurrentPlayer, strSource, intDestination))
                    {
                        _paintBoard.Paint(_gameController.GameBoardState);
                    }

                    else if (bearoffMove == true &&
                             _gameController.MakeMove(_gameController.CurrentPlayer, intSource, strDestination))
                    {
                        _paintBoard.Paint(_gameController.GameBoardState);
                    }
                }
                else
                {
                    break;
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

