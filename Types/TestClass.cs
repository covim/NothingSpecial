using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Types
{
    public class TestClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<NummerMitBeschreibung> IntList { get; set; }


    }

    public class NummerMitBeschreibung
    {
        public int Id { get; set; }
        public string ZifferName { get; set; }
        public int Ziffer { get; set; }
    }
}
