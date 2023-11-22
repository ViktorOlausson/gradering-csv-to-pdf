using System.IO.Pipes;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Xml.Linq;
using OfficeOpenXml;

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
                string[] delargup = delar[3].Split(" ");
                namn = delar[1];
                ålder = delar[2];
                gup = delar[3];
                kommentar = delar[4];
                varning = delar[5];
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
            public string GupFileNameTXT()
            {
                return $"{guparr}gup.txt";
            }
            public string GupFileNameEXEL()
            {
                return $"{guparr}gup.xlsx";
            }
        }
        static void Main(string[] args)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
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

            //exel fil(funkar ej):
            /*FileInfo existingFile = new FileInfo("output.xlsx");
            ExcelPackage package;
            if(existingFile.Exists)
            {
                using (var existingPackage = new ExcelPackage(existingFile))
                {
                    package = existingPackage;
                }
            }
            else
            {
                package = new ExcelPackage();
            }

            

            foreach (anmäld L in lines)
            {
                string sheetName = L.GupFileNameEXEL();
                var existingSheet = package.Workbook.Worksheets[sheetName];
                if(existingSheet != null)
                {
                    var workSheet = package.Workbook.Worksheets[sheetName];
                }
                existingSheet.Cells[existingSheet.Dimension.End.Row + 1, 1].Value = L.namn;
                existingSheet.Cells[existingSheet.Dimension.End.Row + 1, 2].Value = L.ålder;
                existingSheet.Cells[existingSheet.Dimension.End.Row + 1, 3].Value = L.gup;
                existingSheet.Cells[existingSheet.Dimension.End.Row + 1, 4].Value = L.varning;

            }

            package.Save();
*/

            //.txt file:
            foreach(anmäld L in lines)
            {
                string filename = L.GupFileNameTXT();
                string FileName = Path.Combine("txt filer", filename);
                using(StreamWriter gradering = new StreamWriter(FileName, true))
                {
                    gradering.WriteLine(L.ToString());
                    gradering.WriteLine();
                }
            }
            



        }
    }
}