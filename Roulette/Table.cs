using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette
{
    class Table
    {
        int[] Bins = new int[38];

        // separate arrays are designated to determine color of bins
        // Black[] is not used in the current build but included here just in case
        int[] Red = new int[] { 1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36 };
        int[] Black = new int[] { 2, 4, 6, 8, 10, 11, 13, 15, 17, 20, 22, 24, 26, 28, 29, 31, 33, 35 };

        // Assigns incrementing int values to bins in a roulette table. Note that throughout rest of
        // file, indice values are one less than element values.
        public void Assign()
        {
            int value = 1;
            for (int i = 0; i <= 37; i++)
            {
                Bins[i] = value++;
            }
        }

        public void EvenOrOdd(int number)
        {
            string message = "Even/Odd: ";
            message += (number % 2 == 0) ? "Even" : "Odd";
            Console.WriteLine(message);
        }

        // method iterates through Red[] to check for a value that matches the winning bin
        public void RedOrBlack(int number)
        {
            string message = "Red/Black: ";

            bool isRed = false;

            foreach (int element in Red)
            {
                if (element == number)
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

        // Method determines street of winning bin with integer division.
        // Street is equal to the amount of times that 3 can be divided be the winning 
        // value. See visual representation of roulette betting table for clarity.
        public void Street(int number)
        {
            string message = "Street: ";

            int street = (number - 1) / 3;
            for (int i = 0; i <= 35; i++)
            {
                if ((Bins[i] - 1) / 3 == street)
                {
                    message += $"{Bins[i]}/";
                }
            }
            // Removes "/" from end of message.
            message = message.Substring(0, message.Length - 1);
            Console.WriteLine(message);
        }

        // Method determines the two winning double row bets. First bet includes the street
        // below the street with the winning bin along with the winning street, second
        // includes the street above.
        public void DoubleStreet(int number)
        {
            string message = "Double Rows: ";
            string resultMessage = "";

            int street = (number - 1) / 3;

            // Enforces lower bound of Table[]. If winning bin is less than 4, only one double row (winning
            // street + above street) will be included in winning bet.
            if (number > 3)
            {
                // street below winning bin
                for (int i = 0; i <= 35; i++)
                {
                    if ((Bins[i] + 2) / 3 == street)
                    {
                        resultMessage += $"{Bins[i]}/";
                    }
                }
                // street containing winning bin
                for (int i = 0; i <= 35; i++)
                {
                    if ((Bins[i] - 1) / 3 == street)
                    {
                        resultMessage += $"{Bins[i]}/";
                    }
                }
                resultMessage = resultMessage.Substring(0, resultMessage.Length - 1);
            }
            // Enforces upper bound of Table[]. If winning bin is greater than 34, only one double row (street 
            // below winning bin + street containing winning bin) will be included in winning bet.
            if (number < 34)
            {
                // Creates comma separation between two winning bets. Removed later with Substring() if only
                // an upper double row is a valid winning bet.
                resultMessage += ", ";
                // street containing winning bin
                for (int i = 0; i <= 35; i++)
                {
                    if ((Bins[i] - 1) / 3 == street)
                    {
                        resultMessage += $"{Bins[i]}/";
                    }
                }
                // street above winning bin
                for (int i = 0; i <= 35; i++)
                {
                    // The second condition was infuriating to figure out. Turns out that negative integer division
                    // truncates toward zero, doesn't "round down." Second condition is necessary so that numbers
                    // below 4 behave correctly (-1 / 0 would still == street).
                    if ((Bins[i] - 4) / 3 == street && (Bins[i] - 3 > 0))
                    {
                        resultMessage += $"{Bins[i]}/";
                    }
                }
                resultMessage = resultMessage.Substring(0, resultMessage.Length - 1);
            }
            // Removes first two characters (", ") if the only winning bet is an upper double street.
            resultMessage = (number < 4) ? resultMessage.Substring(2, resultMessage.Length - 2) : resultMessage;
            Console.WriteLine(message + resultMessage);
        }

        // Split bets include the winning bin and an adjacent bin, as seen on the betting table (no diagonals).
        public void Split(int number)
        {
            string message = "Split: ";
            // Column determines exclusions (only middle column (2) can have winning bins both above and below
            // the winning bin).
            int column = (number) % 3;

            if (column == 1)
            {
                // enforces lower bound of Table[]
                if (number > 3)
                {
                    // bin left of winning bin + winning bin
                    message += $"{Bins[number - 1] - 3}/{number}, ";
                }
                // winning bin + bin above winning bin
                message += $"{number}/{Bins[number - 1] + 1}, ";
                // enforces upper bound of Table[]
                if (number < 34)
                {
                    // winning bin + bin right of winning bin
                    message += $"{number}/{Bins[number - 1] + 3}, ";
                }
            }

            // See block for column 1 (above) for general notes.
            if (column == 2)
            {
                if (number > 3)
                {
                    message += $"{Bins[number - 1] - 3}/{number}, ";
                }
                message += $"{Bins[number - 1] - 1}/{number}, ";
                message += $"{number}/{Bins[number - 1] + 1}, ";
                if (number < 34)
                {
                    message += $"{number}/{Bins[number - 1] + 3}, ";
                }
            }
            // Third column. See block for column 1 (above) for general notes.
            if (column == 0)
            {
                if (number > 3)
                {
                    message += $"{Bins[number - 1] - 3}/{number}, ";
                }
                message += $"{Bins[number - 1] - 1}/{number}, ";
                if (number < 34)
                {
                    message += $"{number}/{Bins[number - 1] + 3}, ";
                }
            }
            // Removes last two characters (", ") from message.
            message = message.Substring(0, message.Length - 2);
            Console.WriteLine(message);
        }

        // Corner bets include winning bin + 3 bins that share an intersection. There are four winning corner
        // bets for each winning bin (upper/lower bounds of Table[] will exclude two bets if winning bin is 
        // below 4 or above 33; likewise, winning bets in columns 1 and 3 will exclude two winning bets).
        // Search a visual representation of roulette betting table for clarity.
        public void Corner(int number)
        {
            string message = "Corner: ";
            int column = (number) % 3;

            if (column == 1)
            {
                // enforces lower bound of Table[]
                if (number > 3)
                {
                    // intersection with winning bin in lower right corner
                    message += $"{Bins[number - 4]}/{Bins[number - 3]}/{Bins[number - 1]}/{Bins[number]}, ";
                }
                // enforces upper bound of Table[]
                if (number < 34)
                {
                    // intersection with winning bin in lower left corner
                    message += $"{Bins[number - 1]}/{Bins[number]}/{Bins[number + 2]}/{Bins[number + 3]}, ";
                }
            }

            if (column == 2)
            {
                if (number > 3)
                {
                    // intersection with winning bin in upper right corner
                    message += $"{Bins[number - 5]}/{Bins[number - 4]}/{Bins[number - 2]}/{Bins[number - 1]}, ";
                    message += $"{Bins[number - 4]}/{Bins[number - 3]}/{Bins[number - 1]}/{Bins[number]}, ";
                }
                if (number < 34)
                {
                    // intersection with winning bin in upper left corner
                    message += $"{Bins[number - 2]}/{Bins[number - 1]}/{Bins[number + 1]}/{Bins[number + 2]}, ";
                    message += $"{Bins[number - 1]}/{Bins[number]}/{Bins[number + 2]}/{Bins[number + 3]}, ";
                }
            }

            if (column == 0)
            {
                if (number > 3)
                {
                    message += $"{Bins[number - 5]}/{Bins[number - 4]}/{Bins[number - 2]}/{Bins[number - 1]}, ";
                }
                if (number < 34)
                {
                    message += $"{Bins[number - 2]}/{Bins[number - 1]}/{Bins[number + 1]}/{Bins[number + 2]}, ";
                }
            }
            message = message.Substring(0, message.Length - 2);
            Console.WriteLine(message);
        }

        public void Run()
        {
            Random rnd = new Random();
            // randomly selects winning bin
            int winningBin = rnd.Next(1, 38);

            // use the statement below to test a specific number
            // 0 and 00 correspond to winningBin = 37, 38
            //number = 38;


            // Block executes as long as winning bin is not 0 or 00.
            if (winningBin < 37)
            {
                Console.WriteLine($"Winning bin: {winningBin}");
                Console.WriteLine();
                Console.WriteLine("Winning bets:");
                Assign();
                EvenOrOdd(winningBin);
                RedOrBlack(winningBin);
                LowOrHigh(winningBin);
                Dozens(winningBin);
                Column(winningBin);
                Street(winningBin);
                DoubleStreet(winningBin);
                Split(winningBin);
                Corner(winningBin);
                Console.WriteLine();
            }
            else if (winningBin == 37)
            {
                Console.WriteLine($"Winning bin: 0");
            }
            else
            {
                Console.WriteLine($"Winning bin: 00");
            }
        }
    }
}
