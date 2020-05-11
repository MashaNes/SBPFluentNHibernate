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

                IQuery q = s.CreateQuery("select min(r.BrRadneKnjizice) from Radnik r");
                string brKnjizice = q.UniqueResult<string>();

                Radnik radnik = s.Query<Radnik>()
                            .Where(r => r.BrRadneKnjizice == brKnjizice)
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

                /*Park park = s.Query<Park>()
                             .Where(x => x.Naziv == "Dečiji park u naselju Stevan Sinđelić" && x.Opstina == "Crveni krst")
                             .FirstOrDefault();*/

                /*Park park = s.Query<Park>()
                             .Where(p => p.Naziv == "Park Čair" && p.Opstina == "Medijana")
                             .FirstOrDefault();*/

                Park park = s.Query<Park>()
                             .Where(p => p.Naziv == "Tvrđava" && p.Opstina == "Crveni krst")
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
                    else if (o.GetType() == typeof(Spomenik))
                    {
                        Spomenik sp = o as Spomenik;
                        Zasticen spZastita = sp.Zasticen;
                        rez += "Spomenik, zaštićen datuma " + spZastita.DatumStavljanja.ToShortDateString() + " od strane institucije \"" +
                                spZastita.Institucija + "\", uz opis: \"" + spZastita.Opis +
                                "\". Godišnja novčana naknada za potrebe zaštite ovog spomenika iznosi " + spZastita.NovcanaNaknada + " dinara.";
                    }
                    else if (o.GetType() == typeof(Skulptura))
                    {
                        Skulptura sk = o as Skulptura;
                        Zasticen skZastita = sk.Zasticen;
                        rez += "Skulptura, zaštićena datuma " + skZastita.DatumStavljanja.ToShortDateString() + " od strane institucije \"" +
                                skZastita.Institucija + "\", uz opis: \"" + skZastita.Opis +
                                "\". Godišnja novčana naknada za potrebe zaštite ove skulpture iznosi " + skZastita.NovcanaNaknada + " dinara.";
                    }
                    else if(o.GetType() == typeof(Drvo))
                    {
                        Drvo d = o as Drvo;
                        Zasticen dZastita = d.Zasticen;
                        rez += "Drvo, vrste " + d.Vrsta + (d.ObimDebla == null ? "" : ", obima debla " + d.ObimDebla + " metara")
                                + (d.PovrsinaPokrivanja == null ? "" : ", površine pokrivanja " + d.PovrsinaPokrivanja + " metara")
                                + (d.VisinaKrosnje == null ? "" : ", visine krošnje " + d.VisinaKrosnje + " metara")
                                + (d.DatumSadnje == null ? "" : " , posađeno datuma " + d.DatumSadnje.Value.ToShortDateString()) + ".";
                        if(dZastita != null)
                            rez += "Drvo je zaštićeno datuma " + dZastita.DatumStavljanja.ToShortDateString() + " od strane institucije \"" +
                                dZastita.Institucija + "\", uz opis: \"" + dZastita.Opis +
                                "\". Godišnja novčana naknada za za potrebe zaštite ovog drveta iznosi " + dZastita.NovcanaNaknada + " dinara.";
                    }
                    rez += "\n\n";
                }

                MessageBox.Show(rez);
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnZasticenObjekatCreate_Click(object sender, EventArgs e)
        {
            try
            {
                
                ISession s = DataLayer.GetSession();

                Zasticen zastitaSpomenik = new Zasticen();
                zastitaSpomenik.Opis = "Bali-begova džamija u Tvrđavi predstavlja jedan od najvažnijih spomenika u Nišu podignutih za vreme vladavine Turaka.";
                zastitaSpomenik.NovcanaNaknada = 7000;
                zastitaSpomenik.Institucija = "Gradski zavod za zaštitu kulturne svojine";
                zastitaSpomenik.DatumStavljanja = new DateTime(2004, 12, 7);


                Zasticen zastitaSkulptura = new Zasticen();
                zastitaSkulptura.Opis = "Skulptura pauna u parku Čair, jedinstvena po svojoj strukturi, s obzirom na to da je nastala oblikovanjem žbunastih biljaka";
                zastitaSkulptura.NovcanaNaknada = 12000;
                zastitaSkulptura.Institucija = "Niški kulturni centar";
                zastitaSkulptura.DatumStavljanja = new DateTime(2019, 7, 14);

                Zasticen zastitaDrvo = new Zasticen();
                zastitaDrvo.Opis = "Breza, stara preko šezdeset godina, predstavlja jedan u nizu značajnih prirodnih spomenika u Nišu";
                zastitaDrvo.NovcanaNaknada = 9000;
                zastitaDrvo.Institucija = "Zavod za zaštitu životne sredine";
                zastitaDrvo.DatumStavljanja = new DateTime(2014, 4, 5);

                Park parkTvrdjava = s.Query<Park>()
                                           .Where(p => p.Naziv == "Tvrđava" && p.Opstina == "Crveni krst")
                                           .Single();

                Park parkCair = s.Query<Park>()
                                 .Where(p => p.Naziv == "Park Čair" && p.Opstina == "Medijana")
                                 .Single();

                IQuery qSpomenik = s.CreateQuery("select max(o.RedniBroj) from Objekat o where o.Park.Id = " + parkTvrdjava.Id);
                IQuery qSkulptura = s.CreateQuery("select max(o.RedniBroj) from Objekat o where o.Park.Id = " + parkCair.Id);

                int rBrSpomenik = qSpomenik.UniqueResult<int>() + 1;
                int rBrSkulptura = qSkulptura.UniqueResult<int>() + 1;

                int rBrDrvo = rBrSkulptura + 1;

                Spomenik spomenik = new Spomenik();
                spomenik.RedniBroj = rBrSpomenik;
                spomenik.Park = parkTvrdjava;
                spomenik.Zasticen = zastitaSpomenik;

                Skulptura skulptura = new Skulptura();
                skulptura.RedniBroj = rBrSkulptura;
                skulptura.Park = parkCair;
                skulptura.Zasticen = zastitaSkulptura;

                Drvo drvo = new Drvo();
                drvo.RedniBroj = rBrDrvo;
                drvo.Park = parkCair;
                drvo.Zasticen = zastitaDrvo;
                drvo.DatumSadnje = new DateTime(1953, 3, 12);
                drvo.ObimDebla = 2.22f;
                drvo.VisinaKrosnje = 18;
                drvo.PovrsinaPokrivanja = 8.2f;
                drvo.Vrsta = "Breza";

                parkTvrdjava.Objekti.Add(spomenik);
                parkCair.Objekti.Add(skulptura);
                parkCair.Objekti.Add(drvo);

                s.Update(parkTvrdjava);
                s.Update(parkCair);

                s.Save(spomenik);
                s.Save(skulptura);
                s.Save(drvo);
                s.Flush();
                s.Close();

                MessageBox.Show("Uspešno kreirani zaštićeni objekti.");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
