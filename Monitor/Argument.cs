using System.Collections.Generic;

namespace Observing
{
    /**
     * Object to store incoming Arguments
     */ 
    public class Argument
    {       
        public string Name  { get; set; }
        public int LifeTime { get; set; }
        public int Frequency { get; set; }
        public Argument(string Name, int LifeTime, int Frequency)
        {
            this.Name = Name;
            this.LifeTime = LifeTime;
            this.Frequency = Frequency;
        }
    }
}