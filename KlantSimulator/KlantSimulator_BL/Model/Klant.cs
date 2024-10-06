using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlantSimulator_BL.Model
{
    public class Klant
    {
        public int KlantNummer { get; }
        public string VoorNaam { get; }
        public string AchterNaam { get; }
        public Adres Adres { get; }

        public Klant(int klantNummer,string voorNaam,string achterNaam,Adres adres)
        {
            KlantNummer = klantNummer;
            VoorNaam = voorNaam;
            AchterNaam = achterNaam;
            Adres = adres;
        }

        public override string ToString()
        {
            return $"{KlantNummer}|{VoorNaam}|{AchterNaam}|{Adres.Straatnaam}|{Adres.HuisNr}|{Adres.Gemeente}|{Adres.Postcode}";
        }

    }
}
