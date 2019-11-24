using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KonyvespolcFormAlk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnHozzaad_Click(object sender, EventArgs e)
        {
            if (aktualisOldalbox.Text != "" && maxOldalbox.Text != "" && ujKonyvbox.Text != "")
            {
                Konyvek.konyvHozzaAdas(konyvlistbox, ujKonyvbox.Text, Convert.ToInt32(aktualisOldalbox.Text), Convert.ToInt32(maxOldalbox.Text), false) ;

                aktualisOldalbox.Clear();
                ujKonyvbox.Clear();
                maxOldalbox.Clear();
            }
            else
            {
                MessageBox.Show("Hiba!! Üresen hagyott mező!");
            }

        }

        private void btnMentes_Click(object sender, EventArgs e)
        {
            string file = null;

            if (konyvlistbox.SelectedItem != null) 
            {
                if (dialogmentesbetoltes.ShowDialog(this) == DialogResult.OK)
                {
                    file = dialogmentesbetoltes.InitialDirectory + dialogmentesbetoltes.FileName;
                }

                Konyvek.kiiras(konyvlistbox, file);
            }
            else
            {
                MessageBox.Show("Hiba!! Üresen hagyott mező!");
            }


        }

        private void btnBetoltes_Click(object sender, EventArgs e)
        {
            string file = null;

            if (dialogmentesbetoltes.ShowDialog(this) == DialogResult.OK)
            {
                file = dialogmentesbetoltes.InitialDirectory + dialogmentesbetoltes.FileName;
                Konyvek.listFeltolt(konyvlistbox, file);
            }

            Konyvek.kivalaszt(konyvlistbox);
        }
    }
}
