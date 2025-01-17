﻿namespace JarmuPark {
    public class Teherauto: Jarmu {
        private double teherbiras;
        public static double Szorzo;

        public Teherauto(string azonosito, string rendszam, int gyartasiEv, double fogyasztas, double teherbiras) : base(azonosito, rendszam, gyartasiEv, fogyasztas)
        {
            this.teherbiras = teherbiras;
        }

        public Teherauto(string azonosito, string rendszam, int gyartasiEv, double teherbiras) : base(azonosito, rendszam, gyartasiEv)
        {
            this.teherbiras = teherbiras;
        }

        public override int BerletiDij()
        {
            return (int)(base.BerletiDij() + teherbiras * Szorzo);
        }

        public override string ToString()
        {
            return base.ToString() + $"\nteherbírás: {teherbiras}";
        }
    }
}