using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBPZelenePovrsine.Entiteti
{
    public class Park : ZelenaPovrsina
    {
        public virtual float? Povrsina { get; set; }
        public virtual String Naziv { get; set; }

        public virtual IList<RadiU> Radnici { get; set; }

        public Park()
        {
            Radnici = new List<RadiU>();
        }
    }
}
