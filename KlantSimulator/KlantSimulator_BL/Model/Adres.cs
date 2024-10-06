using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlantSimulator_BL.Model
{
    public class Adres
    {
        public string Straatnaam;
        public string HuisNr;
        public string Gemeente;
        public int Postcode;

        public Adres(string straatnaam, string huisNr, string gemeente, int postcode)
        {
            this.Straatnaam = straatnaam;
            this.HuisNr = huisNr;
            this.Gemeente = gemeente;
            this.Postcode = postcode;
        }

        public override string ToString()
        {
            return $"{Straatnaam}|{HuisNr}|{Gemeente}|{Postcode}";
        }
    }
}
