using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Observing
{
    public class Monitor
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        /**
         * This method is monitoring all processes id's that corresponds with given argument's name.
         */
        public static string Monitoring(Argument argument, HashSet<int> hash)
        {  
            // Checking all processes with that name.
            Process[] targetProcesses = Process.GetProcessesByName(argument.Name);
            if (targetProcesses.Length == 0)
            {                
                _logger.Info($" {argument.Name} is currently not running.");
            }
            else
            {
                _logger.Info($" {argument.Name} is running.");
            }

            // Every valid process subscribes to event and adds to hashset<id's>.
            foreach (var process in targetProcesses)
            {
                if (hash.Contains(process.Id) == false)
                {
                    process.EnableRaisingEvents = true;
                    process.Exited += ProcessExited;
                    hash.Add(process.Id);
                }
            }

            // Beginning tasks for each actual id, that currently running
            // we checking their lifetime.

            Task.Run(() =>
            {                
                foreach (var id in hash)
                { 
                    targetProcesses
                    .First(x => x.Id == id)
                    .WaitForExit(argument.LifeTime * Constants.MINUTE);
                    Termination(id, argument.Name);
                }
            });
            // If its still alive we return nothing.
            return null;
        }
        
        /**
         * Method for event when monitored process exited we show message.
         */        
        private static void ProcessExited(object sender, EventArgs e)
        {
            using Process p = sender as Process;
            Console.WriteLine($"Process '{p.ProcessName}' with id - {p.Id} was closed at {p.ExitTime}.");
            _logger.Info($"Process '{p.ProcessName}' with id - {p.Id} was closed.");
            
        }
        /**
         * Method checks if process with this id and argument.Name is still there.
         */
        private static bool IsProcessStillRunning(int id, string name)
        {
            return Process.GetProcesses()
                .Any(p => p.Id.Equals(id) && p.ProcessName.Equals(name));
        }
        
        /**
         * Method that terminates process by id if its still alive after given argument's LifeTime.
         */
        private static void Termination(int id, string name)
        {
            if (IsProcessStillRunning(id, name))
            {
                Process.GetProcessById(id).Kill();
                _logger.Info($"{name} terminated.");
            }
        }
    }
}
