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
    }
}
