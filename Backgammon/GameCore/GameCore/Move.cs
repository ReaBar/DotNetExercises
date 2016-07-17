using System;
using System.Collections.Generic;

namespace GameCore
{
    class Move
    {
        private IBoardState GameBoardState { get; set; }
        public int NumOfTurnsLeft { get; set; }
        private readonly Dice _dice;
        private readonly List<Tuple<string, int>> _barPossibleMoves;
        private readonly List<Tuple<int, int>> _inboardPossibleMoves;

        public Move(IBoardState gameBoardState, Dice dice)
        {
            GameBoardState = gameBoardState;
            _dice = dice;
            _barPossibleMoves = new List<Tuple<string, int>>();
            _inboardPossibleMoves = new List<Tuple<int, int>>();
        }

        public List<Tuple<int, int>> GetInboardPossibleMoves => _inboardPossibleMoves;
        public List<Tuple<string, int>> GetBarPossibleMoves => _barPossibleMoves;

        //public bool IsMoveLegal(IBoardState boardState, IPlayer player, int source, int destination)
        //{
        //    if (boardState != null && player != null && source < GameBoardState.BoardSize() && source >= 0 &&
        //        destination >= 0 && destination < GameBoardState.BoardSize())
        //    {
        //        if (GameBoardState.GameCheckersOnBar.Contains(player.GameCheckerColor))
        //        {
        //            player.PlayerState = PlayerCondition.Bar;
        //        }

        //        switch (player.PlayerState)
        //        {
        //            case PlayerCondition.Regular:
        //                return IsMoveLegalRegularState(player, source, destination);

        //            case PlayerCondition.Bar:
        //                return IsMoveLegalBarState(player, source, destination);

        //            case PlayerCondition.BearingOff:
        //                //return IsMoveLegalBearingOffState(player, source, destination);
        //                return true;

        //            default:
        //                return false;
        //        }
        //    }
        //    return false;
        //}

        public bool IsMoveLegal(IBoardState boardState, IPlayer player, object source, object destination)
        {
            GameBoardState = boardState;
            if (boardState == null || player == null)
            {
                return false;
            }

            if (IsPlayerInBearingoffState(player))
            {
                player.PlayerState = PlayerCondition.BearingOff;
                if (source is int && destination is string)
                {
                    return IsMoveLegalBearingOffState(player, (int)source - 1);
                }
                return false;
            }

            if (GameBoardState.GameCheckersOnBar.Contains(player.GameCheckerColor))
            {
                player.PlayerState = PlayerCondition.Bar;
                if (source is string && destination is int)
                {
                    return IsMoveLegalBarState(player, (int)destination - 1);
                }
                return false;
            }

            else
            {
                player.PlayerState = PlayerCondition.Regular;
                if (source is int && destination is int)
                {
                    return IsMoveLegalRegularState(player, (int)source - 1, (int)destination - 1);
                }
                return false;
            }
        }

        private bool IsMoveLegalRegularState(IPlayer player, int source, int destination)
        {
            if (player.GameCheckerColor.Equals(GameCheckers.White))
            {
                if (source - destination != _dice.FirstDice && source - destination != _dice.SecondDice)
                {
                    return false;
                }
            }

            if (player.GameCheckerColor.Equals(GameCheckers.Red))
            {
                if (destination - source != _dice.FirstDice && destination - source != _dice.SecondDice)
                {
                    return false;
                }
            }

            if (source >= 0 && source < 24 && destination >= 0 && destination < 24 && GameBoardState.BoardPointsState[source].GameCheckersOnSpot.Equals(player.GameCheckerColor) && IsDestinationLegal(player, destination))
            {
                return true;
            }

            return false;
        }

        private bool IsMoveLegalBarState(IPlayer player, int destination)
        {
            if (player.GameCheckerColor.Equals(GameCheckers.Red))
            {
                if (_dice.FirstDice - 1 != destination && _dice.SecondDice - 1 != destination)
                {
                    return false;
                }
            }

            else if (player.GameCheckerColor.Equals(GameCheckers.White))
            {
                if (_dice.FirstDice != (24 - destination) && _dice.SecondDice != (24 - destination))
                {
                    return false;
                }
            }

            if (destination >= 0 && destination < 24 && IsDestinationLegal(player, destination))
            {
                if (player.GameCheckerColor.Equals(GameCheckers.Red) && destination >= 0 && destination < 7)
                {
                    return true;
                }

                if (player.GameCheckerColor.Equals(GameCheckers.White) && destination >= 18 && destination < 24)
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsMoveLegalBearingOffState(IPlayer player, int source)
        {
            if (source >= 0 && source < 24 && GameBoardState.BoardPointsState[source].GameCheckersOnSpot.Equals(player.GameCheckerColor))
            {
                return true;
            }
            return false;
        }

        private bool IsDestinationLegal(IPlayer player, int destination)
        {
            if (GameBoardState.BoardPointsState[destination].GameCheckersOnSpot.Equals(GameCheckers.Empty))
            {
                return true;
            }

            if (GameBoardState.BoardPointsState[destination].GameCheckersOnSpot.Equals(player.GameCheckerColor) || (!GameBoardState.BoardPointsState[destination].GameCheckersOnSpot.Equals(player.GameCheckerColor) && GameBoardState.BoardPointsState[destination].AmountOfCheckers == 1))
            {
                return true;
            }

            if (GameBoardState.BoardPointsState[destination].GameCheckersOnSpot.Equals(player.GameCheckerColor))
            {
                return true;
            }

            return false;
        }

        public IBoardState MakeMove(IBoardState boardState, IPlayer player, object source, object destination)
        {
            GameBoardState = boardState;

            switch (player.PlayerState)
            {
                case PlayerCondition.Regular:
                    return MakeMoveRegularState(GameBoardState, player, (int)source, (int)destination);

                case PlayerCondition.Bar:
                    return MakeMoveBarState(GameBoardState, player, (string)source, (int)destination);

                case PlayerCondition.BearingOff:
                    return MakeMoveBearingoffState(GameBoardState, player, (int)source, (string)destination);

                default:
                    return GameBoardState;
            }
        }

        private IBoardState MakeMoveRegularState(IBoardState boardState, IPlayer player, int source, int destination)
        {
            if (GameBoardState.BoardPointsState[destination].GameCheckersOnSpot == GameCheckers.Empty)
            {
                GameBoardState.BoardPointsState[source].RemoveCheckerFromSpot();
                GameBoardState.BoardPointsState[destination].IncreaseAmountOfCheckers(player.GameCheckerColor);
            }

            else if (GameBoardState.BoardPointsState[destination].GameCheckersOnSpot != player.GameCheckerColor)
            {
                GameBoardState.BoardPointsState[source].RemoveCheckerFromSpot();
                GameBoardState.GameCheckersOnBar.Add(GameBoardState.BoardPointsState[destination].GameCheckersOnSpot);
                GameBoardState.BoardPointsState[destination].IncreaseAmountOfCheckers(player.GameCheckerColor);
            }

            else
            {
                GameBoardState.BoardPointsState[source].RemoveCheckerFromSpot();
                GameBoardState.BoardPointsState[destination].IncreaseAmountOfCheckers();
            }

            return GameBoardState;
        }

        private IBoardState MakeMoveBarState(IBoardState boardState, IPlayer player, string source, int destination)
        {
            if (GameBoardState.BoardPointsState[destination].GameCheckersOnSpot == GameCheckers.Empty)
            {
                GameBoardState.GameCheckersOnBar.Remove(player.GameCheckerColor);
                GameBoardState.BoardPointsState[destination].IncreaseAmountOfCheckers(player.GameCheckerColor);
            }

            else if (GameBoardState.BoardPointsState[destination].GameCheckersOnSpot != player.GameCheckerColor)
            {
                GameBoardState.GameCheckersOnBar.Remove(player.GameCheckerColor);
                GameBoardState.GameCheckersOnBar.Add(GameBoardState.BoardPointsState[destination].GameCheckersOnSpot);
                GameBoardState.BoardPointsState[destination].IncreaseAmountOfCheckers(player.GameCheckerColor);
            }

            else
            {
                GameBoardState.GameCheckersOnBar.Remove(player.GameCheckerColor);
                GameBoardState.BoardPointsState[destination].IncreaseAmountOfCheckers();
            }

            return GameBoardState;
        }

        private IBoardState MakeMoveBearingoffState(IBoardState boardState, IPlayer player, int source,
            string destination)
        {
            if (GameBoardState.BoardPointsState[source].GameCheckersOnSpot.Equals(player.GameCheckerColor))
            {
                GameBoardState.BoardPointsState[source].RemoveCheckerFromSpot();
                GameBoardState.GameCheckersOut.Add(player.GameCheckerColor);
            }

            return GameBoardState;
        }


        private bool IsPlayerInBearingoffState(IPlayer player)
        {
            if (player != null && !GameBoardState.GameCheckersOnBar.Contains(player.GameCheckerColor))
            {
                if (player.GameCheckerColor.Equals(GameCheckers.White))
                {
                    for (int i = 23; i > 5; i--)
                    {
                        if (GameBoardState.BoardPointsState[i].GameCheckersOnSpot.Equals(player.GameCheckerColor))
                        {
                            return false;
                        }
                    }
                }

                else if (player.GameCheckerColor.Equals(GameCheckers.Red))
                {
                    for (int i = 0; i < 18; i++)
                    {
                        if (GameBoardState.BoardPointsState[i].GameCheckersOnSpot.Equals(player.GameCheckerColor))
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            return false;
        }

        internal void PossibleMoves(IPlayer player, int dice1, int dice2)
        {
            GetBarPossibleMoves.Clear();
            GetInboardPossibleMoves.Clear();

            if (GameBoardState.GameCheckersOnBar.Contains(player.GameCheckerColor))
            {
                player.PlayerState = PlayerCondition.Bar;

                if (player.GameCheckerColor.Equals(GameCheckers.Red))
                {
                    if (IsDestinationLegal(player, _dice.FirstDice - 1))
                    {
                        Tuple<string, int> possibleMoveFromBar = new Tuple<string, int>("bar", _dice.FirstDice);
                        _barPossibleMoves.Add(possibleMoveFromBar);
                    }

                    if (IsDestinationLegal(player, _dice.SecondDice - 1))
                    {
                        Tuple<string, int> possibleMoveFromBar = new Tuple<string, int>("bar", _dice.SecondDice);
                        _barPossibleMoves.Add(possibleMoveFromBar);
                    }
                }

                else if (player.GameCheckerColor.Equals(GameCheckers.White))
                {
                    if (IsDestinationLegal(player, 24 - _dice.FirstDice))
                    {
                        Tuple<string, int> possibleMoveFromBar = new Tuple<string, int>("bar", 24 - _dice.FirstDice);
                        _barPossibleMoves.Add(possibleMoveFromBar);
                    }

                    if (IsDestinationLegal(player, 24 - _dice.SecondDice))
                    {
                        Tuple<string, int> possibleMoveFromBar = new Tuple<string, int>("bar", 24 - _dice.SecondDice);
                        _barPossibleMoves.Add(possibleMoveFromBar);
                    }
                }
            }

            else
            {
                player.PlayerState = IsPlayerInBearingoffState(player) ? PlayerCondition.BearingOff : PlayerCondition.Regular;

                for (int i = 1; i < GameBoardState.BoardPointsState.Length + 1; i++)
                {
                    if (player.GameCheckerColor.Equals(GameBoardState.BoardPointsState[i - 1].GameCheckersOnSpot) && player.GameCheckerColor.Equals(GameCheckers.Red))
                    {
                        if (IsMoveLegal(GameBoardState, player, i, i + dice1))
                        {
                            Tuple<int, int> possibleMove = new Tuple<int, int>(i - 1, i + dice1 - 1);
                            _inboardPossibleMoves.Add(possibleMove);
                        }

                        if (IsMoveLegal(GameBoardState, player, i, i + dice2))
                        {
                            Tuple<int, int> possibleMove = new Tuple<int, int>(i - 1, i + dice2 - 1);
                            _inboardPossibleMoves.Add(possibleMove);
                        }
                    }

                    else if (player.GameCheckerColor.Equals(GameBoardState.BoardPointsState[i - 1].GameCheckersOnSpot) && player.GameCheckerColor.Equals(GameCheckers.White))
                    {
                        if (IsMoveLegal(GameBoardState, player, i, i - dice1))
                        {
                            Tuple<int, int> possibleMove = new Tuple<int, int>(i - 1, i - dice1 - 1);
                            _inboardPossibleMoves.Add(possibleMove);
                        }

                        if (IsMoveLegal(GameBoardState, player, i, i - dice2))
                        {
                            Tuple<int, int> possibleMove = new Tuple<int, int>(i - 1, i - dice2 - 1);
                            _inboardPossibleMoves.Add(possibleMove);
                        }
                    }
                }
            }
        }
    }
}
