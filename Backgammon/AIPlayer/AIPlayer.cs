using System;
using System.Collections.Generic;
using GameCore;

namespace AIPlayer
{
    internal class AiPlayer : IPlayer
    {
        public GameCheckers GameCheckerColor { get; }
        public PlayerCondition PlayerState { get; set; }
        public ConsoleColor GameCheckerConsoleColor { get; }
        public bool IsPlayerAi { get; set; }

        public AiPlayer(GameCheckers checkerColor)
        {
            PlayerState = PlayerCondition.Regular;
            IsPlayerAi = true;
            switch (checkerColor)
            {
                case GameCheckers.White:
                    GameCheckerColor = GameCheckers.White;
                    GameCheckerConsoleColor = ConsoleColor.White;
                    break;
                case GameCheckers.Red:
                    GameCheckerColor = GameCheckers.Red;
                    GameCheckerConsoleColor = ConsoleColor.Red;
                    break;
            }
        }

        public Tuple<object, object> MakeMove(HashSet<Tuple<object, object>> possibleMoves)
        {
            Random rand = new Random();
            List<Tuple<object,object>> moves = new List<Tuple<object, object>>();
            foreach (var possibleMove in possibleMoves)
            {
                   moves.Add(possibleMove);
            }

            return moves[rand.Next(0, moves.Count)];
        }
    }
}
