using LiteDB_Class;
using System.ComponentModel.DataAnnotations;
using Types;

namespace Console
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello, World!");



            //var veranstaltung1 = new Veranstaltung("SuperVeranstaltung", "Reuthe");
            //System.Console.WriteLine(veranstaltung1.veranstaltungsName);

            //var teilNehmer1 = new Teilnehmer("Matthias", 1983, 2);
            //veranstaltung1.AddTeilnehmer(teilNehmer1);
            //var teilNehmer2 = new Teilnehmer("Susanne", 1981, 1);
            //veranstaltung1.AddTeilnehmer(teilNehmer2);
            //teilNehmer2.AddTriggerTime(DateTime.Now, "Ch1");
            //teilNehmer2.AddTriggerTime(DateTime.Now, "Ch2");



            //var database = Database.OpenOrCreateDatabase();
            //var veranstaltungsCollection = Database.GetOrCreateVeranstaltungsCollection(database);

            //veranstaltungsCollection.Insert(veranstaltung1);

            //teilNehmer2.AddTriggerTime(DateTime.Now, "Ch3");

            //veranstaltungsCollection.Update(veranstaltung1);

            var veranstaltung2 = new Veranstaltung("","");
            var database2 = Database.OpenOrCreateDatabase();
            var collection = database2.GetCollection<Veranstaltung>("Veranstaltung");
            var mapper = collection.EntityMapper;

        }

    }
}