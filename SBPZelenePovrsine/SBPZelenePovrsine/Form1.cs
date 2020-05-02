using NHibernate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SBPZelenePovrsine.Entiteti;

namespace SBPZelenePovrsine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnZelenePovrsineCreate_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Travnjak travnjak = new Travnjak();
                travnjak.ZonaUgrozenosti = "Zona visoke ugroženosti";
                travnjak.Opstina = "Medijana";
                travnjak.TipPovrsine = "Travnjak";

                travnjak.AdresaZgrade = "Ćele kula 10";
                travnjak.Povrsina = 0.3f;

                s.Save(travnjak);
                s.Flush();
                s.Close();
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnGetZelenePovrsine_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                String rez = "";

                IList<ZelenaPovrsina> lista = s.QueryOver<ZelenaPovrsina>().List<ZelenaPovrsina>();

                foreach (ZelenaPovrsina zp in lista)
                {
                    rez += zp.Id + ": " + zp.TipPovrsine + ", " + zp.Opstina + ", " + zp.ZonaUgrozenosti;
                    if (zp.GetType() == typeof(Travnjak))
                    {
                        Travnjak t = (Travnjak)zp;
                        rez += ", " + t.AdresaZgrade + ", " + t.Povrsina;
                    }
                    else if (zp.GetType() == typeof(Drvored))
                    {
                        Drvored d = (Drvored)zp;
                        rez += ", " + d.Ulica + ", " + d.Duzina + ", " + d.BrojStabala + ", " + d.VrstaDrveta;
                    }
                    else if (zp.GetType() == typeof(Park))
                    {
                        Park p = (Park)zp;
                        rez += ", " + p.Naziv + ", " + p.Povrsina;
                    }
                    rez += "\n";
                }

                MessageBox.Show(rez);

                s.Close();
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnGetRadnici_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                IList<Radnik> radnici = s.QueryOver<Radnik>().List<Radnik>();

                string ispis = "";

                foreach (Radnik r in radnici)
                {
                    ispis += r.BrRadneKnjizice + ": " + r.MBr + ", " + r.Ime + " (" + r.ImeRoditelja + ") " +
                        r.Prezime + ", " + r.Adresa + ", " + r.StrucnaSprema + ", ";

                    
                    if (r.GetType() == typeof(RadnikOdrzavanjeZelenila))
                    {
                        RadnikOdrzavanjeZelenila radnikZelenilo = (RadnikOdrzavanjeZelenila)r;
                        ispis += "radnik na održavanju zelenila.\n\n";
                    }
                    else if (r.GetType() == typeof(RadnikOdrzavanjeHigijene))
                    {
                        RadnikOdrzavanjeHigijene radnikHigijena = (RadnikOdrzavanjeHigijene)r;
                        ispis += "radnik na održavanju higijene.\n\n";
                    }
                    else if (r.GetType() == typeof(RadnikOdrzavanjeObjekataUParku))
                    {
                        RadnikOdrzavanjeObjekataUParku rPark = (RadnikOdrzavanjeObjekataUParku)r;
                        ispis += "radnik na održavanju objekata u parku.\n\n";
                    }
                    

                }

                MessageBox.Show(ispis);

                s.Close();
            }

            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

        }

        private void btnRadniciCreate_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                RadnikOdrzavanjeHigijene radnikHigijena = new RadnikOdrzavanjeHigijene();
                radnikHigijena.BrRadneKnjizice = "213";
                radnikHigijena.MBr = "1402988730891";
                radnikHigijena.Ime = "Kosta";
                radnikHigijena.ImeRoditelja = "Stevan";
                radnikHigijena.Prezime = "Kostić";
                radnikHigijena.Adresa = "Bulevar Nemanjića 12/7, Niš";
                radnikHigijena.DatumRodjenja = new DateTime(1988, 2, 14).Date;
                radnikHigijena.StrucnaSprema = "Četvrti stepen";

                s.Save(radnikHigijena);
                s.Flush();
                s.Close();

                MessageBox.Show("Radnik uspešno sačuvan!");
            }
            
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
