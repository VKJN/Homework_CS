using NumberGenerators;
namespace L7
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Enter task number:");
            int taskNumber = int.Parse(Console.ReadLine());
            Console.WriteLine();
            switch (taskNumber)
            {
                case 1: SolveTask1(); break;
                default: Console.WriteLine("Unknown task"); break;
            }
        }
            
        private static void SolveTask1()
        {
            try
            {
                SolveTask1Handled();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ooops.. Something went wrong:");
                Console.WriteLine(ex.Message);
            }
        }

        private static void SolveTask1Handled()
        {
            Console.WriteLine("Enter count of numbers to generate:");
            int countToGenerate = int.Parse(Console.ReadLine());

            Console.WriteLine("Choose one of supported number generators: odd, even");
            string generatorName = Console.ReadLine();

            NumberGenerator numberGenerator;

            switch (generatorName)
            {
                case "odd":
                    numberGenerator = new OddNumberGenerator();
                    break;
                case "even":
                    numberGenerator = new EvenNumberGenerator();
                    break;
                default:
                    throw new ApplicationException($"Unknown generator: {generatorName}");
            }
        }
    }
}