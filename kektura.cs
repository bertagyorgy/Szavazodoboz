using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _20250108
{
    class Szakasz
    {
        public int emelkedes, lejtes;
        public double hossz;
        public string start, veg, pecset;
        public Szakasz(string egysor)
        {
            string[] darabok = egysor.Trim().Split(';');
            start = darabok[0];
            veg = darabok[1];
            hossz = Convert.ToDouble(darabok[2]);
            emelkedes = int.Parse(darabok[3]);
            lejtes = int.Parse(darabok[4]);
            pecset = darabok[5];
        }
    }
    class Program
    {
        static string[] beolvas;
        static int tfm;
        static List<Szakasz> szakaszok = new List<Szakasz>();

        static void Main(string[] args)
        {
            beolvasas();
            f3();
            f4();
            f5();
            f7();
            f8();
            Console.ReadLine();
        }
        static void beolvasas()
        {
            beolvas = File.ReadAllLines("kektura.csv");
            tfm = int.Parse(beolvas[0]);
            for (int i = 1; i < beolvas.Length; i++)
            {
                szakaszok.Add(new Szakasz(beolvas[i]));
            }
        }
        static void f3()
        {
            Console.WriteLine($"3. feladat: Szakaszok száma: {szakaszok.Count} db");
        }
        static void f4()
        {
            double teljeshossz = 0;
            foreach (var item in szakaszok)
            {
                teljeshossz += item.hossz;
            }
            Console.WriteLine($"4. feladat: A túra teljes hossza: {teljeshossz} km");
        }
        static void f5()
        {
            List<double> legrovidebb = new List<double>();
            foreach (var item in szakaszok)
            {
                legrovidebb.Add(item.hossz);
            }
            double szam = legrovidebb.Min();
            foreach (var item in szakaszok)
            {
                if (item.hossz == szam)
                {
                    Console.WriteLine("5. feladat: A legrövidebb szakasz adatai: ");
                    Console.WriteLine($"\tKezdete: {item.start}");
                    Console.WriteLine($"\tVége: {item.veg}");
                    Console.WriteLine($"\tTávolság: {item.hossz} km");
                }
            }
            

        }
        static bool HianyosNev(string vege, string pecsetelohely)
        {
            return pecsetelohely == "i" && !vege.Contains("pecsetelohely");             
        }
        static void f7()
        {
            bool igaz = true;
            Console.WriteLine("7. feladat: Hiányos állomásnevek:");
            foreach (var item in szakaszok)
            {
                if (HianyosNev(item.veg, item.pecset))
                {
                    igaz = false;
                    Console.WriteLine($"\t{item.veg}");
                }

            }
            if (igaz)
            {
                Console.WriteLine("Nincs hiányos állomásnév!");
            }
            
        }
        static void f8()
        {
            int kezdet = tfm;
            List<int> legmagasabb = new List<int>();
            foreach (var item in szakaszok)
            {
                kezdet += item.emelkedes - item.lejtes;
                legmagasabb.Add(kezdet);
            }
            int maxmagasindex = legmagasabb.IndexOf(legmagasabb.Max());
            int i = 0;
            foreach (var item in szakaszok)
            {
                if (i == maxmagasindex)
                {
                    Console.WriteLine("8. feladat: A túra legmagasabban fekvő végpontja:");
                    Console.WriteLine($"\tA végpont neve: {item.veg}");
                    Console.WriteLine($"\tA végpont tengerszint feletti magassaga: {legmagasabb.Max()} m");
                }
                i++;
            }
        }
        static void f9()
        {
            
        }
    }
}
