using System;
using System.Collections.Generic;

namespace GameCore
{
    public interface IGameController
    {
        IBoardState GameBoardState { get; }
        int RollFirstDice { get; }
        int RollSecondDice { get; }
        int FirstDice { get; }
        int SecondDice { get; }
        bool MakeMove(IPlayer player, object source, object destination);
        IPlayer CurrentPlayer { get;}
        void SetFirstPlayer(GameCheckers gameCheckerColor);
        int NumOfTurnsLeft { get; }
        void TurnStarts();
        bool AnyPossibleMoves { get; }
        bool IsGameOver();
        HashSet<Tuple<int, int>> GetInboardPossibleMoves { get; }
        HashSet<Tuple<string, int>> GetBarPossibleMoves { get; }
        HashSet<Tuple<int, string>> GetBearingoffPossibleMoves { get; }
    }
}
