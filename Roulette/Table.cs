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

        public void NumsThrough36()
        {

        }

        public void EvenOrOdd(int number)
        {
            Console.WriteLine("Even/Odd:");
            if (number % 2 == 0)
            {
                for (int i = 0; i <= 35; i++)
                {
                    if (Numbers[i] % 2 == 0)
                    {
                        Console.WriteLine(Numbers[i]);
                    }
                }
            }

            if (number % 2 != 0)
            {
                for (int i = 0; i <= 35; i++)
                {
                    if (Numbers[i] % 2 != 0)
                    {
                        Console.WriteLine(Numbers[i]);
                    }
                }
            }
            Console.WriteLine();
        }

        public void RedOrBlack(int number)
        {
            Console.WriteLine("Red/Black");

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
                    Console.WriteLine(Black[i]);
                }
            }
            else
            {
                for (int i = 0; i <= Red.Length - 1; i++)
                {
                    Console.WriteLine(Red[i]);
                }
            }
            Console.WriteLine();
        }

        public void LowOrHigh(int number)
        {
            Console.WriteLine("Low/High:");

            int condition = (number - 1) / 18;
            for (int i = 0; i <= 35; i++)
            {
                if ((Numbers[i] - 1) / 18 == condition)
                {
                    Console.WriteLine(Numbers[i]);
                }
            }
            Console.WriteLine();
        }

        public void Dozens(int number)
        {
            Console.WriteLine("Dozens:");

            int condition = (number - 1) / 12;
            for (int i = 0; i <= 35; i++)
            {
                if ((Numbers[i] - 1) / 12 == condition)
                {
                    Console.WriteLine(Numbers[i]);
                }
            }
            Console.WriteLine();
        }

        public void Column(int number)
        {
            Console.WriteLine("Column:");

            int column = number % 3;
            for (int i = 0; i <= 35; i++)
            {
                if (Numbers[i] % 3 == column)
                {
                    Console.WriteLine(Numbers[i]);
                }
            }
            Console.WriteLine();
        }

        public void Street(int number)
        {
            Console.WriteLine("Street:");

            int street = (number - 1) / 3;
            for (int i = 0; i <= 35; i++)
            {
                if ((Numbers[i] - 1) / 3 == street)
                {
                    Console.WriteLine(Numbers[i]);
                }
            }
            Console.WriteLine();
        }

        public void Split (int number)
        {
            Console.WriteLine("Split");
            int column = (number) % 3;
            
            if (column == 1)
            {
                Console.WriteLine(Numbers[number - 1] - 3);
                Console.WriteLine(Numbers[number - 1] + 3);
                Console.WriteLine(Numbers[number - 1] + 1);
            }                                   
                                                
            if (column == 2)                  
            {                                   
                Console.WriteLine(Numbers[number - 1] - 3);
                Console.WriteLine(Numbers[number - 1] + 3);
                Console.WriteLine(Numbers[number - 1] + 1);
                Console.WriteLine(Numbers[number - 1] - 1);
            }                                    
                                                 
            if (column == 0)                   
            {                                    
                Console.WriteLine(Numbers[number - 1] - 3);
                Console.WriteLine(Numbers[number - 1] + 3);
                Console.WriteLine(Numbers[number - 1] - 1);
            }
            Console.WriteLine();
        }

        public void Corner(int number)
        {
            Console.WriteLine("Corner");
            int column = (number) % 3;

            if (column == 1)
            {
                if (number > 3)
                {
                    Console.WriteLine($"{Numbers[number - 4]}/{Numbers[number - 3]}/{Numbers[number - 1]}/{Numbers[number]}");
                }
                if (number < 34)
                {
                    Console.WriteLine($"{Numbers[number - 1]}/{Numbers[number]}/{Numbers[number + 2]}/{Numbers[number + 3]}");
                }
            }

            if (column == 2)
            {
                if (number > 3)
                {
                    Console.WriteLine($"{Numbers[number - 5]}/{Numbers[number - 4]}/{Numbers[number - 2]}/{Numbers[number - 1]}");
                    Console.WriteLine($"{Numbers[number - 4]}/{Numbers[number - 3]}/{Numbers[number - 1]}/{Numbers[number]}");
                }
                if (number < 34)
                {
                    Console.WriteLine($"{Numbers[number - 2]}/{Numbers[number - 1]}/{Numbers[number + 1]}/{Numbers[number + 2]}");
                    Console.WriteLine($"{Numbers[number - 1]}/{Numbers[number]}/{Numbers[number + 2]}/{Numbers[number + 3]}");
                }
            }

            if (column == 0)
            {
                if (number > 3)
                {
                    Console.WriteLine($"{Numbers[number - 5]}/{Numbers[number - 4]}/{Numbers[number - 2]}/{Numbers[number - 1]}");
                }
                if (number < 34)
                {
                    Console.WriteLine($"{Numbers[number - 2]}/{Numbers[number - 1]}/{Numbers[number + 1]}/{Numbers[number + 2]}");
                }
            }
            Console.WriteLine();
        }

        public void Run()
        {
            Random rnd = new Random();
            int number = rnd.Next(1, 38);

            

            if (number < 37)
            {
                Console.WriteLine($"Winning number: {number}");
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
