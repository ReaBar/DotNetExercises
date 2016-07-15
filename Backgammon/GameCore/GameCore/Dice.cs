using System;

namespace GameCore
{
    class Dice
    {
        private readonly Random _rnd = new Random();
        private int _firstDice, _secondDice;
        public int FirstDice => _firstDice;
        public int SecondDice => _secondDice;
        public int RollFirstDice => _firstDice = _rnd.Next(1, 7);
        public int RollSecondDice => _secondDice = _rnd.Next(1, 7);
    }
}
