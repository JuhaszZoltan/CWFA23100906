using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrvosiNobelDijasokCLI
{
    internal class Dijazott
    {
        public int Ev { get; set; }
        public string Nev { get; set; }
        public (int Szul, int? Hal) SzuletesHalalozas { get; set; }
        public string Orszagkod { get; set; }

        public int? Elethossz
        {
            get
            {
                if (SzuletesHalalozas.Hal is null) return null;
                else return SzuletesHalalozas.Hal - SzuletesHalalozas.Szul;
            }
        }

        public Dijazott(string s)
        {
            var v = s.Split(';');
            Ev = int.Parse(v[0]);
            Nev = v[1];
            var szh = v[2].Split('-');
            int sz = int.Parse(szh[0]);
            int? h = null;
            if (szh[1].Length != 0) h = int.Parse(szh[1]);
            SzuletesHalalozas = (sz, h);
            Orszagkod = v[3];
        }
    }
}
