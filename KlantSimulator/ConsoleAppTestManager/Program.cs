using KlantSimulator_BL;
using KlantSimulator_BL.Interface;
using KlantSimulator_DL_File;

namespace ConsoleAppTestManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Pad voor files : ");
            string path = Console.ReadLine();

            IFileProcessor processor;
            processor = new FileProcessor();
            KlantSimulatorManager manager = new KlantSimulatorManager(path, processor);

            Console.Write("Hoeveel klanten wilt u genereren? : ");
            manager.KlantGenerator(int.Parse(Console.ReadLine()));
        }
    }
}
