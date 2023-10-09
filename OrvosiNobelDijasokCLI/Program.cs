using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrvosiNobelDijasokCLI
{
    internal class Program
    {
        static void Main()
        {
            var dijazottak = new List<Dijazott>();
            using (var sr = new StreamReader(@"..\..\src\orvosi_nobeldijak.txt", Encoding.UTF8))
            {
                _ = sr.ReadLine();
                while (!sr.EndOfStream) dijazottak.Add(new Dijazott(sr.ReadLine()));
            }
            Console.WriteLine($"3. feladat: Díjazottak száma: {dijazottak.Count} fő");

            var f4 = dijazottak.Max(d => d.Ev);
            Console.WriteLine($"4. feladat: utolsó év: {f4}");

            Console.Write("5. feladat: Kérem adja meg egy ország kódját: ");
            string ok = Console.ReadLine().ToUpper();
            var f5 = dijazottak.Where(d => d.Orszagkod == ok);
            if (f5.Count() == 0) Console.WriteLine("\tA megadott országból newm volt díjazott!");
            else if (f5.Count() == 1)
            {
                Console.WriteLine("\tA megadott ország díjazottja:");
                Console.WriteLine($"\tNév: {f5.First().Nev}");
                Console.WriteLine($"\tÉv: {f5.First().Ev}");
                Console.WriteLine($"\tSz/H: " +
                    $"{f5.First().SzuletesHalalozas.Szul}-{f5.First().SzuletesHalalozas.Hal}");
            }
            else Console.WriteLine($"\tA megadott országból {f5.Count()} fő díjazott volt!");

            Console.WriteLine($"6. feladat: Statisztika:");
            var f6 = dijazottak
                .GroupBy(d => d.Orszagkod)
                .Where(g => g.Count() >= 5)
                .ToDictionary(k => k.Key, v => v.Count());
            foreach (var kvp in f6) Console.WriteLine($"\t{kvp.Key} - {kvp.Value} fő");

            var f7 = dijazottak
                .Where(d => d.Elethossz != null)
                .Average(d => d.Elethossz);
            Console.WriteLine($"7. feladat: A keresett átlag: {f7:0.0} év");

            Console.ReadKey(true);
        }
    }
}
