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
            message += (number % 2 == 0) ? "Even" : "Odd";
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

            message += (isRed == true) ? "Red" : "Black";
            Console.WriteLine(message);
        }

        public void LowOrHigh(int number)
        {
            string message = "Low/High: ";

            int condition = (number - 1) / 18;
            message += (condition < 1) ? "1 to 18" : "19 to 36";
            Console.WriteLine(message);
        }

        public void Dozens(int number)
        {
            string message = "Dozens: ";

            int condition = (number - 1) / 12;
            if (condition == 0)
            {
                message += "1 to 12";
            }
            else if (condition == 1)
            {
                message += "13 to 24";
            }
            else
            {
                message += "25 to 36";
            }
            Console.WriteLine(message);
        }

        public void Column(int number)
        {
            string message = "Column: ";

            int column = number % 3;
            if (column == 1)
            {
                message += "1";
            }
            else if (column == 2)
            {
                message += "2";
            }
            else
            {
                message += "3";
            }
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
                    message += $"{Numbers[i]}/";
                }
            }
            message = message.Substring(0, message.Length - 1);
            Console.WriteLine(message);
        }

        public void DoubleStreet(int number)
        {
            string message = "Double Rows: ";
            string resultMessage = "";

            int street = (number - 1) / 3;
            if (number > 3)
            {
                for (int i = 0; i <= 35; i++)
                {
                    if ((Numbers[i] + 2) / 3 == street)
                    {
                        resultMessage += $"{Numbers[i]}/";
                    }
                }
                for (int i = 0; i <= 35; i++)
                {
                    if ((Numbers[i] - 1) / 3 == street)
                    {
                        resultMessage += $"{Numbers[i]}/";
                    }
                }
                resultMessage = resultMessage.Substring(0, resultMessage.Length - 1);
            }
            if (number < 34)
            {
                resultMessage += ", ";
                for (int i = 0; i <= 35; i++)
                {
                    if ((Numbers[i] - 1) / 3 == street)
                    {
                        resultMessage += $"{Numbers[i]}/";
                    }
                }
                for (int i = 0; i <= 35; i++)
                {
                    // The second condition was infuriating to figure out. Turns out that negative division
                    // truncates toward zero, doesn't "round down." Second condition is necessary so that numbers
                    // below 4 behave correctly (-1 / 0 would still == street).
                    if ((Numbers[i] - 4) / 3 == street && (Numbers[i] - 3 > 0))
                    {
                        resultMessage += $"{Numbers[i]}/";
                    }
                }
                resultMessage = resultMessage.Substring(0, resultMessage.Length - 1);
            }

            resultMessage = (number < 4) ? resultMessage.Substring(2, resultMessage.Length - 2) : resultMessage;
            Console.WriteLine(message + resultMessage);
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

            // use the statement below to test a specific number
            // 0 and 00 correspond to number = 37, 38
            //number = 38;

            

            if (number < 37)
            {
                Console.WriteLine($"Winning number: {number}");
                Console.WriteLine();
                Console.WriteLine("Winning bets:");
                Assign();
                EvenOrOdd(number);
                RedOrBlack(number);
                LowOrHigh(number);
                Dozens(number);
                Column(number);
                Street(number);
                DoubleStreet(number);
                Split(number);
                Corner(number);
                Console.WriteLine();
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
