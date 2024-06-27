using System;
using System.Collections.Generic;
using System.IO;

namespace JarmuPark {
    internal class Program {
        public static void Main(string[] args)
        {
            Jarmu.AktualisEv = 2024;
            Jarmu.Alapdij = 1000;
            Jarmu.HaszonKulcs = 10;

            Busz.Szorzo = 15;
            Teherauto.Szorzo = 8.5;

            List<Jarmu> jarmuvek = new List<Jarmu>();
            using (StreamReader sr = new StreamReader("jarmuvek.txt"))
            {
                int i = 0;
                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(';');
                    if (line[0] == "b")
                        jarmuvek.Add(new Busz(i.ToString(), line[1], int.Parse(line[2]), double.Parse(line[3].Replace('.', ',')), int.Parse(line[4])));
                    else if(line[0] == "t")
                        jarmuvek.Add(new Teherauto(i.ToString(), line[1], int.Parse(line[2]), double.Parse(line[3].Replace('.', ',')), double.Parse(line[4].Replace('.', ','))));
                    i++;
                }
            }

            Console.WriteLine("Kezdő adatok: ");
            foreach (Jarmu jarmu in jarmuvek)
            {
                Console.WriteLine("\n" + jarmu);
            }

            Random r = new Random();
            int osszBevetel = 0, osszKoltseg = 0;
            int alsoB = 400, felsoB = 420;
            double maxUt = 300;
            int mukodeshatar = 100;
            int fuvarok = 0;

            Console.WriteLine("\nJárművek futtatása...");
            for (int i = 0; i < r.Next(mukodeshatar); i++)
            {
                Jarmu jarmu = jarmuvek[r.Next(jarmuvek.Count)];
                if (jarmu.Fuvaroz(r.NextDouble() * maxUt, r.Next(alsoB, felsoB)))
                {
                    osszBevetel += jarmu.BerletiDij();
                    osszKoltseg += jarmu.AktualisKoltseg;
                    fuvarok++;
                }

                jarmuvek[r.Next(jarmuvek.Count)].Szabad = true;
            }

            Console.WriteLine($"A cég teljes bevétele: {osszBevetel}");
            Console.WriteLine($"A cég teljes költsége: {osszKoltseg}");
            Console.WriteLine($"A cég teljes haszna: {osszBevetel - osszKoltseg}");
            Console.WriteLine($"Fuvarok száma: {fuvarok}");

            Console.WriteLine("\nVégső adatok:");
            foreach (var e in jarmuvek)
            {
                Console.WriteLine("\n" + e);
            }



        }
    }
}