using System.Security.Cryptography.X509Certificates;

namespace Types
{
    public class Veranstaltung : IVeranstaltung
    {
        private string _veranstaltungsName;
        private string _veranstaltungsOrt;
        private DateTime _veranstaltungsDatum;
        private List<ITeilnehmer> _teilnehmerListe;

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
        }

        public void AddTeilnehmer(ITeilnehmer neuerTeilnehmer)
        {
            if (neuerTeilnehmer != null)
            {
                _teilnehmerListe.Add(neuerTeilnehmer);
            }
        }

        public void RemoveTeilnehmer(string teilnehmerId)
        {

            var teilnehmerToRemove = _teilnehmerListe.FirstOrDefault(x => x.id == teilnehmerId);
            if (teilnehmerToRemove != null)
            {
                _teilnehmerListe.Remove(teilnehmerToRemove);
            }

        }
    }
}