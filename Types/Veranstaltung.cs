namespace Types
{
    public class Veranstaltung : IVeranstaltung
    {
        private string _veranstaltungsName;
        private string _veranstaltungsOrt;
        private DateTime _veranstaltungsDatum;
        private IEnumerable<ITeilnehmer> _teilnehmerListe;

        public Veranstaltung(string veranstaltungsName, string veranstaltungsOrt)
        {
            _veranstaltungsName = veranstaltungsName;
            _veranstaltungsOrt = veranstaltungsOrt;
            _veranstaltungsDatum = DateTime.Today;
            _teilnehmerListe = new List<ITeilnehmer>();
        }

        public string veranstaltungsName
        {
            get => _veranstaltungsName;
            set => _veranstaltungsName = value;
        }
        public string veranstaltungsOrt
        {
            get => _veranstaltungsName;
            set => _veranstaltungsName = value;
        }
        public DateTime veranstaltungsDatum
        {
            get => _veranstaltungsDatum;
            set => _veranstaltungsDatum = value;
        }
        public IEnumerable<ITeilnehmer> teilnehmerListe
        {
            get => _teilnehmerListe;
            set => _teilnehmerListe = value;
        }

        public void AddTeilnehmer(ITeilnehmer neuerTeilnehmer)
        {
            _teilnehmerListe.Append(neuerTeilnehmer);
        }

        public void RemoveTeilnehmer(ITeilnehmer TeilnehmerToRemove)
        {
            _teilnehmerListe.ToList<ITeilnehmer>().Remove(TeilnehmerToRemove);
        }
    }
}