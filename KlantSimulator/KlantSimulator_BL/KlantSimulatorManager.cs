using KlantSimulator_BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlantSimulator_BL
{
    public class KlantSimulatorManager
    {
        private List<Klant> klanten = new List<Klant>();
        private List<string> voornamen;
        private List<string> achternamen;
        private List<string> straatnamen;
        private List<string> gemeentes = new List<string>();
        private List<int> postcodes = new List<int>();
        private string path;


        public KlantSimulatorManager(string path)
        {
            this.path = path;
        }

        public void KlantGenerator(int amount)
        {
            // Zet alle gegevens van txt naar variabel (voornamen, achternamen,...)
            LeesGegevens();

            while (amount > 0)
            {
                Random r = new Random();

                // Random keuze 
                int klantNr = KlantNrGenerator();
                string voornaam = voornamen[r.Next(voornamen.Count)];
                string achternaam = achternamen[r.Next(achternamen.Count)];
                string straatnaam = straatnamen[r.Next(straatnamen.Count)];
                string huisNr = HuisNrGenerator();
                int gemeenteIndex = r.Next(gemeentes.Count);
                string gemeente = gemeentes[gemeenteIndex];
                int postcode = postcodes[gemeenteIndex];

                // Zet random keuze in Klant
                Adres adres = new Adres(straatnaam, huisNr, gemeente, postcode);
                Klant klant = new Klant(klantNr, voornaam, achternaam, adres);

                // Kijk of de voornaam en achternaam uniek is
                if (klanten.Count == 0)
                {
                    klanten.Add(klant);
                    amount--;

                }
                else
                {
                    if (!KlantBestaatAl(klant))
                    {
                        klanten.Add(klant);
                        amount--;
                    }
                }

            }

            SchrijfKlanten();
        }

        private bool KlantBestaatAl(Klant klant)
        {
            bool heeftVoorEnAchternaam = false;
            foreach(Klant k in klanten)
            {
                if (k.VoorNaam == klant.VoorNaam && k.AchterNaam == klant.AchterNaam) { heeftVoorEnAchternaam = true; }
            }
            
            bool heeftKlantNr = klanten.Any(k => k.KlantNummer == klant.KlantNummer);
            bool heeftAdres = klanten.Any(k => k.Adres == klant.Adres);
            if (heeftAdres
                || heeftKlantNr
                || heeftVoorEnAchternaam
                )
            {
                return true;
            } else
            {
                return false;
            }
        }

        // Schrijft alle klanten op txt file
        private void SchrijfKlanten()
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
            catch (Exception ex) { throw new Exception("SchrijfKlanten", ex); }
        }

        // Leest alle gegevens die in txt files zijn opgeslagen (voornamen.txt -> voornamen, achternamen.txt -> achternamen,...)
        // moeten we niet bij leesgegevens de namen van de bestanden meegeven als parameter
        // postcodes en gemeentes zijn toch samen we hebben alleen 1 lijst nodig
        private void LeesGegevens()
        {
            // TODO
            try
            {
                using(StreamReader sr = new StreamReader(path + @"\voornamen.txt"))
                {
                    string line = sr.ReadToEnd();
                    voornamen = line.Split(',').Select(x => x.Trim()).ToList();
                }

                using(StreamReader sr = new StreamReader(path + @"\achternamen.txt"))
                {
                    string line = sr.ReadToEnd();
                    achternamen = line.Split(',').Select(n  => n.Trim()).ToList();
                }

                using(StreamReader sr = new StreamReader(path + @"\straatnamen.txt"))
                {
                    string line = sr.ReadToEnd();
                    straatnamen = line.Split(',').Select(l => l.Trim()).ToList();
                }

                string[] lines = File.ReadAllLines(path+@"\gemeentes.txt");
                foreach (string line in lines)
                {
                    string[] parts = line.Split(",");
                    gemeentes.Add(parts[0].Trim());
                    postcodes.Add(int.Parse(parts[1].Trim()));
                }


            }catch (Exception ex) 
            
            {
                Console.WriteLine("Er is fout opgetreden bij het lezen van de gegevens.",ex.Message);
            }

        }

        // Genereert klantnr op basis van voorwaarden
        private int KlantNrGenerator()
        {
            Random r = new Random();
            return r.Next(1, 20001);
        }

        // Genereert HuisNr 1/10 kans op letter (niet groter dan 150)
        private string HuisNrGenerator()
        {
            Random random = new Random();
            string nummer = random.Next(1, 50).ToString();
            int letterNodig = random.Next(1, 11);
            if (letterNodig == 1)
            {
                char randomLetter = (char)random.Next('a', 'z' + 1);
                nummer += randomLetter;
            }

            return nummer;
        }
    }
}
