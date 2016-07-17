
using System;
using System.Security.Cryptography.X509Certificates;
using GameCore;

namespace UICore
{
    class PaintBoard : IPaintBoard
    {
        private int _boardWidth = 45;
        private int _boardHeight = 30;
        private readonly string[,] _boardMatrix;

        public PaintBoard()
        {
            _boardMatrix = new string[30, 45];
            BuildBoard();
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

                    else if (i == _boardHeight - 2 && j != 0 && j < _boardWidth - 1 &&
                             (j < _boardWidth / 2 - 3 || j > _boardWidth / 2 + 3))
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

        public void FillMatrixWithBoardState(IBoardState boardState)
        {
            int bottomColumn = 41;
            int topColumn = 1;
            BuildBoard();
            for (int i = 0; i < boardState.BoardPointsState.Length; i++)
            {
                if (i < boardState.BoardPointsState.Length / 2)
                {
                    int bottomRow = _boardHeight - 3;

                    for (int k = 0; k < boardState.BoardPointsState[i].AmountOfCheckers; k++)
                    {
                        if (boardState.BoardPointsState[i].GameCheckersOnSpot.Equals(GameCheckers.White))
                        {
                            _boardMatrix[bottomRow, bottomColumn] = "w";
                        }

                        else if (boardState.BoardPointsState[i].GameCheckersOnSpot.Equals(GameCheckers.Red))
                        {
                            _boardMatrix[bottomRow, bottomColumn] = "r";
                        }

                        bottomRow--;
                    }
                    if (bottomColumn == 26 && (boardState.GameCheckersOnBar.Count == 0 || !boardState.GameCheckersOnBar.Contains(GameCheckers.Red)))
                    {
                        bottomColumn -= 10;
                    }

                    else if (bottomColumn == 26 && boardState.GameCheckersOnBar.Contains(GameCheckers.Red))
                    {
                        bottomColumn -= 4;
                        bottomRow = _boardHeight - 3;
                        foreach (var gameChecker in boardState.GameCheckersOnBar)
                        {
                            if (gameChecker.Equals(GameCheckers.Red))
                            {
                                _boardMatrix[bottomRow, bottomColumn] = "r";
                                bottomRow--;
                            }
                        }
                        bottomColumn -= 6;
                    }

                    else
                    {
                        bottomColumn -= 3;
                    }
                }

                else
                {
                    int topRow = 3;

                    for (int k = 0; k < boardState.BoardPointsState[i].AmountOfCheckers; k++)
                    {
                        if (boardState.BoardPointsState[i].GameCheckersOnSpot.Equals(GameCheckers.White))
                        {
                            _boardMatrix[topRow, topColumn] = "w";
                        }

                        else
                        {
                            _boardMatrix[topRow, topColumn] = "r";
                        }
                        topRow++;
                    }
                    if (topColumn == 16 && (boardState.GameCheckersOnBar.Count == 0 || !boardState.GameCheckersOnBar.Contains(GameCheckers.White)))
                    {
                        topColumn += 10;
                    }

                    else if (topColumn == 16 && boardState.GameCheckersOnBar.Contains(GameCheckers.White))
                    {
                        topColumn += 6;
                        topRow =  3;
                        foreach (var gameChecker in boardState.GameCheckersOnBar)
                        {
                            if (gameChecker.Equals(GameCheckers.White))
                            {
                                _boardMatrix[topRow, topColumn] = "w";
                                topRow++;
                            }
                        }
                        topColumn += 4;
                    }

                    else
                    {
                        topColumn += 3;
                    }
                }
            }
        }

        public void Paint(IBoardState boardState)
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
                            Console.Write(_boardMatrix[i, j]);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(_boardMatrix[i, j]);
                        }
                        Console.ResetColor();
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
