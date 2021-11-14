using System;
using System.Collections.Generic;
using System.Threading;

namespace Observing
{
    public class Program
    {
        Argument argument;

        private static void Main(string[] args)
        {
            Program p = new Program();
            // Entering the dynamic context.
            p.Init(args);
            p.Run();
        }
        
        public void Init(string[] arguments)
        {
            // Checking that there was all 3 arguments.
            CheckFormat(arguments);

            // Extracting application name, prefered lifetime of monitored application and time between each check.
            int lifetime;
            int frequency;

            if ((Int32.TryParse(arguments[1], out _) == false) || (Int32.TryParse(arguments[2], out _) == false))
            {
                throw new ArgumentException($"{nameof(arguments)} should be in - {Constants.FORMAT} format.");               
            }            

            lifetime = Int32.Parse(arguments[1]);
            frequency = Int32.Parse(arguments[2]);
            
            // Checking arguments for bad values.
            if (lifetime < 0 || frequency<0)
            {
                throw new ArgumentException($"{nameof(arguments)} cannot be of negative value!");
            }

            if ((arguments[0] == null) || (arguments[0] == ""))
            {
                throw new ArgumentException($"{nameof(argument)} cannot be empty!");
            }

            argument = new Argument(arguments[0], lifetime, frequency);
        }
        
        public void Run()
        {
            // Hash set to store id's of arguments name.
            var hash = new HashSet<int>();

            Console.WriteLine($"\r{Constants.MSG} {argument.Name}...");
            Visuals.Spinner();

            while (true)
            {
                Monitor.Monitoring(argument, hash);                
                Thread.Sleep(argument.Frequency * Constants.MINUTE);
            }
        }

        private static void CheckFormat(string[] arguments)
        {            
            if (arguments.Length < 3)
            {
                Console.WriteLine(Constants.WARNING);
                Console.WriteLine(Constants.HELP);
                Visuals.DrawCountDown();
                Environment.Exit(0);
            }
        }
    }
}
