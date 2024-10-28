using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KlantSimulator_BL.Exceptions;

namespace KlantSimulator_BL.Model
{
    public class Klant
    {
        private int klantNummer;

        public int KlantNummer
        {
            get { return klantNummer; }
            // private set omdat het alleen binnen de klasse moet kunnen worden aangepast (aka met de contructor in dit geval)
            private set 
            { // domeinexception, cuz wy not ;)
                if (value < 0 || value > 50000) {throw new DomeinException("klant| klantnummer lag niet tussen 0 en 20000");}
                klantNummer = value; 
            }
        }

        private string voorNaam;

        public string VoorNaam
        {
            get { return voorNaam; }
            // zelfde principe als klantnummer
            private set 
            {
                if(string.IsNullOrWhiteSpace(value)) { throw new DomeinException("Klant| Voornaam mag niet leeg zijn");}
                voorNaam = value;
            }
        }

        private string achterNaam;

        public string AchterNaam
        {
            get { return achterNaam; }
            // zelfde principe als klantnummer
            private set
            {
                if(string.IsNullOrWhiteSpace(value)) { throw new DomeinException("Klant| Achternaam mag niet leeg zijn"); }
                achterNaam = value;
            }
        }

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
            return $"{KlantNummer}|{VoorNaam}|{AchterNaam}|{Adres}";
        }

    }
}
