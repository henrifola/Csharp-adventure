using System;
using System.Diagnostics;


namespace VSCode
{
    class Program
    {
        
    
        static void Main(string[] args)
        {   
            var timer = new Stopwatch();
            Random rnd = new Random();
            int nmb = rnd.Next(1, 11);
            bool play = true;
            int guess;
            int counter = 1;
             

            Console.WriteLine("Guess a number from 1 to 10");
            timer.Start();
            

            while(play){
                guess = Convert.ToInt32(Console.ReadLine());

                if(guess == nmb){
                    timer.Stop();
                    Console.WriteLine("Correct! You used {0} tries and {1} seconds. Play again?", counter, timer.Elapsed);
                    int choice = Convert.ToInt32(Console.ReadLine());
                    if(choice > 0) {
                        guess = rnd.Next(1, 11);
                        counter = 1;
                        }
                    else if (choice == 0) play = false;
                }
                else{
                    counter++;
                    if(guess < nmb) Console.WriteLine("Wrong, try a bigger number");
                    else if(guess > nmb) Console.WriteLine("Wrong, try a smaller number");
                }

            }
            


        }
    }
}