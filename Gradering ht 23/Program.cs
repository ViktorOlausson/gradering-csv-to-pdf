using System.IO.Pipes;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Xml.Linq;

namespace Gradering_ht_23
{
    internal class Program
    {
        static List<anmäld> lines = new List<anmäld>();
        class anmäld
        {
            public string namn, gup, ålder, kommentar, varning;
            public string guparr;

            public anmäld(string namn, string gup, string ålder)
            {
                this.namn = namn;
                this.gup = gup;
                this.ålder = ålder;
            }
            public anmäld() { }
            
            public anmäld(string line)
            {
                string[] delar = line.Split(",");
                string[] delargup = delar[2].Split(" ");
                namn = delar[0];
                ålder = delar[1];
                gup = delar[2];
                kommentar = delar[3];
                varning = delar[4];
                guparr = delargup[0];

            }

            public void print(int i)
            {
                Console.WriteLine($"namn: {namn}");
                Console.WriteLine($"ålder: {ålder}");
                Console.WriteLine($"ska ta gup: {gup}");
                Console.WriteLine($"kommentar: {kommentar}");
                Console.WriteLine($"varning: {varning}");
                Console.WriteLine($"guparr: {guparr}");
            }
            public string ToString()
            {
                return $"namn: {namn} | ålder: {ålder} | ska ta gup: {gup} | kommentar: {kommentar} | varning: {varning}";
            }
            public string GupFileName()
            {
                return $"{guparr}gup.txt";
            }
        }
        static void Main(string[] args)
        {
            string filePath = "gradering.csv";
            


            using (StreamReader gradering = new StreamReader(filePath))
            {
                
                string line = gradering.ReadLine();
                while (line != null)
                {
                    anmäld L = new anmäld(line);
                    lines.Add(L);
                    line = gradering.ReadLine();
                    
                }

            }


            //skriv ut
            int i = 0;
            foreach (anmäld L in lines)
            {
                L.print(i++);
            }

            List<anmäld> gup11 = new List<anmäld>();
            //sortera och spara: 



            foreach(anmäld L in lines)
            {
                string filename = L.GupFileName();
                using(StreamWriter gradering = new StreamWriter(filename, true))
                {
                    gradering.WriteLine(L.ToString());
                    gradering.WriteLine();
                }
            }
            



        }
    }
}