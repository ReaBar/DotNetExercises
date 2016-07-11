using System;

namespace GameCore
{
    public interface IPlayer
    {
        GameCheckers GameCheckerColor { get; }
        ConsoleColor GameCheckerConsoleColor { get; }
        void MakeMove(int x, int y);
    }
}
