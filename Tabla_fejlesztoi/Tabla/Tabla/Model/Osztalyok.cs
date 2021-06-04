using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabla.Model
{
    public class Osztalyok
    {
        public int id { get; }
        public string nev { get; set; }
        public int osztalyFonokID { get; set; }
        public Osztalyok(int id, string nev, int osztalyFonokID)
        {
            this.id = id;
            this.nev = nev;
            this.osztalyFonokID = osztalyFonokID;

        }
    }
}
