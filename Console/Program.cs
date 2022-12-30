using LiteDB;
using LiteDB_Class;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.IO.Ports;
using System.Xml;
using System.Xml.Xsl;
using TDC8000;
using Types;

namespace Console
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello, World!");
            System.IO.File.Delete(@"C:\Temp\MyData1.db");
            System.IO.File.Delete(@"C:\Temp\MyData1-log.db");
            int racerOnTrack = 0;

            //JustReadCom();


            var veranstaltung1 = GenerateDemoVeranstaltung();
            var Tdc8000 = new TDC8000Parser();

            SerialPort port = new SerialPort("COM5", 9600, Parity.None, 8, StopBits.One);
            port.Open();
            //for (int i = 0; i < 2; i++)
            while(true)
            {
                //System.Console.WriteLine(i);
                var stringFromStopwatch = port.ReadTo("\r");
                System.Console.WriteLine(stringFromStopwatch);
                if (Tdc8000.TDC8000ParseManager(stringFromStopwatch)) 
                {
                    veranstaltung1.TriggerTimesListe.Add(Tdc8000.AktuelleTriggerZeit);
                    veranstaltung1.ToString();
                    System.Console.WriteLine("Eingelesene Zeit: " + Tdc8000.AktuelleTriggerZeit.TriggerTime.ToString("HH:mm:ss.ffff"));
                }
                else 
                { 
                    racerOnTrack = Tdc8000.NextRacerToFinish;
                    System.Console.WriteLine("Nächster Läufer im Ziel: " + racerOnTrack.ToString());
                }        
            }

            port.Close();
            veranstaltung1.ToString();

            Teilnehmer.UpdateRaceTimes(veranstaltung1.TriggerTimesListe, veranstaltung1.TeilnehmerListe);
            
            var db = new LiteDatabase(@"C:\Temp\MyData1.db");
            var col = db.GetCollection<Veranstaltung>("Veranstaltung");

            Database.SaveDataToDB(veranstaltung1, col);


            var veranstaltungAusDb1 = Database.ReadAllDataFromDB(col);





        }




        public static Veranstaltung GenerateDemoVeranstaltung()
        {
            var veranstaltung1 = new Veranstaltung
            {
                Id = 1,
                VeranstaltungsName = "SuperVeranstaltung",
                TeilnehmerListe = new List<Teilnehmer>(),
                TriggerTimesListe = new List<TriggerTimes>()
            };

            var teilNehmer1 = new Teilnehmer { Id = 1, TeilnehmerName = "Matthias", Jahrgang = 1983, Startnummer = 2 };
            var teilNehmer2 = new Teilnehmer { Id = 2, TeilnehmerName = "Susanne", Jahrgang = 1981, Startnummer = 1 };
            veranstaltung1.TeilnehmerListe.Add(teilNehmer1);
            veranstaltung1.TeilnehmerListe.Add(teilNehmer2);
            //var triggerTime1 = new TriggerTimes { Id = 1, Startnummer = 1, Channel = "C0", Status = "normal", TriggerTime = DateTime.Now };
            //var triggerTime2 = new TriggerTimes { Id = 2, Startnummer = 1, Channel = "C1", Status = "normal", TriggerTime = DateTime.Now + TimeSpan.FromSeconds(2) };
            //veranstaltung1.TriggerTimesListe.Add(triggerTime1);
            //veranstaltung1.TriggerTimesListe.Add(triggerTime2);

            //string timeString1 = " 0002 C0  12:34:56.7891        ";
            //string timeString2 = " 0002 C1  12:35:57.0000        ";
            //string timeString3 = "?0001 C1  12:35:57.0000        ";
            //string timeString4 = "c0001 C1  12:35:57.0000        ";

            //var triggerTime3 = TDC8000Parser.TDC8000StringToTriggerTimes(timeString1);
            //var triggerTime4 = TDC8000Parser.TDC8000StringToTriggerTimes(timeString2);

            //veranstaltung1.TriggerTimesListe.Add(triggerTime3);
            //veranstaltung1.TriggerTimesListe.Add(triggerTime4);





            //var start = DateTime.Now;
            //Teilnehmer.UpdateRaceTimes(veranstaltung1.TriggerTimesListe, veranstaltung1.TeilnehmerListe);
            //var stop = DateTime.Now;

            //var dauer = stop - start;
            //System.Console.WriteLine(dauer.ToString());
            return veranstaltung1;

        }

        public static void JustReadCom()
        {
            SerialPort port = new SerialPort("COM5", 9600, Parity.None, 8, StopBits.One);
            port.Open();
            while (true)
            {
                
                var stringFromStopwatch = port.ReadTo("\r");
                System.Console.WriteLine(stringFromStopwatch);

            }

            port.Close();
        }


    }
}