using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonyvespolcFormAlk
{
    class Konyv
    {
        private string nev;
        private int aktualisOldal;
        private int maxOldal;
        private Boolean feltetel;

        public string Nev { get => nev; set => nev = value; }
        public int AktualisOldal { get => aktualisOldal; set => aktualisOldal = value; }
        public int MaxOldal { get => maxOldal; set => maxOldal = value; }
        public bool Feltetel { get => feltetel; set => feltetel = value; }

        public Konyv(string nev, int aktualisOldal, int maxOldal, bool feltetel)
        {
            this.nev = nev;
            this.aktualisOldal = aktualisOldal;
            this.maxOldal = maxOldal;
            this.feltetel = feltetel;
        }

        
    }
}
