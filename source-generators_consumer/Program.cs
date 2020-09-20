using System;
using CSV;
using System.Linq;

namespace source_generators_consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Personnes.All.ForEach(p=>Console.WriteLine(p.Prenom));
            Console.WriteLine($"Personnes : {Personnes.All.Count}");
            System.Console.WriteLine("_________________");
            StationsVelo.All.Take(10).ToList().ForEach(s=>Console.WriteLine(s.NomStation));
            Console.WriteLine($"Stations : {StationsVelo.All.Count}");

        }
    }
}
