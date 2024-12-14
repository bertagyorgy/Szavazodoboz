using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _20241212
{
    class Kezieb
    {
        public int golok, loves, hetmeteres, hetmeteres_probalkozas, kiallitas, cm;
        public string nev, poszt, szulido, csapat;

        public Kezieb(string egysor)
        {
            string[] darabok = egysor.Trim().Split(';');
            nev = darabok[0];
            golok = int.Parse(darabok[1]);
            loves = int.Parse(darabok[2]);
            hetmeteres = int.Parse(darabok[3]);
            hetmeteres_probalkozas = int.Parse(darabok[4]);
            kiallitas = int.Parse(darabok[5]);
            poszt = darabok[6];
            szulido = darabok[7];
            cm = int.Parse(darabok[8]);
            csapat = darabok[9];
        }
    }
    class Program
    {
        static List<Kezieb> jatekos = new List<Kezieb>();
        static List<int> eletkorok = new List<int>();
        static List<int> magassagok = new List<int>();
        static double atlag;
        static void Main(string[] args)
        {
            f2();
            f3();
            f4();
            f5();
            f6();
            f7();
            f8();
            f9();
            f10();
            f11();
            f12();
            f13();
            f14();
            f15();
            f16();
            Console.ReadLine();
        }
        static void f2()
        {
            string[] beolvas = File.ReadAllLines("kezieb.txt", Encoding.UTF8);
            foreach (var item in beolvas)
            {
                jatekos.Add(new Kezieb(item));
            }
            Console.WriteLine($"2. feladat: A magyar csapatban {jatekos.Count} mezőnyjátékos szerepelt.");
        }
        static void f3()
        {
            List<string> beallok = new List<string>();
            Console.WriteLine("3. feladat: Beállók:");
            foreach (var item in jatekos)
            {
                if (item.poszt == "beálló")
                {
                    beallok.Add(item.nev);
                }
            }
            beallok.Sort();
            foreach (var item in beallok)
            {
                Console.WriteLine($"\t{item}");
            }
        }
        static void f4()
        {
            List<string> csapatok = new List<string>();
            Console.WriteLine("4. feladat: A játékosokat adó csapatok:");
            foreach (var item in jatekos)
            {
                if (!csapatok.Contains(item.csapat))
                {
                    csapatok.Add(item.csapat);
                }
            }
            csapatok.Sort();
            foreach (var item in csapatok)
            {
                Console.WriteLine($"\t{item}");
            }
        }
        static void f5()
        {
            List<string> otgolosok = new List<string>();
            Console.WriteLine("5. feladat: Öt gólnál többet dobtak:");
            foreach (var item in jatekos)
            {
                if (item.loves > 5)
                {
                    otgolosok.Add(item.nev);
                }
            }
            otgolosok.Sort();
            foreach (var item in otgolosok)
            {
                Console.WriteLine($"\t{item}");
            }
        }
        static void f6()
        {
            int osszgol = 0;
            int hetmeteres_szamolo = 0;
            foreach (var item in jatekos)
            {
                osszgol += item.golok;
                hetmeteres_szamolo += item.hetmeteres;
            }
            Console.WriteLine($"6. feladat: A magyar csapat összesen {osszgol} gólt lőtt, ebből {hetmeteres_szamolo} hétméterest.");
        }
        static void f7()
        {
            int i = 0;
            foreach (var item in jatekos)
            {
                if (item.hetmeteres > 0)
                {
                    i++;
                }
            }
            Console.WriteLine($"7. feladat: {i} játékos dobott hétméterest.");
        }
        static void f8()
        {
            int buntetes = 0;
            foreach (var item in jatekos)
            {
                if (item.kiallitas > 0)
                {
                    buntetes += item.kiallitas;
                }
            }
            Console.WriteLine($"8. feladat: {buntetes * 2} perc büntetést kapott a csapat.");
        }
        static void f9()
        {
            string fiataljatekos = "";
            foreach (var item in jatekos)
            {
                eletkorok.Add(int.Parse(item.szulido.Split('.')[0]));
            }
            eletkorok.Sort();
            int legfiatalabb = eletkorok.Last();
            foreach (var item in jatekos)
            {
                if (Convert.ToString(legfiatalabb) == item.szulido.Split('.')[0])
                {
                    fiataljatekos = item.nev;
                }
            }
            Console.WriteLine($"9. feladat: A legfiatalabb játékos {fiataljatekos}.");
        }
        static void f10()
        {
            int i = 0;
            foreach (var item in eletkorok)
            {
                if (item == 1999)
                {
                    i++;
                }
            }
            Console.WriteLine($"10. feladat: 1999-ben {i} játékos született.");
        }
        static void f11()
        {            
            foreach (var item in jatekos)
            {
                magassagok.Add(item.cm);
            }
            atlag = magassagok.Sum() / magassagok.Count;
            Console.WriteLine($"11. feladat: A csapat átlagmagassága {Math.Round(atlag)} cm.");
        }
        static void f12()
        {
            List<int> evek = new List<int>();
            foreach (var item in eletkorok)
            {
                evek.Add(2024 - item);
            }
            double atlagev = evek.Sum() / evek.Count;
            Console.WriteLine($"12. feladat: A csapat átlagéletkora {atlagev} év.");
        }
        static void f13()
        {
            int i = 0;
            foreach (var item in jatekos)
            {
                if (item.csapat == "Balatonfüredi KSE")
                {
                    i++;
                }
            }
            Console.WriteLine($"13. feladat: A Balatonfüredi KSE {i} játékost adott a válogatottnak.");
        }
        static void f14()
        {
            string lekaicsapat = "";
            foreach (var item in jatekos)
            {
                if (item.nev == "Lékai Máté")
                {
                    lekaicsapat = item.csapat;
                }
            }
            Console.WriteLine($"14. feladat: Lékai Máté a {lekaicsapat}-ben játszik.");
        }
        static void f15()
        {
            bool ketszaz = false;
            foreach (var item in magassagok)
            {
                if (item == 200)
                {
                    ketszaz = true;
                }
            }
            if (ketszaz == true)
            {
                Console.WriteLine("15. feladat: Van olyan játékos aki 200 cm magas.");
            }
            else
            {
                Console.WriteLine("15. feladat: Nincs olyan játékos aki 200 cm magas.");
            }
        }
        static void f16()
        {
            string file = "magasak.txt";
            using (FileStream fs = File.Create(file)) { }
            foreach (var item in jatekos)
            {
                if (item.cm > atlag)
                {
                    string sor = $"{item.nev} {item.cm}";
                    File.AppendAllText(file, sor + Environment.NewLine);
                }
            }
        }

    }
}
