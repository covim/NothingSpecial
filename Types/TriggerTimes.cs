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
        public DateTime TriggerTime { get; set; } = new DateTime(2000, 1, 1, 00, 00, 00);
        public int Startnummer { get; set; }
        public string Status { get; set; }
    }
}