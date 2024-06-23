using SearchProblem;
namespace L8
{
    internal class Program
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
            Console.WriteLine("Enter text to search for problem: ");
            string text = Console.ReadLine();

            Console.WriteLine("Choose the problem:");
            Console.WriteLine("1. Your words");
            Console.WriteLine("2. Forbidden words");

            int choice = int.Parse(Console.ReadLine());
            ProblemFinder problemFinder = null;

            switch (choice)
            {
                case 1:
                    Console.Write("Enter how many words you want to search: ");
                    int countWords = int.Parse(Console.ReadLine());
                    string[] words = new string[countWords];

                    for (int i = 0; i < countWords; i++)
                    {
                        Console.Write($"Write the {i + 1} word: ");
                        words[i] = Console.ReadLine();
                    }

                    problemFinder = new FinderYourWords(text, words);
                    break;

                case 2:
                    problemFinder = new FinderForbiddenWords(text);
                    break;

                default:
                    Console.WriteLine("incorrect answer");
                    break;
            }

            if (problemFinder != null)
            {
                Dictionary<string, int> result = problemFinder.FindProblem();
                Console.WriteLine("Результат: ");
                var value = result.Keys;
                foreach (string key in value)
                {
                    Console.WriteLine("Слово: " + key + " / Количество: " + result[key]);
                }
            }
        }
    }
}