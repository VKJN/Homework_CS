using System.ComponentModel;

namespace L9
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
                default: Console.WriteLine("Unknown task"); break;
            }
        }

        private static void SolveTask1()
        {
            Console.WriteLine("Введите непробельный символ: ");
            char nonSpaceChar = Console.ReadKey().KeyChar;
            Console.WriteLine();

            Console.WriteLine("Введите количество строк для вывода: ");
            if (!int.TryParse(Console.ReadLine(), out int lineCount))
            {
                Console.WriteLine("Неверное значение");
                return;
            }

            Action<char> writeAction = CreateIndexSelectingLambda(1, 3);
            writeAction += CreateRandomPositionLambda();

            for (int i = 0; i < lineCount; i++)
            {
                writeAction(nonSpaceChar);
                Console.WriteLine();
            }
        }

        private static Action<char> CreateIndexSelectingLambda(int indexA, int indexB)
        {
            var random = new Random();
            return symbol =>
            {
                int index = random.Next(0, 2) == 1 ? indexA : indexB;
                for (int i = 0; i < 4; i++)
                {
                    if (i == index) Console.Write(symbol);
                    else Console.Write(' ');
                }
            };
        }

        private static Action<char> CreateRandomPositionLambda()
        {
            var random = new Random();
            return symbol =>
            {
                int printIndex = random.Next(0, 4);
                for (int i = 0; i < 4; i++)
                {
                    Console.Write(i == printIndex ? symbol : ' ');
                }
            };
        }
    }
}