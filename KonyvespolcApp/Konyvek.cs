using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KonyvespolcFormAlk
{
    public static class Konyvek
    {
        private static List<Konyv> konyvek = new List<Konyv>();

        public static void konyvHozzaAdas(ListBox lb, string nev, int aktualisOldal, int maxOldal, Boolean feltetel) 
        {
            Konyv k = new Konyv(nev,aktualisOldal,maxOldal, feltetel);
            konyvek.Add(k);
            lb.Items.Add(nev);
        }

        private static void beolvasas(ListBox lb , string eleres) 
        {
            using (StreamReader olvaso = new StreamReader(eleres)) 
            {
                string sor;
                string[] szetvagott;

                try
                {
                    while (!olvaso.EndOfStream)
                    {
                        sor = olvaso.ReadLine();
                        szetvagott = sor.Split(';');
                        konyvHozzaAdas(lb, szetvagott[0], Convert.ToInt32(szetvagott[1]), Convert.ToInt32(szetvagott[2]), Boolean.Parse(szetvagott[3]));
                    }

                    olvaso.Close();
                    lb.Items.Clear();
                }
                catch(Exception e)
                {
                    MessageBox.Show("Hiba lépett fel a fájl beolvasása során!" + e.Message);
                }
            }
        }

        public static void kiiras(ListBox lb, string eleres)
        {
            using (StreamWriter iro = new StreamWriter(eleres))
            {
                try
                {
                    for (int i = 0; i < konyvek.Count; i++)
                    {

                        Boolean feltetel = lb.GetItemText(lb.SelectedItem) != null 
                            && lb.GetItemText(lb.SelectedItem) == konyvek[i].Nev ?
                            true : false;

                        iro.WriteLine(
                            konyvek[i].Nev + ";" +
                            konyvek[i].AktualisOldal + ";" +
                            konyvek[i].MaxOldal + ";" +
                            feltetel);
                    }

                    iro.Close();
                }
                catch(Exception e)
                {
                    MessageBox.Show("Hiba lépett fel a fájl írása közben!" + e.Message);
                }
            }

        }

        public static void kivalaszt(ListBox lb)
        {
            for (int i = 0; i < konyvek.Count; i++)
            {
                if (lb.GetItemText(lb.SelectedItem) == konyvek[i].Nev)
                {
                    lb.Items[i] = true;
                }
            }
        }

        public static int[] aktualMaxOldal(ListBox lb)
        {
            int[] oldalak = new int[2];

            for (int i = 0; i < konyvek.Count; i++)
            {
                if (lb.GetItemText(lb.SelectedItem) == konyvek[i].Nev)
                {
                    oldalak[0] = konyvek[i].AktualisOldal;
                    oldalak[1] = konyvek[i].MaxOldal;
                }
            }

            return oldalak;
        }

        public static ListBox listFeltolt(ListBox lb, string eleres)
        {
            beolvasas(lb, eleres);

            for (int i = 0; i < konyvek.Count; i++)
            {
                lb.Items.Add(konyvek[i].Nev);
            }
            return lb;
        }

    }
}
