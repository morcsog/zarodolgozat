using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabla.Model
{
    public class Diak
    {
        public int id { get; }
        public string nev {get; set;}
        public string osztalyId { get; }
        public List<int> hianyzasId { get; }
        public List<int> tanarId { get; }
        public List<int> jegyekID { get; }
        public List<int> tantargyakId { get; }
        public int osztalyfonokId { get; }

        public Diak(int id, string nev, string osztalyId, List<int> hianyzasId, List<int> tanarId, List<int> jegyekID, List<int> tantargyakId, int osztalyfonokId)
        {
            this.id = id;
            this.nev = nev;
            this.osztalyId = osztalyId;
            this.hianyzasId = hianyzasId;
            this.tanarId = tanarId;
            this.jegyekID = jegyekID;
            this.tantargyakId = tantargyakId;
            this.osztalyfonokId = osztalyfonokId;
        }

        public Diak(int id, string nev, string osztalyId)
        {
            this.id = id;
            this.nev = nev;
            this.osztalyId = osztalyId;
        }
        public Diak()
        {

        }
    }
}
