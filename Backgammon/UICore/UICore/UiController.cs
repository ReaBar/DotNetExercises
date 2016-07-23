using System;
using GameCore;

namespace UICore
{
    public class UiController : IUiController
    {
        private readonly IGameController _gameController;
        private readonly UiDice _dice;
        private readonly IPaintBoard _paintBoard;
        private bool _stopGame = false;
        private const string NoPossibleMoves = "Sorry you don't have any possible moves to make, changing turns";

        public UiController(IGameController gameController)
        {
            _dice = new UiDice();
            _paintBoard = new PaintBoard();
            _gameController = gameController;
        }

        public void NextTurn()
        {
            string input;
            string[] movesArr = new string[] { };
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

            } while (string.IsNullOrWhiteSpace(input) || !input.Equals("!roll") && !input.Equals("!quit"));

            if (input.Equals("!quit"))
            {
                _stopGame = true;
                return;
            }

            _gameController.TurnStarts();

            _dice.PrintDice(_gameController.FirstDice);
            Console.WriteLine();
            _dice.PrintDice(_gameController.SecondDice);

            if (!_gameController.AnyPossibleMoves)
            {
                Console.WriteLine(NoPossibleMoves);
            }
            else
            {
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
                        if (_gameController.AnyPossibleMoves && !_gameController.IsGameOver())
                        {
                            Console.WriteLine(
                                "From where would you like to move and where to (please write source, destination for example 1, 4 or bar, 5 or 19, out)");

                            var moves = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(moves)) continue;
                            if (moves.Equals("!quit"))
                            {
                                _stopGame = true;
                                return;
                            }

                            if (moves.Equals("!moves"))
                            {
                                {
                                    foreach (var bearingoffPossibleMove in _gameController.GetBearingoffPossibleMoves)
                                    {
                                        Console.WriteLine(
                                            $"from {bearingoffPossibleMove.Item1} to {bearingoffPossibleMove.Item2}");
                                    }

                                    foreach (var barPossibleMove in _gameController.GetBarPossibleMoves)
                                    {
                                        Console.WriteLine(
                                            _gameController.CurrentPlayer.GameCheckerColor.Equals(GameCheckers.Red)
                                                ? $"from {barPossibleMove.Item1} to {barPossibleMove.Item2}"
                                                : $"from {barPossibleMove.Item1} to {barPossibleMove.Item2 + 1}");
                                    }

                                    foreach (var inboardPossibleMove in _gameController.GetInboardPossibleMoves)
                                    {
                                        Console.WriteLine(
                                            $"from {inboardPossibleMove.Item1 + 1} to {inboardPossibleMove.Item2 + 1}");
                                    }
                                }
                            }
                            movesArr = moves.Split(',');

                            ingameBoardMoves = int.TryParse(movesArr[0], out intSource) &&
                                               int.TryParse(movesArr[1], out intDestination);
                            if (ingameBoardMoves ||
                                (string.IsNullOrWhiteSpace(movesArr[0]) && string.IsNullOrWhiteSpace(movesArr[1])))
                                continue;
                            if (movesArr[0].ToLower().Equals("bar") && int.TryParse(movesArr[1], out intDestination))
                            {
                                barMove = true;
                                strSource = movesArr[0];
                            }

                            else if (int.TryParse(movesArr[0], out intSource) &&
                                     movesArr[1].ToLower().Trim().Equals("out"))
                            {
                                bearoffMove = true;
                                strDestination = movesArr[1];
                            }
                        }

                        else if(!_gameController.IsGameOver())
                        {
                            Console.WriteLine(NoPossibleMoves);
                        }

                    } while (movesArr.Length != 2 && (!ingameBoardMoves || !barMove || !bearoffMove));

                    if (ingameBoardMoves &&
                        _gameController.MakeMove(_gameController.CurrentPlayer, intSource, intDestination))
                    {
                        _paintBoard.Paint(_gameController.GameBoardState);
                    }

                    else if (barMove &&
                             _gameController.MakeMove(_gameController.CurrentPlayer, strSource, intDestination))
                    {
                        _paintBoard.Paint(_gameController.GameBoardState);
                    }

                    else if (bearoffMove &&
                             _gameController.MakeMove(_gameController.CurrentPlayer, intSource, strDestination))
                    {
                        _paintBoard.Paint(_gameController.GameBoardState);
                    }
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

                } while (string.IsNullOrWhiteSpace(input) || !input.Equals("!roll") && !input.Equals("!quit"));

                if (input.Equals("!quit"))
                {
                    _stopGame = true;
                    return;
                }

                int firstDice = _gameController.RollFirstDice;
                _dice.PrintDice(firstDice);

                do
                {
                    Console.WriteLine("Red player please roll the first dice using !roll");
                    input = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(input) || !input.Equals("!roll") && !input.Equals("!quit"));

                if (input.Equals("!quit"))
                {
                    _stopGame = true;
                    return;
                }

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
            Console.WriteLine("you can use !quit to quit the game at anytime");
            Console.WriteLine("you can use !moves to see a list of possible moves");
            Console.WriteLine("Starting new game - Good Luck");
            _paintBoard.Paint(_gameController.GameBoardState);
            WhosGonnaStart();
            while (!_stopGame)
            {
                NextTurn();
                if (_gameController.IsGameOver())
                {
                    Console.WriteLine("Game Over - Good Game");
                    break;
                }
            }
        }
    }
}

