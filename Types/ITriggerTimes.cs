namespace Types
{
    public interface ITriggerTimes
    {
        string channel { get; set; }
        DateTime triggerTime { get; set;  }
        int startnummer { get; set; }
        string status { get; set; }
    }
}