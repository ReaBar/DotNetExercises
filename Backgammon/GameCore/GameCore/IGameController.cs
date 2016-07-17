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
    }
}
