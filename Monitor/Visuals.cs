using System;
using System.Threading;
using System.Threading.Tasks;

namespace Observing
{
    /**
     * Class for visual effects in concole app.
     */
    public class Visuals
    {
        /**
        * Method that draw's message with countdown timer if application ends.
        */
        public static void DrawCountDown()
        {
            Console.WriteLine();
            int seconds = 9;
            while (seconds >= 0)
            {
                Thread.Sleep(1000);
                Console.Write($"\r{Constants.ENDING_MSG} {seconds}");
                seconds--;
            }
        }
        /**
        * Just spinning stick for good looks
        */
        public static void Spinner()
        {
            Task.Run(async() =>
            {                              
                while (true)
                {                    
                    await Task.Delay(200);
                    Console.Write("\r|");
                    await Task.Delay(200);
                    Console.Write("\r/");
                    await Task.Delay(200);
                    Console.Write("\r-");
                    await Task.Delay(200);
                    Console.Write("\r\\");
                }
            }
            );
        }
    }
}
