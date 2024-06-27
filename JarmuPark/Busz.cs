namespace JarmuPark {
    public class Busz: Jarmu {
        private int ferohely;
        public static double Szorzo;

        public Busz(string azonosito, string rendszam, int gyartasiEv, double fogyasztas, int ferohely) : base(azonosito, rendszam, gyartasiEv, fogyasztas)
        {
            this.ferohely = ferohely;
        }

        public Busz(string azonosito, string rendszam, int gyartasiEv, int ferohely) : base(azonosito, rendszam, gyartasiEv)
        {
            this.ferohely = ferohely;
        }

        public override int BerletiDij()
        {
            return (int)(base.BerletiDij() + ferohely * Szorzo);
        }

        public override string ToString()
        {
            return base.ToString() + $"\nférőhelyek: {ferohely}";
        }
    }
}