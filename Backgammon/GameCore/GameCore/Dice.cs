using System;

namespace GameCore
{
    class Dice
    {
        private readonly Random _rnd = new Random();
        private int _firstDice, _secondDice;
        internal int FirstDice => _firstDice;
        internal int SecondDice => _secondDice;
        internal int RollFirstDice => _firstDice = _rnd.Next(1, 7);
        internal int RollSecondDice => _secondDice = _rnd.Next(1, 7);
        //internal bool IsDouble => _firstDice == _secondDice;

        //internal void RollDices()
        //{
        //    _firstDice = _rnd.Next(1, 7);
        //    _secondDice = _rnd.Next(1, 7);
        //}
    }
}
