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
            //var zielZeiten = triggerTimes.FindAll(x => x.Channel.Contains("C1") && x.Status == "normal").ToList();
            //var startZeiten = triggerTimes.FindAll(x => x.Channel.Contains("C0") && x.Status == "normal").ToList();

            //foreach (var teilnehmer in teilnehmers)
            //{
            //    var startnummer = teilnehmer.Startnummer;
            //    var zielzeitFuerStartnummer = zielZeiten.FindAll(x => x.Startnummer == startnummer);
            //    var startzeitfuerStartnummer = startZeiten.FindAll(x => x.Startnummer == startnummer);

            //    if (zielzeitFuerStartnummer.Count == 1 && startzeitfuerStartnummer.Count == 1)
            //    {
            //        var raceTime = new TimeSpan();
            //        raceTime = zielzeitFuerStartnummer[0].TriggerTime - startzeitfuerStartnummer[0].TriggerTime;
            //        teilnehmer.TeilnehmerRaceTimes.Add(raceTime);
            //    }
            //}

            var alleLaufZeiten = triggerTimes.FindAll(x => x.Channel.Contains("RT") && x.Status == "normal").ToList();
            foreach (var teilnehmer in teilnehmers)
            {

                var startNummer = teilnehmer.Startnummer;
                var laufzeit = new TimeSpan(0);
                if (alleLaufZeiten.FindAll(x => x.Startnummer == startNummer).Count > 0)
                {
                    laufzeit = alleLaufZeiten.FindAll(x => x.Startnummer == startNummer).ToList()[0].LaufZeit;
                    teilnehmer.TeilnehmerRaceTimes.Add(laufzeit);
                }
                else
                {
                    teilnehmer.TeilnehmerRaceTimes.Add(laufzeit);
                }
            }

        }
    }
}
