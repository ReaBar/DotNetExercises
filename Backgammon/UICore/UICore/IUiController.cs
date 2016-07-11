using GameCore;

namespace UICore
{
    public interface IUiController
    {
        void PaintBoard();
        void NextTurn();
        void StartGame();
    }
}
