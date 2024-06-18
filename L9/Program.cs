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

        delegate void PrintLine();

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

            int count = 0;
            PrintLine printLine = null;

            for (int i = 0; i < lineCount; i++)
            {
                printLine += CharAtPosition(nonSpaceChar, ++count);
            }

            if (printLine != null) printLine();
        }

        private static PrintLine CharAtPosition(char nonSpaceChar, int count)
        {
            Random random = new Random();
            char[] array = { ' ', ' ', ' ', ' ' };
            return () =>
            {
                int position = random.Next(0, 4);
                array[position] = nonSpaceChar;
                Console.Write($"{count} лямбда:");
                Console.WriteLine(new string(array));
            };
        }
    }
}