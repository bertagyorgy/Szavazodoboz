using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _20250115
{
    class Helyezesek
    {
        public int helyezes, sportolok_szama;
        public string sportag, versenyszam;

        public Helyezesek(string egysor)
        {
            string[] darabok = egysor.Trim().Split(' ');
            helyezes = int.Parse(darabok[0]);
            sportolok_szama = int.Parse(darabok[1]);
            sportag = darabok[2];
            versenyszam = darabok[3];
        }
    }
    class Program
    {
        static int arany;
        static int ezust;
        static int bronz;
        static int negyedik;
        static int otodik;
        static int hatodik;
        static List<Helyezesek> helyezes = new List<Helyezesek>();
        static void Main(string[] args)
        {
            f2();
            f3();
            f4();
            f5();
            f6();
            f7();
            f8();
            Console.ReadLine();

        }
        static void f2()
        {
            string[] beolvas = File.ReadAllLines("helsinki.txt", Encoding.Default);
            foreach (var item in beolvas)
            {
                helyezes.Add(new Helyezesek(item));
            }

        }
        static void f3()
        {
            Console.WriteLine($"3. feladat:\nPontszerző helyezések száma: {helyezes.Count}");
        }
        static void f4()
        {
            Console.WriteLine("4. feladat:");
            foreach (var item in helyezes)
            {
                switch (item.helyezes)
                {
                    case 1:
                        arany++;
                        break;
                    case 2:
                        ezust++;
                        break;
                    case 3:
                        bronz++;
                        break;
                    case 4:
                        negyedik++;
                        break;
                    case 5:
                        otodik++;
                        break;
                    case 6:
                        hatodik++;
                        break;
                }
            }
            Console.WriteLine($"Arany: {arany}");
            Console.WriteLine($"Ezüst: {ezust}");
            Console.WriteLine($"Bronz: {bronz}");
            Console.WriteLine($"Összesen: {arany + ezust + bronz}");
        }
        static void f5()
        {
            Console.WriteLine("5. feladat");
            Console.WriteLine($"Olimpiai pontok száma: {arany * 7 + ezust * 5 + bronz * 4 + negyedik * 3 + otodik * 2 + hatodik}");
        }
        static void f6()
        {
            int torna = 0;
            int uszas = 0;
            foreach (var item in helyezes)
            {
                if (item.sportag == "torna")
                {
                    torna++;
                }
                if (item.sportag == "uszas")
                {
                    uszas++;
                }
            }
            if (torna > uszas)
            {
                Console.WriteLine("Torna sportágban szereztek több érmet");
            }
            else if (uszas > torna)
            {
                Console.WriteLine("Úszás sportágban szereztek több érmet");
            }
            else
            {
                Console.WriteLine("Egyenlő volt az érmek száma");
            }
        }
        static void f7()
        {
            string filenev = "helsinki2.txt";
            using (FileStream fs = File.Create(filenev)) { }
            foreach (var item in helyezes)
            {
                string sportag;
                if (item.sportag == "kajakkenu" || item.sportag == "kajak-kenu")
                {
                    sportag = "kajak-kenu";
                }
                else
                {
                    sportag = item.sportag;
                }

                string ujsor = $"{item.helyezes} {item.sportolok_szama} {sportag} {item.versenyszam}\n";
                File.AppendAllText(filenev, ujsor);
                
            }
        }
        static void f8()
        {
            List<int> legmagasabb = new List<int>();
            foreach (var item in helyezes)
            {
                legmagasabb.Add(item.sportolok_szama);
            }
            foreach (var item in helyezes)
            {
                if (item.sportolok_szama == legmagasabb.Max())
                {
                    Console.WriteLine($"Helyezés: {item.helyezes}");
                    Console.WriteLine($"Sportág: {item.sportag}");
                    Console.WriteLine($"Versenyszám: {item.versenyszam}");
                    Console.WriteLine($"Sportolók száma: {item.sportolok_szama}");
                }
            }
        }
    }
}
