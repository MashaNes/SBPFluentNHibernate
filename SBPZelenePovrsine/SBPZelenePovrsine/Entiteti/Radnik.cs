using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBPZelenePovrsine.Entiteti
{
    public abstract class Radnik
    {
        public virtual string BrRadneKnjizice { get; set; }
        public virtual string MBr { get; set; }
        public virtual string Ime { get; set; }
        public virtual string ImeRoditelja { get; set; }
        public virtual string Prezime { get; set; }
        public virtual string Adresa { get; set; }
        public virtual DateTime DatumRodjenja { get; set; }
        public virtual string StrucnaSprema { get; set; }
    }

    public class RadnikOdrzavanjeZelenila: Radnik
    {
  
    }

    public class RadnikOdrzavanjeHigijene: Radnik
    {

    }

    public class RadnikOdrzavanjeObjekataUParku: Radnik
    {

    }
}
