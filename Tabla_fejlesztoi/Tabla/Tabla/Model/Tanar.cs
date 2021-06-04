using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabla.Model
{
    public class Tanar
    {
        public Tanar(int id, string nev, string sajatOsztaly, List<string> tanitjaLista, int osztalyfonokE)
        {
            this.id = id;
            this.nev = nev;
            this.sajatOsztaly = sajatOsztaly;
            this.tanitjaLista = tanitjaLista;
            this.osztalyfonokE = osztalyfonokE;
        }
        public Tanar(int id, string nev, List<string> tanitjaLista, int osztalyfonokE)
        {
            this.id = id;
            this.nev = nev;
            this.tanitjaLista = tanitjaLista;
            this.osztalyfonokE = osztalyfonokE;
        }

        public int id { get; }
        public string nev { get; set; }
        public string sajatOsztaly { get; set; }
        public List<string> tanitjaLista { get; set; }
        public int osztalyfonokE { get; set; }

        

        
        
    }
}
