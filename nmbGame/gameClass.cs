
using System;
using System.Diagnostics;

namespace nmbGame
{
    public class gameClass
    {

        public void startGame()
        {
            Random rnd = new Random();
            var timer = new Stopwatch();
            int nmb = rnd.Next(1, 11);
            int guess;
            int counter = 1;
            int choice = 0;

            Console.WriteLine("Guess a number from 1 to 10");
            timer.Start();

            while (true)
            {
                try
                {
                    guess = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Enter a number");
                    continue;
                }

                if (guess == nmb)
                {
                    timer.Stop();
                    Console.WriteLine("Correct! You used {0} tries and {1} seconds. Play again? 0/1", counter, timer.Elapsed.Seconds);
                    try
                    {
                        choice = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        break;
                    }
                    if (choice > 0)
                    {
                        nmb = rnd.Next(1, 11);
                        counter = 1;
                        Console.WriteLine("Guess a number from 1 to 10");
                        timer.Restart();
                    }
                    else if (choice == 0) break;
                }
                else
                {
                    counter++;
                    if (guess < nmb) Console.WriteLine("Wrong, try a bigger number");
                    else if (guess > nmb) Console.WriteLine("Wrong, try a smaller number");
                }

            }
        }

    }
}