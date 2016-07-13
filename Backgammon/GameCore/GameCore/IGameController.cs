
namespace GameCore
{
    public interface IGameController
    {
        IBoardState GameBoardState { get; }
        int RollFirstDice();
        int RollSecondDice();
        IBoardState MakeMove(IBoardState boardState, IPlayer player, int source, int destination);
        GameCheckers WhosTurn { get; set; }
    }
}
