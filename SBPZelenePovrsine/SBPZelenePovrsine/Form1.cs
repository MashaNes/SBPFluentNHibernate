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
                MessageBox.Show("Zelena površina uspešno sačuvana");
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
                    rez += "\n\n";
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

        private void btnZelenePovrsineDelete_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Travnjak t = s.Query<Travnjak>()
                              .Where(travnjak => travnjak.AdresaZgrade == "Ćele kula 10")
                              .FirstOrDefault();
                s.Close();

                s = DataLayer.GetSession();

                ZelenaPovrsina z = s.Get<ZelenaPovrsina>(t.Id);

                s.Delete(z);
                s.Flush();
                s.Close();
                MessageBox.Show("Uspešno obrisan travnjak na adresi 'Ćele kula 10'");
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }


        private void btnRadnikDelete_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Radnik radnik = s.Query<Radnik>()
                            .Where(r => r.BrRadneKnjizice == "213")
                            .SingleOrDefault();

                s.Delete(radnik);
                s.Flush();
                s.Close();
                MessageBox.Show("Uspešno obrisan radnik sa brojem radne knjižice 213.");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRadiUCreate_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Park p = new Park();
                p.Naziv = "Park na centralnom trgu";
                p.Opstina = "Niška Banja";
                p.TipPovrsine = "Park";
                p.ZonaUgrozenosti = "Zona niske ugroženosti";

                s.Save(p);
                s.Flush();

                Radnik r = new RadnikOdrzavanjeHigijene();
                r.Ime = "Milovan";
                r.ImeRoditelja = "Stojan";
                r.Prezime = "Novaković";
                r.BrRadneKnjizice = "687";
                r.MBr = "1206978730049";
                r.Adresa = "Strahinjića Bana 15, Niš";
                r.DatumRodjenja = new DateTime(1978, 6, 12);
                r.StrucnaSprema = "Treći stepen";

                s.Save(r);
                s.Flush();

                RadiU radiU = new RadiU();
                radiU.DatumOd = new DateTime(2015, 4, 23);
                radiU.Park = p;
                radiU.Radnik = r;

                s.Save(radiU);
                s.Flush();
                s.Close();

                MessageBox.Show("Stavka 'radi u' uspešno kreirana");
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnRadiUGet_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                List<RadiU> radi = s.Query<RadiU>()
                                    .Where(x => x.Radnik.BrRadneKnjizice == "120")
                                    .OrderBy(x => x.DatumOd)
                                    .ToList();
                String ispis = "";

                foreach (RadiU stavka in radi)
                {
                    String rez = stavka.DatumOd.ToShortDateString() + " do ";
                    rez += (stavka.DatumDo == null ? "sada: " : stavka.DatumDo.Value.ToShortDateString() + ": ");
                    rez += stavka.Park.Naziv + ", " + stavka.Park.Opstina + ", " + stavka.Park.ZonaUgrozenosti;
                    rez += "\n\n";
                    ispis += rez;
                }

                MessageBox.Show(ispis);
                s.Close();
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnJeSefCreate_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Park park = new Park();
                park.ZonaUgrozenosti = "Zona srednje ugroženosti";
                park.TipPovrsine = "Park";
                park.Opstina = "Medijana";
                park.Naziv = "Park kod Pravnog fakulteta";

                RadnikOdrzavanjeZelenila radnik = new RadnikOdrzavanjeZelenila();
                radnik.BrRadneKnjizice = "321";
                radnik.MBr = "2104979731014";
                radnik.Ime = "Ana";
                radnik.ImeRoditelja = "Ivan";
                radnik.Prezime = "Kostić";
                radnik.Adresa = "Cvijićeva 5, Niš";
                radnik.DatumRodjenja = new DateTime(1979, 4, 21);
                radnik.StrucnaSprema = "Treći stepen";

                s.Save(park);
                s.Save(radnik);
                s.Flush();

                RadiU radiU = new RadiU();
                radiU.Park = park;
                radiU.Radnik = radnik;
                radiU.DatumOd = new DateTime(2008, 1, 13);
                radiU.DatumDo = new DateTime(2018, 5, 20);

                s.Save(radiU);
                s.Flush();

                JeSef jeSef = new JeSef();
                jeSef.Park = park;
                jeSef.Radnik = radnik;
                jeSef.DatumOd = new DateTime(2015, 7, 11);
                jeSef.DatumDo = new DateTime(2016, 8, 20);

                s.Save(jeSef);
                s.Flush();
                s.Close();

                MessageBox.Show("Stavka 'je_šef' uspešno kreirana!");

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnJeSefGet_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                IList<JeSef> sefovanja = s.Query<JeSef>()
                                          .Where(js => js.Radnik.BrRadneKnjizice == "110")
                                          .OrderBy(js => js.DatumOd)
                                          .ToList();

                String message = "";

                foreach(JeSef js in sefovanja)
                {
                    String datumDo = (js.DatumDo != null) ? js.DatumDo.Value.ToShortDateString() : "sada";
                    message += "Od " + js.DatumOd.ToShortDateString() + " do " + datumDo + ": " + js.Park.Naziv + 
                               ", " + js.Park.Opstina + ", " + js.Park.ZonaUgrozenosti + "\n\n";
                }

                s.Close();
                MessageBox.Show(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnObjekatCreate_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Klupa klupa = new Klupa();
                klupa.RedniBroj = 5;

                Fontana fontana = new Fontana();
                fontana.RedniBroj = 6;

                Svetiljka svetiljka = new Svetiljka();
                svetiljka.RedniBroj = 7;

                Igraliste igraliste = new Igraliste();
                igraliste.RedniBroj = 8;
                igraliste.Pesak = "Ne";
                igraliste.StarostDeceOd = 5;
                igraliste.StarostDeceDo = 12;
                igraliste.BrojIgracaka = 7;

                Park park = s.Query<Park>()
                             .Where(x => x.Naziv == "Dečiji park u naselju Stevan Sinđelić" && x.Opstina == "Crveni krst")
                             .FirstOrDefault();

                klupa.Park = park;
                fontana.Park = park;
                svetiljka.Park = park;
                igraliste.Park = park;

                park.Objekti.Add(klupa);
                park.Objekti.Add(fontana);
                park.Objekti.Add(svetiljka);
                park.Objekti.Add(igraliste);

                s.Update(park);

                s.Flush();
                s.Close();

                MessageBox.Show("Objekti uspešno kreirani");
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnGetObjekat_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Park park = s.Query<Park>()
                             .Where(x => x.Naziv == "Dečiji park u naselju Stevan Sinđelić" && x.Opstina == "Crveni krst")
                             .FirstOrDefault();

                String rez = "";

                foreach (Objekat o in park.Objekti)
                {
                    rez += o.RedniBroj + ": ";
                    if (o.GetType() == typeof(Klupa))
                    {
                        rez += "Klupa";
                    }
                    else if (o.GetType() == typeof(Fontana))
                    {
                        rez += "Fontana";
                    }
                    else if (o.GetType() == typeof(Svetiljka))
                    {
                        rez += "Svetiljka";
                    }
                    else if (o.GetType() == typeof(Igraliste))
                    {
                        Igraliste i = o as Igraliste;
                        rez += "Igralište " + (i.BrojIgracaka == null ? "" : "sa " + i.BrojIgracaka + " igračaka ")
                            + "za decu od " + i.StarostDeceOd + " do " + i.StarostDeceDo + " godina";
                    }
                    // Dodati Spomenik, Skulpturu i Drvo (sa stampom i o zasticenosti)
                    rez += "\n\n";
                }

                MessageBox.Show(rez);
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
