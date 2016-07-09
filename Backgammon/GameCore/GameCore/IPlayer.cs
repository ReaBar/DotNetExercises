namespace GameCore
{
    interface IPlayer
    {
        string PlayerColor { get; }
        void MakeMove(int x, int y);
    }
}
