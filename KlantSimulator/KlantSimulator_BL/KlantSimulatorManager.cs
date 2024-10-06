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
        private List<String> postcodes;


        public KlantSimulatorManager()
        {

        }

        public Klant KlantGenerator(int amount)
        {
            // TODO
            Klant k = new Klant();
            return k;
        }

        // Schrijft alle klanten op txt file
        public void SchrijfKlanten()
        {
            // TODO
        }

        // Leest alle gegevens die in txt files zijn opgeslagen
        public void LeesGegevens()
        {
            // TODO
        }

        // Genereert klantnr
        public int KlantNrGenerator()
        {
            // TODO
        }

        // Genereert HuisNr 1/10 kans op letter
        public string HuisNrGenerator()
        {
            // TODO
        }
    }
}
