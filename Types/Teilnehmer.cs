using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Types
{
    public class Teilnehmer
    {
        public int Id { get; set; }
        public string TeilnehmerName { get; set; }
        public int Jahrgang { get; set; }
        public int Startnummer { get; set; }
        public List<TimeSpan> TeilnehmerRaceTimes { get; set; } = new List<TimeSpan>();

        public static void UpdateRaceTimes(List<TriggerTimes> triggerTimes, List<Teilnehmer> teilnehmers)
        {
            var ZielZeiten = triggerTimes.FindAll(x => x.Channel.Contains("C1") && x.Status == "normal").ToList();
            var StartZeiten = triggerTimes.FindAll(x => x.Channel.Contains("C0") && x.Status == "normal").ToList();

            foreach (var teilnehmer in teilnehmers)
            {
                var startnummer = teilnehmer.Startnummer;
                var zielzeitFuerStartnummer = ZielZeiten.FindAll(x => x.Startnummer == startnummer);
                var startzeitfuerStartnummer = StartZeiten.FindAll(x => x.Startnummer == startnummer);

                if (zielzeitFuerStartnummer.Count == 1 && startzeitfuerStartnummer.Count == 1)
                {
                    var raceTime = new TimeSpan();
                    raceTime = zielzeitFuerStartnummer[0].TriggerTime - startzeitfuerStartnummer[0].TriggerTime;
                    teilnehmer.TeilnehmerRaceTimes.Add(raceTime);
                }
            }


        }
    }
}
