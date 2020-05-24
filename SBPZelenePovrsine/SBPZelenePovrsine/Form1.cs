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
    public partial class frmZelenePovrsine : Form
    {
        public frmZelenePovrsine()
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
                    rez += zp.Id + ": " + zp.TipPovrsine + ", opština " + zp.Opstina + ", " + zp.ZonaUgrozenosti;
                    if (zp.GetType() == typeof(Travnjak))
                    {
                        Travnjak t = (Travnjak)zp;
                        rez += ", " + t.AdresaZgrade + (t.Povrsina == null? "" : ", površina u arima - " + t.Povrsina);
                    }
                    else if (zp.GetType() == typeof(Drvored))
                    {
                        Drvored d = (Drvored)zp;
                        rez += ", " + d.Ulica + ", " + d.VrstaDrveta 
                            + (d.Duzina == null? "" : ", dužina u metrima - " + d.Duzina) 
                            + (d.BrojStabala == null? "" : ", broj stabala - " + d.BrojStabala);
                    }
                    else if (zp.GetType() == typeof(Park))
                    {
                        Park p = (Park)zp;
                        rez += ", " + p.Naziv 
                            + (p.Povrsina == null? "" : ", pavršina u hetarima - " + p.Povrsina);
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
                    ispis += r.BrRadneKnjizice + ": " + r.MBr + ", " + r.Ime + " (" + r.ImeRoditelja + ") "
                          + r.Prezime + ", " + r.Adresa + ", " + r.StrucnaSprema + ", "
                          + (r.DatumRodjenja == null ? "" : r.DatumRodjenja.Value.ToShortDateString() + ", ");

                    
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

                Random random = new Random();

                RadnikOdrzavanjeHigijene radnikHigijena = new RadnikOdrzavanjeHigijene();
                radnikHigijena.BrRadneKnjizice = random.Next(100, 1000).ToString();

                int dan = random.Next(1, 32);
                int mesec = random.Next(1, 13);
                if (dan == 31 && (mesec == 4 || mesec == 6 || mesec == 9 || mesec == 11))
                    dan--;
                else if (mesec == 2 && dan > 28)
                    dan = 28;
                int godina = 1900 + random.Next(56,102);
                radnikHigijena.DatumRodjenja = new DateTime(godina, mesec, dan).Date;

                String mbr = (dan < 10 ? "0" + dan : dan.ToString())
                           + (mesec < 10 ? "0" + mesec : mesec.ToString())
                           + (godina < 2000? (godina-1000).ToString(): "00" + (godina-2000).ToString());
                mbr += random.Next(10, 100).ToString();
                mbr += "0";
                int kraj = random.Next(10, 1000);
                mbr += (kraj < 100 ? "0" + kraj : kraj.ToString());               
                radnikHigijena.MBr = mbr;

                radnikHigijena.Ime = "Kosta";
                radnikHigijena.ImeRoditelja = "Stevan";
                radnikHigijena.Prezime = "Kostić";
                radnikHigijena.Adresa = "Bulevar Nemanjića 12/7, Niš";
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
                              .OrderByDescending(x => x.Id)
                              .FirstOrDefault();
                String adresa = t.AdresaZgrade;

                s.Delete(t);
                s.Flush();
                s.Close();
                MessageBox.Show("Uspešno obrisan travnjak na adresi '" + adresa + "'");
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

                if(brKnjizice == "110" || brKnjizice == "120")
                {
                    q = s.CreateQuery("select max(r.BrRadneKnjizice) from Radnik r");
                    brKnjizice = q.UniqueResult<string>();
                }

                Radnik radnik = s.Get<Radnik>(brKnjizice);

                s.Delete(radnik);
                s.Flush();
                s.Close();
                MessageBox.Show("Uspešno obrisan radnik sa brojem radne knjižice " + brKnjizice + ".");
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

                String NazivParka = "Park na centralnom trgu";
                String Opstina = "Niška Banja";

                Park park = s.Query<Park>()
                             .Where(x => x.Naziv == NazivParka && x.Opstina == Opstina)
                             .FirstOrDefault();

                if(park == null)
                {
                    park = new Park();
                    park.Naziv = NazivParka;
                    park.Opstina = Opstina;
                    park.TipPovrsine = "Park";
                    park.ZonaUgrozenosti = "Zona niske ugroženosti";

                    s.Save(park);
                    s.Flush();
                }

                String brojRadneKnjizice = "687";
                Radnik r = s.Get<Radnik>(brojRadneKnjizice);

                if(r == null)
                {
                    r = new RadnikOdrzavanjeHigijene();
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
                }

                DateTime datum = s.Query<RadiU>()
                                  .Where(x => x.Radnik == r)
                                  .OrderBy(x => x.DatumOd)
                                  .Select(x => x.DatumOd)
                                  .FirstOrDefault();

                RadiU radiU = new RadiU();

                if (datum.Year == 1)
                {
                    radiU.DatumOd = new DateTime(2015, 4, 23);
                }
                else
                {
                    if(datum.Day != 1)
                        radiU.DatumDo = new DateTime(datum.Year, datum.Month, datum.Day - 1);
                    else if(datum.Month != 1)
                        radiU.DatumDo = new DateTime(datum.Year, datum.Month - 1, datum.Day);
                    else
                        radiU.DatumDo = new DateTime(datum.Year - 1, 12, datum.Day);
                    radiU.DatumOd = new DateTime(datum.Year - 1, datum.Month, datum.Day);
                }
                
                radiU.Park = park;
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
                String brojRadneKnjizice = "120";
                ISession s = DataLayer.GetSession();
                List<RadiU> radi = s.Query<RadiU>()
                                    .Where(x => x.Radnik.BrRadneKnjizice == brojRadneKnjizice)
                                    .OrderBy(x => x.DatumOd)
                                    .ToList();
                String ispis = "";

                foreach (RadiU stavka in radi)
                {
                    if(ispis == "")
                    {
                        Radnik r = stavka.Radnik;
                        ispis += "Radnik " + r.Ime + " (" + r.ImeRoditelja + ") " + r.Prezime
                              + " radio je u sledećim parkovima u navedenom periodu:\n\n";
                    }
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

                String NazivParka = "Park kod Pravnog fakulteta";
                String Opstina = "Medijana";

                Park park = s.Query<Park>()
                             .Where(x => x.Naziv == NazivParka && x.Opstina == Opstina)
                             .FirstOrDefault();

                if(park == null)
                {
                    park = new Park();
                    park.ZonaUgrozenosti = "Zona srednje ugroženosti";
                    park.TipPovrsine = "Park";
                    park.Opstina = Opstina;
                    park.Naziv = NazivParka;
                    s.Save(park);
                }

                String brojRadneKnjizice = "321";
                Radnik radnik = s.Get<Radnik>(brojRadneKnjizice);

                if(radnik == null)
                {
                    radnik = new RadnikOdrzavanjeZelenila();
                    radnik.BrRadneKnjizice = "321";
                    radnik.MBr = "2104979731014";
                    radnik.Ime = "Ana";
                    radnik.ImeRoditelja = "Ivan";
                    radnik.Prezime = "Kostić";
                    radnik.Adresa = "Cvijićeva 5, Niš";
                    radnik.DatumRodjenja = new DateTime(1979, 4, 21);
                    radnik.StrucnaSprema = "Treći stepen";
                    s.Save(radnik);
                }

                s.Flush();

                RadiU radiU = new RadiU();
                radiU.Park = park;
                radiU.Radnik = radnik;

                DateTime datum = s.Query<RadiU>()
                                  .Where(x => x.Radnik == radnik)
                                  .OrderBy(x => x.DatumOd)
                                  .Select(x => x.DatumOd)
                                  .FirstOrDefault();

                if (datum.Year == 1)
                {
                    radiU.DatumOd = new DateTime(2016, 1, 13);
                    radiU.DatumDo = new DateTime(2018, 5, 20);
                }
                else
                {
                    if (datum.Day != 1)
                        radiU.DatumDo = new DateTime(datum.Year, datum.Month, datum.Day - 1);
                    else if (datum.Month != 1)
                        radiU.DatumDo = new DateTime(datum.Year, datum.Month - 1, datum.Day);
                    else
                        radiU.DatumDo = new DateTime(datum.Year - 1, 12, datum.Day);
                    radiU.DatumOd = new DateTime(datum.Year - 2, datum.Month, datum.Day);
                }

                s.Save(radiU);
                s.Flush();

                JeSef jeSef = new JeSef();
                jeSef.Park = park;
                jeSef.Radnik = radnik;
                jeSef.DatumOd = new DateTime(radiU.DatumOd.Year + 1, radiU.DatumOd.Month, radiU.DatumOd.Day);
                jeSef.DatumDo = radiU.DatumDo;

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
                String brojRadneKnjizice = "110";
                ISession s = DataLayer.GetSession();

                IList<JeSef> sefovanja = s.Query<JeSef>()
                                          .Where(js => js.Radnik.BrRadneKnjizice == brojRadneKnjizice)
                                          .OrderBy(js => js.DatumOd)
                                          .ToList();

                String message = "";

                foreach(JeSef js in sefovanja)
                {
                    if (message == "")
                    {
                        Radnik r = js.Radnik;
                        message += "Radnik " + r.Ime + " (" + r.ImeRoditelja + ") " + r.Prezime
                                + " bio je šef sledećih parkova u navedenom periodu:\n\n";
                    }
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

                String NazivParka = "Dečiji park u naselju Stevan Sinđelić";
                String Opstina = "Crveni krst";
                int maxRedniBroj = s.Query<Objekat>()
                                    .Where(x => x.Park.Naziv == NazivParka && x.Park.Opstina == Opstina)
                                    .OrderByDescending(x => x.RedniBroj)
                                    .Select(x => x.RedniBroj)
                                    .FirstOrDefault();

                Klupa klupa = new Klupa();
                klupa.RedniBroj = maxRedniBroj + 1;

                Fontana fontana = new Fontana();
                fontana.RedniBroj = maxRedniBroj + 2;

                Svetiljka svetiljka = new Svetiljka();
                svetiljka.RedniBroj = maxRedniBroj + 3;

                Igraliste igraliste = new Igraliste();
                igraliste.RedniBroj = maxRedniBroj + 4;
                igraliste.Pesak = "Ne";
                igraliste.StarostDeceOd = 5;
                igraliste.StarostDeceDo = 12;
                igraliste.BrojIgracaka = 7;

                Park park = s.Query<Park>()
                             .Where(x => x.Naziv == NazivParka && x.Opstina == Opstina)
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

                String NazivParka = "Tvrđava"; // ili "Dečiji park u naselju Stevan Sinđelić" ili "Park Čair"
                String Opstina = "Crveni krst"; // ili "Crveni krst" ili "Medijana"

                List<Objekat> objekti = s.Query<Objekat>()
                                         .Where(o => o.Park.Naziv == NazivParka && o.Park.Opstina == Opstina)
                                         .OrderBy(o => o.RedniBroj)
                                         .ToList();

                String rez = "Objekti u parku " + NazivParka + ", u opštini " + Opstina + "\n\n\n";

                foreach(Objekat o in objekti)
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
                        rez += "Spomenik, zaštićen datuma " + spZastita.DatumStavljanja.ToShortDateString() 
                            + " od strane institucije \"" + spZastita.Institucija 
                            + "\", uz opis: \"" + spZastita.Opis 
                            + "\". Godišnja novčana naknada za potrebe zaštite ovog spomenika iznosi " 
                            + spZastita.NovcanaNaknada + " dinara.";
                    }
                    else if (o.GetType() == typeof(Skulptura))
                    {
                        Skulptura sk = o as Skulptura;
                        Zasticen skZastita = sk.Zasticen;
                        rez += "Skulptura, zaštićena datuma " + skZastita.DatumStavljanja.ToShortDateString() 
                            + " od strane institucije \"" + skZastita.Institucija
                            + "\", uz opis: \"" + skZastita.Opis 
                            + "\". Godišnja novčana naknada za potrebe zaštite ove skulpture iznosi " 
                            + skZastita.NovcanaNaknada + " dinara.";
                    }
                    else if(o.GetType() == typeof(Drvo))
                    {
                        Drvo d = o as Drvo;
                        Zasticen dZastita = d.Zasticen;
                        
                        rez += "Drvo, vrste " + d.Vrsta 
                            + (d.ObimDebla == null ? "" : ", obima debla " + d.ObimDebla + " metara")
                            + (d.PovrsinaPokrivanja == null ? "" : ", površine pokrivanja " + d.PovrsinaPokrivanja + " metara")
                            + (d.VisinaKrosnje == null ? "" : ", visine krošnje " + d.VisinaKrosnje + " metara")
                            + (d.DatumSadnje == null ? "" : " , posađeno datuma " + d.DatumSadnje.Value.ToShortDateString()) + ".";
                        if(dZastita != null)
                            rez += " Drvo je zaštićeno datuma " + dZastita.DatumStavljanja.ToShortDateString() 
                                + " od strane institucije \"" + dZastita.Institucija 
                                + "\", uz opis: \"" + dZastita.Opis 
                                + "\". Godišnja novčana naknada za potrebe zaštite ovog drveta iznosi " 
                                + dZastita.NovcanaNaknada + " dinara.";
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

                String nazivParka = "Tvrđava";
                String Opstina = "Crveni krst";

                Park parkTvrdjava = s.Query<Park>()
                                     .Where(p => p.Naziv == nazivParka && p.Opstina == Opstina)
                                     .Single();

                nazivParka = "Park Čair";
                Opstina = "Medijana";

                Park parkCair = s.Query<Park>()
                                 .Where(p => p.Naziv == nazivParka && p.Opstina == Opstina)
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

                s.Flush();
                s.Close();

                MessageBox.Show("Uspešno kreirani zaštićeni objekti.");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGetZasticeniObjekti_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                IList<Zasticen> zasticeni = s.Query<Zasticen>().ToList();

                string message = "";
                string messageEnd = "";

                foreach(Zasticen z in zasticeni)
                {
                    if(z.Objekat.GetType() == typeof(Spomenik))
                    {
                        message += "Spomenik, stavljen pod zaštitu datuma ";
                        messageEnd = "Spomenik se nalazi u parku \"" + z.Objekat.Park.Naziv +
                                      "\", a godišnja novčana naknada za potrebe održavanja ovog spomenika iznosi "; 
                    }
                    else if(z.Objekat.GetType() == typeof(Skulptura))
                    {
                        message += "Skulptura, stavljena pod zaštitu datuma ";
                        messageEnd = "Skulptura se nalazi u parku \"" + z.Objekat.Park.Naziv +
                                      "\", a godišnja novčana naknada za potrebe održavanja ove skulputre iznosi ";
                    }
                    else if(z.Objekat.GetType() == typeof(Drvo))
                    {
                        message += "Drvo, stavljeno pod zaštitu datuma ";
                        messageEnd = "Drvo se nalazi u parku \"" + z.Objekat.Park.Naziv +
                                      "\", a godišnja novčana naknada za potrebe održavanja ovog drveta iznosi ";
                    }

                    message += z.DatumStavljanja.ToShortDateString() + ", od strane institucije " +
                               z.Institucija + ", uz opis \"" + z.Opis + "\". " + messageEnd + z.NovcanaNaknada + " dinara.\n\n";
                }

                s.Close();
                MessageBox.Show(message);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGetZasticeniObjektiUParku_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                string nazivParka = "Tvrđava"; 
                string nazivOpstine = "Crveni krst";

                //Za park i opštinu, rezultate daju i kombinacije :
                // 1. "Park Čair" i "Medijana" 
                // 2. "Park Svetog Save" i "Medijana"

                List<Zasticen> zasticeni = s.Query<Zasticen>()
                                            .Where(z => z.Objekat.Park.Naziv == nazivParka && z.Objekat.Park.Opstina == nazivOpstine)
                                            .OrderBy(z => z.Objekat.RedniBroj)
                                            .ToList();

                string message = "Zaštićeni objekti u parku " + nazivParka + ", u opštini " + nazivOpstine + "\n\n\n";
                string messageEnd = "";

                foreach(Zasticen z in zasticeni)
                {
                    if (z.Objekat.GetType() == typeof(Spomenik))
                    {
                        message += "Spomenik, stavljen pod zaštitu datuma ";
                        messageEnd ="Godišnja novčana naknada za potrebe održavanja ovog spomenika iznosi ";
                    }
                    else if (z.Objekat.GetType() == typeof(Skulptura))
                    {
                        message += "Skulptura, stavljena pod zaštitu datuma ";
                        messageEnd = "Godišnja novčana naknada za potrebe održavanja ove skulputre iznosi ";
                    }
                    else if (z.Objekat.GetType() == typeof(Drvo))
                    {
                        message += "Drvo, stavljeno pod zaštitu datuma ";
                        messageEnd = "Godišnja novčana naknada za potrebe održavanja ovog drveta iznosi ";
                    }

                    message += z.DatumStavljanja.ToShortDateString() + ", od strane institucije " +
                               z.Institucija + ", uz opis \"" + z.Opis + "\". " + messageEnd + z.NovcanaNaknada + " dinara.\n\n";
                }

                s.Close();
                MessageBox.Show(message);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnGetParkInfo_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                string nazivParka = "Tvrđava";
                string nazivOpstine = "Crveni krst";

                Park p = s.Query<Park>()
                          .Where(x => x.Naziv == nazivParka && x.Opstina == nazivOpstine)
                          .FirstOrDefault();

                String ispis = "Park " + p.Naziv + " u opštini " + p.Opstina + ":\n\n";
                ispis += "Radnici koji trenutno rade u tom parku:\n";

                List<RadiU> radiU = p.Radnici.Where(x => x.DatumDo == null).ToList();

                foreach (RadiU stavka in radiU)
                {
                    ispis += stavka.Radnik.BrRadneKnjizice + " " + stavka.Radnik.Ime + " ("
                          + stavka.Radnik.ImeRoditelja + ") " + stavka.Radnik.Prezime
                          + " počeo sa radom " + stavka.DatumOd.ToShortDateString() + "\n";
                }

                ispis += "\nŠef parka je ";
                JeSef trenutniSef = p.Sefovi.Where(x => x.DatumDo == null).FirstOrDefault();
                ispis += trenutniSef.Radnik.Ime + " (" + trenutniSef.Radnik.ImeRoditelja + ") "
                      + trenutniSef.Radnik.Prezime + " " + trenutniSef.Radnik.BrRadneKnjizice + "\n\n";

                ispis += "Objekti koji se nalaze u parku:\n";
                List<Objekat> objektiSorted = p.Objekti.OrderBy(x => x.RedniBroj).ToList();

                foreach (Objekat o in objektiSorted)
                {
                    ispis += o.RedniBroj + ": ";
                    if (o.GetType() == typeof(Klupa))
                    {
                        ispis += "Klupa";
                    }
                    else if (o.GetType() == typeof(Fontana))
                    {
                        ispis += "Fontana";
                    }
                    else if (o.GetType() == typeof(Svetiljka))
                    {
                        ispis += "Svetiljka";
                    }
                    else if (o.GetType() == typeof(Igraliste))
                    {
                        Igraliste i = o as Igraliste;
                        ispis += "Igralište " + (i.BrojIgracaka == null ? "" : "sa " + i.BrojIgracaka + " igračaka ")
                              + "za decu od " + i.StarostDeceOd + " do " + i.StarostDeceDo + " godina";
                    }
                    else if (o.GetType() == typeof(Spomenik))
                    {
                        Spomenik sp = o as Spomenik;
                        Zasticen spZastita = sp.Zasticen;
                        ispis += "Spomenik, zaštićen datuma " + spZastita.DatumStavljanja.ToShortDateString()
                              + " od strane institucije \"" + spZastita.Institucija
                              + "\", uz opis: \"" + spZastita.Opis
                              + "\". Godišnja novčana naknada za potrebe zaštite ovog spomenika iznosi "
                              + spZastita.NovcanaNaknada + " dinara.";
                    }
                    else if (o.GetType() == typeof(Skulptura))
                    {
                        Skulptura sk = o as Skulptura;
                        Zasticen skZastita = sk.Zasticen;
                        ispis += "Skulptura, zaštićena datuma " + skZastita.DatumStavljanja.ToShortDateString()
                              + " od strane institucije \"" + skZastita.Institucija
                              + "\", uz opis: \"" + skZastita.Opis
                              + "\". Godišnja novčana naknada za potrebe zaštite ove skulpture iznosi "
                              + skZastita.NovcanaNaknada + " dinara.";
                    }
                    else if (o.GetType() == typeof(Drvo))
                    {
                        Drvo d = o as Drvo;
                        Zasticen dZastita = d.Zasticen;

                        ispis += "Drvo, vrste " + d.Vrsta
                              + (d.ObimDebla == null ? "" : ", obima debla " + d.ObimDebla + " metara")
                              + (d.PovrsinaPokrivanja == null ? "" : ", površine pokrivanja " + d.PovrsinaPokrivanja + " metara")
                              + (d.VisinaKrosnje == null ? "" : ", visine krošnje " + d.VisinaKrosnje + " metara")
                              + (d.DatumSadnje == null ? "" : " , posađeno datuma " + d.DatumSadnje.Value.ToShortDateString()) + ".";
                        if (dZastita != null)
                            ispis += " Drvo je zaštićeno datuma " + dZastita.DatumStavljanja.ToShortDateString()
                                  + " od strane institucije \"" + dZastita.Institucija
                                  + "\", uz opis: \"" + dZastita.Opis
                                  + "\". Godišnja novčana naknada za potrebe zaštite ovog drveta iznosi "
                                  + dZastita.NovcanaNaknada + " dinara.";
                    }
                    ispis += "\n";
                }

                s.Close();
                MessageBox.Show(ispis);
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnGetParkZasticeniInfo_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                IList<Park> parkovi = s.Query<Zasticen>()
                                       .Select(z => z.Objekat.Park)
                                       .Distinct().ToList();

                string message = "";

                foreach(Park p in parkovi)
                {
                    int drveceCount = p.Objekti.Where(o => o.GetType() == typeof(Drvo) && o.Zasticen != null).Count();
                    int skulptureCount = p.Objekti.Where(o => o.GetType() == typeof(Skulptura)).Count();
                    int spomeniciCount = p.Objekti.Where(o => o.GetType() == typeof(Spomenik)).Count();

                    int totalCount = drveceCount + skulptureCount + spomeniciCount;

                    message += "Park \"" + p.Naziv + "\", u opštini \"" + p.Opstina + 
                               "\", u kome broj zaštićenih objekata iznosi " + totalCount + ":\n" + 
                               "Drveće: " + drveceCount + ".\n" + 
                               "Skulpture: " + skulptureCount + ".\n" +
                               "Spomenici: " + spomeniciCount + ".\n\n\n";
                }

                s.Close();
                MessageBox.Show(message);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
