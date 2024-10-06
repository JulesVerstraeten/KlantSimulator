using KlantSimulator_BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlantSimulator_BL
{
    internal class KlantSimulatorManager
    {
        private List<Klant> klanten;
        private List<String> voornamen;
        private List<String> achternamen;
        private List<String> straatnamen;
        private List<String> gemeentes;
        private List<int> postcodes;


        public KlantSimulatorManager()
        {

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
                int gemeenteIndex = r.Next(postcodes.Count);
                string gemeente = gemeentes[gemeenteIndex];
                int postcode = postcodes[gemeenteIndex];

                // Zet random keuze in Klant
                Adres adres = new Adres(straatnaam, huisNr, gemeente, postcode);
                Klant klant = new Klant(klantNr, voornaam, achternaam, adres);

                // Kijk of de voornaam en achternaam uniek is
                foreach (Klant k in klanten)
                {
                    if (k.VoorNaam != voornaam && k.AchterNaam != achternaam)
                    {
                        klanten.Add(klant);
                        amount--;
                    }
                }
            }

        }

        // Schrijft alle klanten op txt file
        public void SchrijfKlanten()
        {
            // TODO
        }

        // Leest alle gegevens die in txt files zijn opgeslagen (voornamen.txt -> voornamen, achternamen.txt -> achternamen,...)
        public void LeesGegevens()
        {
            // TODO
        }

        // Genereert klantnr op basis van voorwaarden
        public int KlantNrGenerator()
        {
            // TODO
        }

        // T

        // Genereert HuisNr 1/10 kans op letter (niet groter dan 150)
        public string HuisNrGenerator()
        {
            // TODO
        }
    }
}
