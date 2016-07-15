namespace GameCore
{
    public interface IGameController
    {
        IBoardState GameBoardState { get; }
        int RollFirstDice { get; }
        int RollSecondDice { get; }
        int FirstDice { get; }
        int SecondDice { get; }
        bool MakeMove(IPlayer player, int source, int destination);
        IPlayer CurrentPlayer { get;}
        void SetFirstPlayer(GameCheckers gameCheckerColor);
    }
}
