namespace Types
{
    public interface ITeilnehmer
    {
        string id { get; set;  }
        string teilnehmerName { get; set;  }
        int jahrgang { get; set;  }
        int startnummer { get; set; }
        IEnumerable<ITriggerTimes> racersTriggerTimes { get; }
        
    }
}