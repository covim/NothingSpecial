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



            var veranstaltung1 = new Veranstaltung("SuperVeranstaltung", "Reuthe");
            System.Console.WriteLine(veranstaltung1.veranstaltungsName);

            var teilNehmer1 = new Teilnehmer("Matthias", 1983, 2);
            veranstaltung1.AddTeilnehmer(teilNehmer1);
            var teilNehmer2 = new Teilnehmer("Susanne", 1981, 1);
            veranstaltung1.AddTeilnehmer(teilNehmer2);
            teilNehmer2.AddTriggerTime(DateTime.Now, "Ch1");
            teilNehmer2.AddTriggerTime(DateTime.Now, "Ch2");



            var database = Database.OpenOrCreateDatabase();
            var veranstaltungsCollection = Database.GetOrCreateVeranstaltungsCollection(database);
            var teilnehmerCollection = Database.GetOrCreateTeilnehmerCollection(database);
            var triggerTimesCollection = Database.GetOrCreateTriggerTimesCollection(database);

            veranstaltungsCollection.Insert(veranstaltung1);

            teilNehmer2.AddTriggerTime(DateTime.Now, "Ch3");

            veranstaltungsCollection.Update(veranstaltung1);





            foreach (var teilnehmer in veranstaltung1.teilnehmerListe)
            {
                System.Console.WriteLine(teilnehmer.teilnehmerName + " Jahrgang:" + teilnehmer.jahrgang.ToString());
                foreach (var triggerTime in teilnehmer.racersTriggerTimes)
                {
                    System.Console.WriteLine($"{triggerTime.channel} at {triggerTime.triggerTime.ToString("dd.MM.yyyy HH:mm:ss.fffffff")}");
                }
            }
        }

    }
}