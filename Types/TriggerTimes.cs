using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Types
{
    public class TriggerTimes : ITriggerTimes
    {
        private string _channel;
        private DateTime _triggerTime;

        public DateTime triggerTime
        {
            get { return _triggerTime; }
            set { _triggerTime = value; }
        }


        public string channel
        {
            get { return _channel; }
            set { _channel = value; }
        }
    }
}
