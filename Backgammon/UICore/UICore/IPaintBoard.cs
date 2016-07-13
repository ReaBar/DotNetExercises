using GameCore;

namespace UICore
{
    interface IPaintBoard
    {
        void Paint(IBoardState boardState);
        void FillMatrixWithBoardState(IBoardState boardState);
        void BuildBoard();
    }
}
