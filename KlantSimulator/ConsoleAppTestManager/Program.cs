using KlantSimulator_BL;

namespace ConsoleAppTestManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            KlantSimulatorManager manager = new KlantSimulatorManager(@"C:\Users\jules\Documents\HoGent\SEM2\Software_Ontwerp\KlantenSimulator\KlantSimulator");
            manager.KlantGenerator(600);
        }
    }
}
