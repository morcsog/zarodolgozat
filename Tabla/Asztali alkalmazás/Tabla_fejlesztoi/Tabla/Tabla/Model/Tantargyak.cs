using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabla.Model
{
    class Tantargyak
    {
        public Tantargyak(int id, string nev, List<int> tanarId)
        {
            this.id = id;
            this.nev = nev;
            this.tanarId = tanarId;
        }

        public int id { get; }
        public string nev { get; set; }
        public List<int> tanarId { get; }
    }
}
