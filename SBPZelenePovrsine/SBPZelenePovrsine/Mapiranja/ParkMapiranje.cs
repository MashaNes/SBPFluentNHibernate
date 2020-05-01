using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBPZelenePovrsine.Entiteti;
using FluentNHibernate.Mapping;

namespace SBPZelenePovrsine.Mapiranja
{
    public class ParkMapiranje : SubclassMap<Park>
    {
        public ParkMapiranje()
        {
            Table("PARK");
            KeyColumn("ID");

            Map(x => x.Povrsina, "POVRSINA");
            Map(x => x.Naziv, "NAZIV");
        }
    }
}
