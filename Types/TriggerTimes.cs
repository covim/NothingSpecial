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
        private int _startnummer;
        private string _status;

        public string status
        {
            get { return _status; }
            set { _status = value; }
        }

        public int startnummer
        {
            get { return _startnummer; }
            set { _startnummer = value; }
        }

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