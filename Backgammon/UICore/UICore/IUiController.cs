using GameCore;

namespace UICore
{
    public interface IUiController
    {
        void PaintBoard(IBoardState boardState = null);
        void NextTurn();
        void StartGame(IBoardState boardState);
    }
}
