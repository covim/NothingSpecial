using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Types
{
    public class Teilnehmer : ITeilnehmer
    {
        private string _id;
        private string _teilnehmerName;
        private int _jahrgang;
        private List<ITriggerTimes> _racersTriggerTimes;
        private int _startnummer;

        public int startnummer
        {
            get { return _startnummer; }
            set { _startnummer = value; }
        }

        public Teilnehmer(string teilnehmrName, int jahrgang, int startnummer)
        {
            _id = Guid.NewGuid().ToString();
            _teilnehmerName = teilnehmrName;
            _jahrgang = jahrgang;
            _startnummer = startnummer;
            _racersTriggerTimes = new List<ITriggerTimes>();
        }
        public Teilnehmer(string teilnehmrName, int jahrgang)
        {
            _id =  Guid.NewGuid().ToString();
            _teilnehmerName = teilnehmrName;
            _jahrgang = jahrgang;
            _racersTriggerTimes = new List<ITriggerTimes>();
        }

        public IEnumerable<ITriggerTimes> racersTriggerTimes
        {
            get { return _racersTriggerTimes; }
        }


        public int jahrgang
        {
            get { return _jahrgang; }
            set { _jahrgang = value; }
        }


        public string teilnehmerName
        {
            get { return _teilnehmerName; }
            set { _teilnehmerName = value; }
        }


        public string id
        {
            get { return _id; }
            set { _id = value; }
        }

        public void AddTriggerTime(DateTime triggerTime, string channel)
        {
            var newTriggerTime = new TriggerTimes{ triggerTime = triggerTime, channel = channel };
            _racersTriggerTimes.Add(newTriggerTime);
        }


    }
}
