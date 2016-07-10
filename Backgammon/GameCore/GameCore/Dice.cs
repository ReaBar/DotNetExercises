using System;

namespace GameCore
{
    class Dice
    {
        private readonly Random _rnd = new Random();
        public int FirstDice => _rnd.Next(1, 7);
        public int SecondDice => _rnd.Next(1, 7);
    }
}
