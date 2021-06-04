using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabla.Model
{
    class Jegyek
    {
        public int id { get; }
        public int jegy { get; set; }
        public int tantargyId { get; }
        public string datum { get; set; }
        public Jegyek(int id, int jegy, int tantargyId, string datum)
        {
            this.id = id;
            this.jegy = jegy;
            this.tantargyId = tantargyId;
            this.datum = datum;
        }

              

    }
}
