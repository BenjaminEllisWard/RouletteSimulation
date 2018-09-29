using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette
{
    class Table
    {
        int[] Numbers = new int[38];

        int[] Red = new int[] { 1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36 };
        int[] Black = new int[] { 2, 4, 6, 8, 10, 11, 13, 15, 17, 20, 22, 24, 26, 28, 29, 31, 33, 35 };

        public void Assign()
        {
            int value = 1;
            for (int i = 0; i <= 37; i++)
            {
                Numbers[i] = value++;
            }
        }

        public void EvenOrOdd(int number)
        {
            string message = "Even/Odd: ";
            if (number % 2 == 0)
            {
                for (int i = 0; i <= 35; i++)
                {
                    if (Numbers[i] % 2 == 0)
                    {
                       message += $"{Numbers[i]}, ";
                    }
                }
            }

            if (number % 2 != 0)
            {
                for (int i = 0; i <= 35; i++)
                {
                    if (Numbers[i] % 2 != 0)
                    {
                        message += $"{Numbers[i]}, ";
                    }
                }
            }
            message = message.Substring(0, message.Length -2);
            Console.WriteLine(message);
        }

        public void RedOrBlack(int number)
        {
            string message = "Red/Black: ";

            bool isRed = false;

            for (int i = 0; i <= Red.Length - 1; i++)
            {
                if (number == Red[i])
                {
                    isRed = true;
                }
            }

            if (isRed == false)
            {
                for (int i = 0; i <= Black.Length - 1; i++)
                {
                    message += $"{Black[i]}, ";
                }
            }
            else
            {
                for (int i = 0; i <= Red.Length - 1; i++)
                {
                    message += $"{Red[i]}, ";
                }
            }
            message = message.Substring(0, message.Length - 2);
            Console.WriteLine(message);
        }

        public void LowOrHigh(int number)
        {
            string message = "Low/High: ";

            int condition = (number - 1) / 18;
            for (int i = 0; i <= 35; i++)
            {
                if ((Numbers[i] - 1) / 18 == condition)
                {
                    message += $"{Numbers[i]}, ";
                }
            }
            message = message.Substring(0, message.Length - 2);
            Console.WriteLine(message);
        }

        public void Dozens(int number)
        {
            string message = "Dozens: ";

            int condition = (number - 1) / 12;
            for (int i = 0; i <= 35; i++)
            {
                if ((Numbers[i] - 1) / 12 == condition)
                {
                    message += $"{Numbers[i]}, ";
                }
            }
            message = message.Substring(0, message.Length - 2);
            Console.WriteLine(message);
        }

        public void Column(int number)
        {
            string message = "Column: ";

            int column = number % 3;
            for (int i = 0; i <= 35; i++)
            {
                if (Numbers[i] % 3 == column)
                {
                    message += $"{Numbers[i]}, ";
                }
            }
            message = message.Substring(0, message.Length - 2);
            Console.WriteLine(message);
        }

        public void Street(int number)
        {
            string message = "Street: ";

            int street = (number - 1) / 3;
            for (int i = 0; i <= 35; i++)
            {
                if ((Numbers[i] - 1) / 3 == street)
                {
                    message += $"{Numbers[i]}, ";
                }
            }
            message = message.Substring(0, message.Length - 2);
            Console.WriteLine(message);
        }

        public void Split (int number)
        {
            string message = "Split: ";
            int column = (number) % 3;
            
            if (column == 1)
            {
                if (number > 3)
                {
                    message += $"{Numbers[number - 1] - 3}/{number}, ";
                }
                message += $"{number}/{Numbers[number - 1] + 1}, ";
                if (number < 34)
                {
                    message += $"{number}/{Numbers[number - 1] + 3}, ";
                }
            }

            if (column == 2)
            {
                if (number > 3)
                {
                    message += $"{Numbers[number - 1] - 3}/{number}, ";
                }
                message += $"{Numbers[number - 1] - 1}/{number}, ";
                message += $"{number}/{Numbers[number - 1] + 1}, ";
                if (number < 34)
                {
                    message += $"{number}/{Numbers[number - 1] + 3}, ";
                }
            }                                    
                                                 
            if (column == 0)                   
            {
                if (number > 3)
                {
                    message += $"{Numbers[number - 1] - 3}/{number}, ";
                }
                message += $"{Numbers[number - 1] - 1}/{number}, ";
                if (number < 34)
                {
                    message += $"{number}/{Numbers[number - 1] + 3}, ";
                }
            }
            message = message.Substring(0, message.Length - 2);
            Console.WriteLine(message);
        }

        public void Corner(int number)
        {
            string message = "Corner: ";
            int column = (number) % 3;

            if (column == 1)
            {
                if (number > 3)
                {
                    message += $"{Numbers[number - 4]}/{Numbers[number - 3]}/{Numbers[number - 1]}/{Numbers[number]}, ";
                }
                if (number < 34)
                {
                    message += $"{Numbers[number - 1]}/{Numbers[number]}/{Numbers[number + 2]}/{Numbers[number + 3]}, ";
                }
            }

            if (column == 2)
            {
                if (number > 3)
                {
                    message += $"{Numbers[number - 5]}/{Numbers[number - 4]}/{Numbers[number - 2]}/{Numbers[number - 1]}, ";
                    message += $"{Numbers[number - 4]}/{Numbers[number - 3]}/{Numbers[number - 1]}/{Numbers[number]}, ";
                }
                if (number < 34)
                {
                    message += $"{Numbers[number - 2]}/{Numbers[number - 1]}/{Numbers[number + 1]}/{Numbers[number + 2]}, ";
                    message += $"{Numbers[number - 1]}/{Numbers[number]}/{Numbers[number + 2]}/{Numbers[number + 3]}, ";
                }
            }

            if (column == 0)
            {
                if (number > 3)
                {
                    message += $"{Numbers[number - 5]}/{Numbers[number - 4]}/{Numbers[number - 2]}/{Numbers[number - 1]}, ";
                }
                if (number < 34)
                {
                    message += $"{Numbers[number - 2]}/{Numbers[number - 1]}/{Numbers[number + 1]}/{Numbers[number + 2]}, ";
                }
            }
            message = message.Substring(0, message.Length - 2);
            Console.WriteLine(message);
        }

        public void Run()
        {
            Random rnd = new Random();
            int number = rnd.Next(1, 38);
            number = 36;

            

            if (number < 37)
            {
                Console.WriteLine($"Winning number: {number}");
                Console.WriteLine();
                Assign();
                EvenOrOdd(number);
                RedOrBlack(number);
                LowOrHigh(number);
                Dozens(number);
                Column(number);
                Street(number);
                Split(number);
                Corner(number);
            }
            else if (number == 37)
            {
                Console.WriteLine($"Winning number: 0");
            }
            else
            {
                Console.WriteLine($"Winning number: 00");
            }
        }
    }
}
