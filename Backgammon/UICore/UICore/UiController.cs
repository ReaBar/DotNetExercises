using System;
using GameCore;

namespace UICore
{
    public class UiController : IUiController
    {
        private IGameController _gameController;
        private int _boardWidth = 45;
        private int _boardHeight = 30;
        private string[,] _boardMatrix;

        public UiController(IGameController gameController)
        {
            _gameController = gameController;
            _boardMatrix = new string[30, 45];
        }

        public void BuildBoard()
        {
            int topNumbers = 13;
            int bottomNumbers = 12;

            for (int i = 0; i < _boardMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < _boardMatrix.GetLength(1); j++)
                {
                    if (i == 0)
                    {
                        _boardMatrix[i, j] = "_";
                    }

                    else if (i == 2 && j != 0 && j < _boardWidth - 1 && (j < _boardWidth / 2 - 3 || j > _boardWidth / 2 + 3))
                    {
                        _boardMatrix[i, j] = topNumbers.ToString() + " ";
                        j += 2;
                        topNumbers++;
                    }

                    else if (i == _boardHeight - 2 && j != 0 && j < _boardWidth - 1 && (j < _boardWidth / 2 - 3 || j > _boardWidth / 2 + 3))
                    {
                        if (bottomNumbers < 10)
                        {
                            _boardMatrix[i, j] = bottomNumbers.ToString() + "  ";
                            j += 2;
                        }
                        else
                        {
                            _boardMatrix[i, j] = bottomNumbers.ToString() + " ";
                            j += 2;
                        }
                        bottomNumbers--;
                    }

                    else if (i == _boardHeight - 1)
                    {
                        _boardMatrix[i, j] = "-";
                    }

                    else if ((j == 0 || j == _boardWidth - 1) && (i != 0 && i != _boardHeight - 1))
                    {
                        _boardMatrix[i, j] = "|";
                    }

                    else if (j == _boardWidth / 2 - 2 || j == _boardWidth / 2 + 2)
                    {
                        _boardMatrix[i, j] = "|";
                    }

                    else if (j == _boardWidth / 2 - 1 && i == _boardHeight / 2)
                    {
                        _boardMatrix[i, j++] = "B";
                        _boardMatrix[i, j++] = "A";
                        _boardMatrix[i, j] = "R";
                    }

                    else
                    {
                        _boardMatrix[i, j] = " ";
                    }
                }
            }
        }

        private void FillMatrixWithBoardState(IBoardState boardState)
        {
            int bottomColumn = 41;
            int topColumn = 1;

            for (int i = 0; i < boardState.BoardState.Length; i++)
            {
                if (i < boardState.BoardState.Length / 2)
                {
                    int bottomRow = _boardHeight -3;

                    for (int k = 0; k < boardState.BoardState[i].AmountOfCheckers; k++)
                    {
                        if (boardState.BoardState[i].GameCheckersOnSpot.Equals(GameCheckers.White))
                        {
                            _boardMatrix[bottomRow, bottomColumn] = "w";
                        }

                        else
                        {
                            _boardMatrix[bottomRow, bottomColumn] = "r";
                        }
                        bottomRow--;
                    }
                    if (bottomColumn == 26)
                    {
                        bottomColumn -= 10;
                    }
                    else
                    {
                        bottomColumn -= 3;
                    }
                }

                else
                {
                    int topRow = 3;

                    for (int k = 0; k < boardState.BoardState[i].AmountOfCheckers; k++)
                    {
                        if (boardState.BoardState[i].GameCheckersOnSpot.Equals(GameCheckers.White))
                        {
                            _boardMatrix[topRow, topColumn] = "w";
                        }

                        else
                        {
                            _boardMatrix[topRow, topColumn] = "r";
                        }
                        topRow++;
                    }
                    if (topColumn == 16)
                    {
                        topColumn += 10;
                    }
                    else
                    {
                        topColumn += 3;
                    }
                }
            }
        }

        public void PaintBoard(IBoardState boardState)
        {
            FillMatrixWithBoardState(boardState);
            for (int i = 0; i < _boardMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < _boardMatrix.GetLength(1); j++)
                {
                    if (_boardMatrix[i, j] == null)
                    {
                        Console.Write("");
                    }

                    else
                    {
                        if (_boardMatrix[i, j].Equals("r"))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        Console.Write(_boardMatrix[i, j]);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                Console.WriteLine();
            }
        }

        public void NextTurn()
        {
            throw new NotImplementedException();
        }

        public void StartGame(IBoardState boardState)
        {
            Console.WriteLine("Starting new game - Good Luck");
            BuildBoard();
            PaintBoard(boardState);

            //throw new NotImplementedException();
        }
    }
}
