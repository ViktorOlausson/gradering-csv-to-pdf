using System.IO.Pipes;
using System.Runtime.CompilerServices;

namespace Gradering_ht_23
{
    internal class Program
    {
        class anmäld
        {
            public string namn, gup, ålder, kommentar, varning;

            public anmäld(string namn, string gup, string ålder)
            {
                this.namn = namn;
                this.gup = gup;
                this.ålder = ålder;
            }

            public anmäld(string line)
            {
                string[] delar = line.Split(",");
                namn = delar[0];
                ålder = delar[1];
                gup = delar[2];
                kommentar = delar[3];
                varning = delar[4];
            }

            public void print()
            {
                Console.WriteLine($"namn: {namn}");
                Console.WriteLine($"ålder: {ålder}");
                Console.WriteLine($"ska ta gup: {gup}");
                Console.WriteLine($"kommentar: {kommentar}");
                Console.WriteLine($"varning: {varning}");
            }

        }
        static void Main(string[] args)
        {
            string filePath = "gradering.csv";
            


            using (StreamReader gradering = new StreamReader(filePath))
            {
                
                string line = gradering.ReadLine();
                
                
            }
            
            
        }
    }
}