using LiteDB;
using Types;

namespace LiteDB_Class
{
    public class Database
    {

        public static bool UpdateDb(Veranstaltung veranstaltung, ILiteCollection<Veranstaltung> col)
        {
            var nix = col.Update(veranstaltung);

            return true;
        }

        public static bool SaveDataToDB(Veranstaltung veranstaltung, ILiteCollection<Veranstaltung> col)
        {

            col.Insert(veranstaltung);
            col.EnsureIndex(x => x.VeranstaltungsName);

            return true;
        }

        public static Veranstaltung ReadAllDataFromDB(ILiteCollection<Veranstaltung> col)
        {
            var data = col.Query().ToList();

            Veranstaltung eingeleseneVeranstaltung = new Veranstaltung();
            eingeleseneVeranstaltung.Id = data[0].Id;
            eingeleseneVeranstaltung.VeranstaltungsDatum = data[0].VeranstaltungsDatum;
            eingeleseneVeranstaltung.VeranstaltungsOrt = data[0].VeranstaltungsOrt;
            eingeleseneVeranstaltung.VeranstaltungsName = data[0].VeranstaltungsName;
            eingeleseneVeranstaltung.TeilnehmerListe = new List<Teilnehmer>(data[0].TeilnehmerListe);
            eingeleseneVeranstaltung.TriggerTimesListe = new List<TriggerTimes>(data[0].TriggerTimesListe);

            return eingeleseneVeranstaltung;

        }





    }
}