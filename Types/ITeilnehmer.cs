namespace Types
{
    public interface ITeilnehmer
    {
        int id { get; set;  }
        string teilnehmerName { get; set;  }
        DateTime geburtsDatum { get; set;  }
        IEnumerable<ITriggerTimes> racersTriggerTimes { get; set;  }
        
    }
}