namespace JarmuPark {
    public class Busz: Jarmu {
        private int ferohely;
        private double szorzo;

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
            return (int)(base.BerletiDij() + ferohely * szorzo);
        }

        public override string ToString()
        {
            return base.ToString() + $"\nférőhelyek: {ferohely}";
        }
    }
}