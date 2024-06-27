namespace JarmuPark {
     public abstract class Jarmu {
         public static int AktualisEv;
         public static int Alapdij;
         public static double HaszonKulcs;

         private string azonosito;
         private string rendszam;
         private int gyartasiEv;
         private double fogyasztas;
         private double futottKm;
         private int aktualisKoltseg;
         private bool szabad;

         public string Azonosito => azonosito;
         public string Rendszam => rendszam;
         public int GyartasiEv => gyartasiEv;
         public double Fogyasztas => fogyasztas;
         public double FutottKm => futottKm;
         public int AktualisKoltseg => aktualisKoltseg;
         public bool Szabad
         {
             get => szabad;
             set => szabad = value;
         }

         protected Jarmu(string azonosito, string rendszam, int gyartasiEv, double fogyasztas)
         {
             this.azonosito = azonosito;
             this.rendszam = rendszam;
             this.gyartasiEv = gyartasiEv;
             this.fogyasztas = fogyasztas;
             szabad = true;
         }

         protected Jarmu(string azonosito, string rendszam, int gyartasiEv)
         {
             this.azonosito = azonosito;
             this.rendszam = rendszam;
             this.gyartasiEv = gyartasiEv;
             szabad = true;
         }

         public int Kor()
         {
             return AktualisEv - gyartasiEv;
         }

         public bool Fuvaroz(double ut, int benzinAr)
         {
             if (!szabad)
                 return false;

             futottKm += ut;
             aktualisKoltseg = (int)(benzinAr * ut * fogyasztas / 100);
             szabad = false;
             return true;
         }

         public virtual int BerletiDij()
         {
             return (int)(Alapdij + aktualisKoltseg + aktualisKoltseg * HaszonKulcs / 100);
         }

         public override string ToString()
         {
             return $"A {GetType().Name.ToLower()} azonossítója: {azonosito}\n rendszáma: {rendszam}\n kora: {Kor()}\n fogyasztása: {fogyasztas}\n km óra állása: {futottKm}";
         }
     }
}