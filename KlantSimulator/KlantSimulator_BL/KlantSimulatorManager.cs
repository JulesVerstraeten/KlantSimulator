using KlantSimulator_BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KlantSimulator_BL.Exceptions;
using KlantSimulator_BL.Interface;

namespace KlantSimulator_BL
{
    public class KlantSimulatorManager
    {
        private string path;
        public IFileProcessor Processor;

        public KlantSimulatorManager(string path, IFileProcessor processor)
        {
            this.path = path;
            Processor = processor;
        }

        public void KlantGenerator(int amount)
        {
            try
            {
                Generator generator = new Generator(path, Processor);
                generator.KlantGenerator(amount);
            } catch (Exception ex)
            {
                throw new Exception("KlantGenerator",ex);
            }
        }
    }
}
