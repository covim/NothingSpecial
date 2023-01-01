using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Types
{
    public class TriggerTimes
    {
        public int Id { get; set; } 
        public string Channel { get; set; }
        public DateTime TriggerTime { get; set; } = DateTime.Today;
        public TimeSpan LaufZeit { get; set; } = new TimeSpan(0, 0, 0);
        public int Startnummer { get; set; }
        public string Status { get; set; }
    }
}