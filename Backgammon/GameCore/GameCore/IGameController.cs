
namespace GameCore
{
    public interface IGameController
    {
        void StartNewGame();
        IBoardState GameBoardState { get; }
    }
}
