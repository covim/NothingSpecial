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
        public string Klasse { get; set; }
        public string Verein { get; set; }
        public List<TimeSpan> TeilnehmerRaceTimes { get; set; } = new List<TimeSpan>();

        public static void UpdateRaceTimes(List<TriggerTimes> triggerTimes, List<Teilnehmer> teilnehmers)
        {
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
