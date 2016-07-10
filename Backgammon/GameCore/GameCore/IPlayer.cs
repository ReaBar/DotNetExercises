namespace GameCore
{
    public interface IPlayer
    {
        GameCheckers PlayerColor { get; }
        void MakeMove(int x, int y);
    }
}
