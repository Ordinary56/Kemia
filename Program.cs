using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Elem> elemek = new List<Elem>();
            using (StreamReader sr = new StreamReader("./Source/felfedezesek.csv",Encoding.UTF8))
            {
                sr.ReadLine().Skip(1);
                while(!sr.EndOfStream)
                {
                    string[] text = sr.ReadLine().Split(';');
                    elemek.Add(new Elem(text[0],text[1],text[2],int.Parse(text[3]),text[4]));
                }
            }
            Console.WriteLine($"3. feladat: Elemek száma: {elemek.Count}");
            Console.WriteLine($"4. feladat: felfedezések száma az Ókorban: {elemek.Where(x => x.Ev.Equals("Ókor")).Count()}");
            string userInput;
            do
            {
                Console.Write("5. feladat: Kérek egy vegyjelet: ");
                userInput = Console.ReadLine() ?? "";
            } while (!(userInput.Length < 3));
            if (!elemek.Any(x => x.Vegyjel.ToLower() == userInput.ToLower())) Console.WriteLine("6. feladat: nincs ilyen elem az adatforrásban!");
            else
            {
                Elem keresett = elemek.Where(x => x.Vegyjel.ToLower() == userInput.ToLower()).First();
                Console.WriteLine($"6. feladat: Keresés\n\tAz elem vegyjele:{keresett.Vegyjel}" +
                    $"\n\tAz elem neve: {keresett.Nev}\n\tRendszáma: {keresett.Rendszam}\n\tFelfedezés éve: {keresett.Ev}" +
                    $"\n\tFelfedező: {keresett.Felfedezo}");
            }
           
            Console.WriteLine($"7. feladat:  év volt a leghosszabb időszak két elem felfedezése között");
            Console.WriteLine($"8. feladat: Statisztika: ");
            elemek.Where(x => x.Ev != "Ókor").GroupBy(x => x.Ev).Where(x => x.Key.Count() > 3).ToList().ForEach(x => Console.WriteLine($"\t{x.Key}:  {x.Key.Count()} db"));

        }
    }
}
