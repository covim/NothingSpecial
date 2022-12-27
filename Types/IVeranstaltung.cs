using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Types
{
    public interface IVeranstaltung
    {
        string veranstaltungsName { get; set; }
        string veranstaltungsOrt { get; set; }
        DateTime veranstaltungsDatum { get; set; }
        IEnumerable<ITeilnehmer> teilnehmerListe { get; set; }

    }
}
