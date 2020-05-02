using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using SBPZelenePovrsine.Entiteti;

namespace SBPZelenePovrsine.Mapiranja
{
    public class RadnikMapiranja: ClassMap<Radnik>
    {
        public RadnikMapiranja()
        {
            Table("RADNIK");

            DiscriminateSubClassesOnColumn("TIP_ANGAZOVANJA");

            Id(x => x.BrRadneKnjizice, "BR_RADNE_KNJIZICE").GeneratedBy.Assigned();

            Map(x => x.MBr, "MBR"); //Da li treba dodati Unique, radi sigurnosti?
            Map(x => x.Ime, "IME");
            Map(x => x.ImeRoditelja, "IME_RODITELJA");
            Map(x => x.Prezime, "PREZIME");
            Map(x => x.Adresa, "ADRESA");
            Map(x => x.DatumRodjenja, "DATUM_RODJENJA");
            Map(x => x.StrucnaSprema, "STRUCNA_SPREMA");
        }
    }

    public class RadnikOdrzavanjeZelenilaMapiranja: SubclassMap<RadnikOdrzavanjeZelenila>
    {
        public RadnikOdrzavanjeZelenilaMapiranja()
        { 
            DiscriminatorValue("Održavanje zelenila");
        }
    }

    public class RadnikOdrzavanjeHigijeneMapiranja : SubclassMap<RadnikOdrzavanjeHigijene>
    {
        public RadnikOdrzavanjeHigijeneMapiranja()
        {
            DiscriminatorValue("Održavanje higijene");
        }
    }

    public class RadnikOdrzavanjeObjekataUParkuMapiranja : SubclassMap<RadnikOdrzavanjeObjekataUParku>
    {
        public RadnikOdrzavanjeObjekataUParkuMapiranja()
        {
            DiscriminatorValue("Održavanje objekata u parku");
        }
    }
}
