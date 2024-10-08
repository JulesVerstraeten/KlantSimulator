using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlantSimulator_BL.Model {
    public class Adres {
        private string straatnaam;

        public string Straatnaam {
            get { return straatnaam; }
            set { straatnaam = value; }
        }

        private string huisNr;
        public string HuisNr {
            get { return huisNr; }
            set { huisNr = value; }
        }

        private string gemeente;
        public string Gemeente {
            get { return gemeente; }
            set { gemeente = value; }
        }

        private int postcode;
        public int Postcode {
            get { return postcode; }
            set {
                if (value < 1000 || value > 9999) {
                    throw new Exception("Poscode is kleiner dan 1k of groter dan 9999");
                } else {
                    postcode = value;
                }
            }
        }

        public Adres(string straatnaam, string huisNr, string gemeente, int postcode) {
            Straatnaam = straatnaam;
            HuisNr = huisNr;
            Gemeente = gemeente;
            Postcode = postcode;
        }

        public override string ToString() {
            return $"{Straatnaam}|{HuisNr}|{Gemeente}|{Postcode}";
        }
    }
}

