using System;

namespace GameCore
{
    public interface IPlayer
    {
        GameCheckers GameCheckerColor { get; }
        PlayerCondition PlayerState { get; set; }
        ConsoleColor GameCheckerConsoleColor { get; }
    }
}
