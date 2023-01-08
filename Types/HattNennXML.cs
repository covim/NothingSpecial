// using System.Xml.Serialization;
// XmlSerializer serializer = new XmlSerializer(typeof(Nennungsdatei));
// using (StringReader reader = new StringReader(xml))
// {
//    var test = (Nennungsdatei)serializer.Deserialize(reader);
// }

public class Software
{
    public string? Hersteller { get; set; }
    public string? EMail { get; set; }
    public double Version { get; set; }
    public string? Text { get; set; }
}

public class Renndatum
{
    public int Tag { get; set; }
    public int Monat { get; set; }
    public int Jahr { get; set; }
}

public class Renndaten
{
    public string Kategorie { get; set; }
    public string GenNummer { get; set; }
    public string Punkterennen { get; set; }
    public string Bewerbsart { get; set; }
    public int BewerbsNr { get; set; }
    public string Rennort { get; set; }
    public string OESVListe { get; set; }
    public Renndatum Renndatum { get; set; }
}

public class NennungsErsteller
{
    public string VereinVerband { get; set; }
    public string Sportwart { get; set; }
    public string Strasse { get; set; }
    public object PLZ { get; set; }
    public object Ort { get; set; }
    public string Telefon { get; set; }
}

public class Geburtsdatum
{
    public int Tag { get; set; }
    public int Monat { get; set; }
    public int Jahr { get; set; }
}

public class OESVPunkte
{
    public double AL { get; set; }
    public double SL { get; set; }
    public double RSL { get; set; }
    public double SG { get; set; }
}

public class StarterIn
{
    public int OESVCode { get; set; }
    public string Nachname { get; set; }
    public string Vorname { get; set; }
    public string Geschl { get; set; }
    public Geburtsdatum Geburtsdatum { get; set; }
    public OESVPunkte OESVPunkte { get; set; }
}

public class Nennungsabgabe
{
    public List<StarterIn> StarterIn { get; set; }
}

public class Nennungsdatei
{
    public Software Software { get; set; }
    public Renndaten Renndaten { get; set; }
    public NennungsErsteller NennungsErsteller { get; set; }
    public Nennungsabgabe Nennungsabgabe { get; set; }
}

