using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tortiki
{
        public static class ArrowMenu
        {
            public static int ShowMenu(string[] options)
            {
                int currentChoice = 0;

                while (true)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();

                    if (keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        currentChoice = (currentChoice - 1 + options.Length) % options.Length;
                    }
                    else if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        currentChoice = (currentChoice + 1) % options.Length;
                    }
                    else if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        return currentChoice;
                    }
                }
            }
        }
}
