using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Types
{
    public class Teilnehmer : ITeilnehmer
    {
        private int _id;
        private string _teilnehmerName;
        private DateTime _geburtsDatum;
        private IEnumerable<ITriggerTimes> _racersTriggerTimes;

        public IEnumerable<ITriggerTimes> racersTriggerTimes
        {
            get { return _racersTriggerTimes; }
            set { _racersTriggerTimes = value; }
        }


        public DateTime geburtsDatum
        {
            get { return _geburtsDatum; }
            set { _geburtsDatum = value; }
        }


        public string teilnehmerName
        {
            get { return _teilnehmerName; }
            set { _teilnehmerName = value; }
        }


        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

    }
}
