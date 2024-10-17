using KlantSimulator_BL.Exceptions;
using KlantSimulator_BL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlantSimulator_BL.Model
{
    public class Generator
    {
        private int MAX_KLANTEN = 20_000;
        private int KANS_OP_LETTER = 10;
        private int MAX_HUISNR = 50;
        private char MAX_CHAR_HUISNR = 'z';

        private List<Klant> klanten = new List<Klant>();
        private IFileProcessor processor;
        private string path;
        private List<string> voornamen;
        private List<string> achternamen;
        private List<string> straatnamen;
        private List<string> gemeentes;
        private List<int> postcodes;

        public Generator(string path, IFileProcessor processor)
        {
            this.path = path;
            this.processor = processor;
        }

        // Genereert klanten
        public void KlantGenerator(int amount)
        {
            LeesGegevens(path);

            if (amount > MAX_KLANTEN)
            {
                throw new ManagerException("Maximaal 20.000 klanten aangeven");
            }
            // Zet alle gegevens van txt naar variabel (voornamen, achternamen,...)

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
            foreach (Klant k in klanten)
            {
                Console.WriteLine(k.ToString()); 
            }

            processor.SchrijfKlanten(klanten, path);
        }

        // Kijkt of klant al bestaat
        private bool KlantBestaatAl(Klant klant)
        {
            bool heeftVoorEnAchternaam = false;
            foreach (Klant k in klanten)
            {
                if (k.VoorNaam == klant.VoorNaam && k.AchterNaam == klant.AchterNaam) { heeftVoorEnAchternaam = true; }
            }
            bool heeftKlantNr = klanten.Any(k => k.KlantNummer == klant.KlantNummer);
            bool heeftAdres = klanten.Any(k => k.Adres == klant.Adres);
            if (heeftAdres || heeftKlantNr || heeftVoorEnAchternaam) { return true; } else return false;
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
            string nummer = random.Next(1, MAX_HUISNR).ToString();
            int letterNodig = random.Next(1, KANS_OP_LETTER);
            if (letterNodig == 1)
            {
                char randomLetter = (char)random.Next('a', MAX_CHAR_HUISNR + 1);
                nummer += randomLetter;
            }

            return nummer;
        }

        // Leest alle gegevens die in txt files zijn opgeslagen (voornamen.txt -> voornamen, achternamen.txt -> achternamen,...)
        private void LeesGegevens(string path)
        {
            voornamen = processor.LeesVoornamen(path);
            achternamen = processor.LeesAchternamen(path);
            straatnamen = processor.LeesStraatnamen(path);
            gemeentes = processor.LeesGemeentes(path);
            postcodes = processor.LeesPostcodes(path);
        }
    }
}
