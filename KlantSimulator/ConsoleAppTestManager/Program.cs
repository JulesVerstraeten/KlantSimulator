using KlantSimulator_BL;

namespace ConsoleAppTestManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Pad voor files : ");

            KlantSimulatorManager manager = new KlantSimulatorManager(Console.ReadLine());

            Console.Write("Hoeveel klanten wilt u genereren? : ");
            manager.KlantGenerator(int.Parse(Console.ReadLine()));
        }
    }
}
