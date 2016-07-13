using System;
using System.Collections.Generic;

namespace GameCore
{
    class Move
    {
        private IBoardState GameBoardState { get; set; }

        public Move(IBoardState gameBoardState)
        {
            GameBoardState = gameBoardState;
        }

        private bool IsMoveLegal(IPlayer player, int source, int destination)
        {
            switch (player.PlayerState)
            {
                case PlayerCondition.Regular:
                    return IsMoveLegalRegularState(player, source, destination);

                case PlayerCondition.Bar:
                    return IsMoveLegalBarState(player, source, destination);

                case PlayerCondition.BearingOff:
                    //return IsMoveLegalBearingOffState(player, source, destination);
                    return true;

                default:
                    return false;
            }
        }

        private bool IsMoveLegalRegularState(IPlayer player, int source, int destination)
        {
            if (GameBoardState.BoardPointsState[source].GameCheckersOnSpot.Equals(player.GameCheckerColor) && IsDestinationLegal(player, destination))
            {
                return true;
            }

            return false;
        }

        private bool IsMoveLegalBarState(IPlayer player, int source, int destination)
        {
            if (GameBoardState.GameCheckersOnBar.Contains(player.GameCheckerColor) && IsDestinationLegal(player, destination))
            {
                return true;
            }
            return false;
        }

        //private bool IsMoveLegalBearingOffState(IPlayer player, int source, int destination)
        //{

        //    return false;
        //}

        private bool IsDestinationLegal(IPlayer player, int destination)
        {
            PointOnBoard point = GameBoardState.BoardPointsState[destination];
            if (GameBoardState.BoardPointsState[destination].GameCheckersOnSpot.Equals(GameCheckers.Empty))
            {
                return true;
            }


            if (point.GameCheckersOnSpot.Equals(player.GameCheckerColor) || (!point.GameCheckersOnSpot.Equals(player.GameCheckerColor) && point.AmountOfCheckers == 1))
            {
                return true;
            }


            //else
            //{
            //    if (point.GameCheckersOnSpot.Equals(GameCheckers.Red) || (point.GameCheckersOnSpot.Equals(GameCheckers.White) && point.AmountOfCheckers == 1))
            //    {
            //        return true;
            //    }
            //}

            return false;
        }

        public IBoardState MakeMove(IBoardState boardState, IPlayer player, int source, int destination)
        {
            //TODO needs to add a state for BAR and BEARING OFF at destination and BAR for source
            if (boardState != null && player != null && source < GameBoardState.BoardSize() && source > 0 && destination > 0 && destination < GameBoardState.BoardSize())
            {
                if (boardState.GameCheckersOnBar.Contains(player.GameCheckerColor))
                {
                    player.PlayerState = PlayerCondition.Bar;
                }

                GameBoardState = boardState;
                if (IsMoveLegal(player, source, destination))
                {
                    PointOnBoard sourcePoint = GameBoardState.BoardPointsState[source];
                    PointOnBoard destinationPoint = GameBoardState.BoardPointsState[destination];

                    sourcePoint.RemoveCheckerFromSpot();
                    if (GameBoardState.BoardPointsState[destination].GameCheckersOnSpot != player.GameCheckerColor)
                    {
                        GameBoardState.GameCheckersOnBar.Add(GameBoardState.BoardPointsState[destination].GameCheckersOnSpot);
                        GameBoardState.BoardPointsState[destination].RemoveCheckerFromSpot();
                        GameBoardState.BoardPointsState[destination].IncreaseAmountOfCheckers(player.GameCheckerColor);
                    }
                    else
                    {
                        destinationPoint.IncreaseAmountOfCheckers();
                    }

                    return GameBoardState;
                }
            }

            return boardState;
        }

        public List<Tuple<int, int>> PossibleMoves(IPlayer player, int dice1, int dice2)
        {
            List<Tuple<int, int>> possibleMoves = new List<Tuple<int, int>>();

            //TODO generate this method

            return possibleMoves;
        }
    }
}
