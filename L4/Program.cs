using NumberGenerators; // For the first task
using Shapes; // For the second task
using GuessTheNumber; // For the third task
using PseudoText; // For the fourth task

namespace L4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter task number:");
            int taskNumber = int.Parse(Console.ReadLine());
            Console.WriteLine();
            switch (taskNumber)
            {
                case 1: SolveTask1(); break;
                case 2: SolveTask2(); break;
                case 3: SolveTask3(); break;
                case 4: SolveTask4(); break;
                default: Console.WriteLine("Unknown task"); break;
            }
        }

        private static void SolveTask1()
        {
            EvenNumberGenerator g1 = new EvenNumberGenerator();
            Console.WriteLine(g1.GenerateNext());
            Console.WriteLine();

            OddNumberGenerator g2 = new OddNumberGenerator();
            Console.WriteLine(g2.GenerateNext());
            Console.WriteLine();

            PrimeNumberGenerator g3 = new PrimeNumberGenerator();
            Console.WriteLine(g3.GeneratePrime());
            Console.WriteLine(g3.IsPrime(123));
            Console.WriteLine();

            FibonacciNumberGenerator g4 = new FibonacciNumberGenerator();
            List<long> fibonacciSequence = g4.GenerateFibonacciSequence(50);
            for (int i = 0; i < fibonacciSequence.Count; i++)
            {
                Console.Write(fibonacciSequence[i] + " ");
            }
            Console.WriteLine();
        }

        private static void SolveTask2()
        {
            DrawShapes drawShapes = new DrawShapes();

            Console.WriteLine("What's shape do you want to draw (triangle, square or rectangle)?");
            string shapeName = Console.ReadLine();

            switch (shapeName.ToLower())
            {
                case "triangle": drawShapes.DrawTriangle(); break;
                case "square": drawShapes.DrawSquare(); break;
                case "rectangle": drawShapes.DrawRectangle(); break;
                default: Console.WriteLine("Wrong name!"); break;
            }
        }

        private static void SolveTask3()
        {
            Console.Write("Enter the minimum number of the range: ");
            int min = int.Parse(Console.ReadLine());

            Console.Write("Enter the maximum number of the range: ");
            int max = int.Parse(Console.ReadLine());

            if (min > max) (min, max) = (max, min);

            Game game = new Game(min, max);
            game.Play();
        }

        private static void SolveTask4()
        {
            Console.Write("Enter the number of vowels: ");
            int numVowels = int.Parse(Console.ReadLine());

            Console.Write("Enter the number of consonants: ");
            int numConsonants = int.Parse(Console.ReadLine());

            Console.Write("Enter the maximum word length: ");
            int maxWordLength = int.Parse(Console.ReadLine());

            PseudoTextGenerator generator = new PseudoTextGenerator(numVowels, numConsonants, maxWordLength);
            string pseudoText = generator.GenerateText();

            Console.WriteLine("Generated Pseudo Text:");
            Console.WriteLine(pseudoText);
        }
    }
}