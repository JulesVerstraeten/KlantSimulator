using KlantSimulator_BL.Exceptions;
using KlantSimulator_BL.Interface;
using KlantSimulator_BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlantSimulator_DL_File
{
    public class FileProcessor : IFileProcessor
    {
        // Schrijft alle klanten op txt file
        public void SchrijfKlanten(List<Klant> klanten, string path)
        {
            try
            {
                string filePath = path + @"\klanten.txt";
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                else
                {
                    File.Create(filePath).Close();
                }

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (Klant line in klanten)
                        writer.WriteLine(line.ToString());
                }

                Console.WriteLine($"Klanten opgeslagen in {filePath}");
            }
            catch (Exception ex) { throw new ManagerException("SchrijfKlanten", ex); }
        }

        // Leest alle gegevens die in txt files zijn opgeslagen (voornamen.txt -> voornamen, achternamen.txt -> achternamen,...)
        // moeten we niet bij leesgegevens de namen van de bestanden meegeven als parameter
        // postcodes en gemeentes zijn toch samen we hebben alleen 1 lijst nodig
        public List<string> LeesVoornamen(string path)
        {
            List<string> voornamen = new List<string>();
            try
            {
                using (StreamReader sr = new StreamReader(path + @"\voornamen.txt"))
                {
                    string line = sr.ReadToEnd();
                    voornamen = line.Split(',').Select(x => x.Trim()).ToList();
                }
                return voornamen;
            }
            catch (Exception ex)

            {
                throw new ManagerException("Er is fout opgetreden bij het lezen van de gegevens.", ex);
            }
        }
        public List<string> LeesAchternamen(string path)
        {
            List<string> achternamen = new List<string>();
            try
            {
                using (StreamReader sr = new StreamReader(path + @"\achternamen.txt"))
                {
                    string line = sr.ReadToEnd();
                    achternamen = line.Split(',').Select(x => x.Trim()).ToList();
                }
                return achternamen;
            }
            catch (Exception ex)

            {
                throw new ManagerException("Er is fout opgetreden bij het lezen van de gegevens.", ex);
            }
        }
        public List<string> LeesStraatnamen(string path)
        {
            List<string> straatnamen = new List<string>();
            try
            {
                using (StreamReader sr = new StreamReader(path + @"\straatnamen.txt"))
                {
                    string line = sr.ReadToEnd();
                    straatnamen = line.Split(',').Select(x => x.Trim()).ToList();
                }
                return straatnamen;
            }
            catch (Exception ex)

            {
                throw new ManagerException("Er is fout opgetreden bij het lezen van de gegevens.", ex);
            }
        }
        public List<string> LeesGemeentes(string path)
        {
            List<string> gemeentes = new List<string>();
            try
            {
                string[] lines = File.ReadAllLines(path + @"\gemeentes.txt");
                foreach (string line in lines)
                {
                    string[] parts = line.Split(",");
                    gemeentes.Add(parts[0].Trim());
                }
                return gemeentes;
            }
            catch (Exception ex)

            {
                throw new ManagerException("Er is fout opgetreden bij het lezen van de gegevens.", ex);
            }
        }
        public List<int> LeesPostcodes(string path)
        {
            
            List<int> postcodes = new List<int>();
            try
            {
                string[] lines = File.ReadAllLines(path + @"\gemeentes.txt");
                foreach (string line in lines)
                {
                    string[] parts = line.Split(",");
                    postcodes.Add(int.Parse(parts[1].Trim()));
                }
                return postcodes;
            }
            catch (Exception ex)

            {
                throw new ManagerException("Er is fout opgetreden bij het lezen van de gegevens.", ex);
            }
        }
    }
}
