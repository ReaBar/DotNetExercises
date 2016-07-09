using System;

namespace GameCore
{
    class Dice
    {
        private readonly Random _rnd = new Random();
        public int[] RollDices()
        {
            int[] numbersRolled = new int[2];
            numbersRolled[0] = _rnd.Next(1, 7);
            numbersRolled[1] = _rnd.Next(1, 7);
            return numbersRolled;
        }

        public int SingleDice() => _rnd.Next(1, 7);
    }
}
