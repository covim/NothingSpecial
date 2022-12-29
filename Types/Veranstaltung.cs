using System.Security.Cryptography.X509Certificates;

namespace Types
{
    public class Veranstaltung
    {
        public int Id { get; set; }
        public string VeranstaltungsName { get; set; }
        public string VeranstaltungsOrt { get; set; }
        public DateTime VeranstaltungsDatum { get; set; }
        public List<Teilnehmer> TeilnehmerListe { get; set; }
        public List<TriggerTimes> TriggerTimesListe { get; set;}

    }
}