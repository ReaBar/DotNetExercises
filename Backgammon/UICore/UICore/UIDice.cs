using System;

namespace UICore
{
    class UiDice
    {
        private int _diceSize = 3;
        internal void PrintDice(int dice)
        {
            switch (dice)
            {
                case 1:
                    for (int i = 0; i < _diceSize; i++)
                    {
                        if (i == _diceSize / 2)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("  .  ");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("     ");
                            Console.ResetColor();
                        }
                    }
                    break;

                case 2:
                    for (int i = 0; i < _diceSize; i++)
                    {
                        if (i == _diceSize / 2 || i == _diceSize / 2 - 1)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("  .  ");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("     ");
                            Console.ResetColor();
                        }
                    }
                    break;

                case 3:
                    for (int i = 0; i < _diceSize; i++)
                    {
                        if (i == _diceSize / 2 || i == _diceSize / 2 - 1 || i == _diceSize / 2 + 1)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("  .  ");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("     ");
                            Console.ResetColor();
                        }
                    }
                    break;

                case 4:
                    for (int i = 0; i < _diceSize; i++)
                    {
                        if (i == _diceSize - 1 || i == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine(".   .");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("     ");
                            Console.ResetColor();
                        }
                    }
                    break;

                case 5:
                    for (int i = 0; i < _diceSize; i++)
                    {
                        if (i == _diceSize - 1 || i == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine(".   .");
                            Console.ResetColor();
                        }
                        else if (i == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("  .  ");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("     ");
                            Console.ResetColor();
                        }
                    }
                    break;

                case 6:
                    for (int i = 0; i < _diceSize; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine(".   .");
                        Console.ResetColor();
                    }
                    break;
            }
        }
    }
}
