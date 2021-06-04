using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabla.Model
{
    class Hianyzas
    {
        public int id { get; }
        public string datum { get; set; }
        public int oraszam { get; set; }

        public int diakId { get;  }
        public Hianyzas(int id, string datum, int oraszam, int diakId)
        {
            this.id = id;
            this.datum = datum;
            this.oraszam = oraszam;
            this.diakId = diakId;
        }

        


    }
}
