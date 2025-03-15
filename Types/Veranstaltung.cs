using OfficeOpenXml;
using System.ComponentModel;
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
        public List<TriggerTimes> TriggerTimesListe { get; set; }



        public List<Teilnehmer> LeseTeilnehmerAusExcel(string dateipfad)
        {
            var teilnehmerListe = new List<Teilnehmer>();

            try
            {
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                using (var package = new ExcelPackage(new FileInfo(dateipfad)))
                {
                    var worksheet = package.Workbook.Worksheets[0]; // Erstes Arbeitsblatt
                    int rowCount = worksheet.Dimension.Rows;

                    for (int row = 2; row <= rowCount; row++) // Überspringt Kopfzeile
                    {
                        teilnehmerListe.Add(new Teilnehmer
                        {
                            Startnummer = int.Parse(worksheet.Cells[row, 1].Text),
                            Id = int.Parse(worksheet.Cells[row, 2].Text), // ÖSV-Code als ID nutzen
                            TeilnehmerName = worksheet.Cells[row, 3].Text,
                            Jahrgang = int.Parse(worksheet.Cells[row, 4].Text),
                            Verein = worksheet.Cells[row, 5].Text,
                            Klasse = worksheet.Cells[row, 6].Text
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Einlesen der Datei: {ex.Message}");
            }

            return teilnehmerListe;
        }
    }
}