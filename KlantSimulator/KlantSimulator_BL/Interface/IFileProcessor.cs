using KlantSimulator_BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlantSimulator_BL.Interface
{
    public interface IFileProcessor
    {
        public void SchrijfKlanten(List<Klant> klanten, string path);
        public List<string> LeesVoornamen(string path);
        public List<string> LeesAchternamen(string path);
        public List<string> LeesStraatnamen(string path);
        public List<string> LeesGemeentes(string path);
        public List<int> LeesPostcodes(string path);
    }
}
