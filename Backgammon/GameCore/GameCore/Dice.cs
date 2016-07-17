using System;

namespace GameCore
{
    class Dice
    {
        public Dice()
        {
            FirstDicePlayed = false;
            SecondDicePlayed = false;
        }
        private readonly Random _rnd = new Random();
        private int _firstDice, _secondDice;
        internal int FirstDice => _firstDice;
        internal int SecondDice => _secondDice;
        internal int RollFirstDice => _firstDice = _rnd.Next(1, 7);
        internal int RollSecondDice => _secondDice = _rnd.Next(1, 7);
        internal bool FirstDicePlayed { get; set; }
        internal bool SecondDicePlayed { get; set; }
    }
}
