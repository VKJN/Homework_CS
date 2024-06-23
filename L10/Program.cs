
using System;
using System.Linq;

namespace L10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter task number:");
            int taskNumber = int.Parse(Console.ReadLine());
            switch (taskNumber)
            {
                case 1: SolveTask1(); break;
                default: Console.WriteLine("Unknown task"); break;
            }
        }

        private static void SolveTask1()
        {
            while (true)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Создать заметку");
                Console.WriteLine("2. Прочитать заметку из файла");
                Console.WriteLine("3. Выйти из программы");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        CreateNote();
                        break;
                    case "2":
                        PrintNote();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте еще раз.");
                        break;
                }
            }
        }

        struct Note
        {
            public string Caption;
            public string Body;
        }

        private static void CreateNote()
        {
            Note note = new Note();
            const string separator = "|";

            Console.Write("Введите заголовок заметки: ");
            note.Caption = ReadInput();

            Console.Write("Введите тело заметки: ");
            note.Body = ReadInput();

            if (!note.Caption.Contains(separator) && !note.Body.Contains(separator))
            {
                Console.Write("Введите имя файла для сохранения заметки: ");
                string fileName = Console.ReadLine();

                File.WriteAllText(fileName, string.Join(separator, note.Caption, note.Body));
                Console.Write("Сохранено");
            }
        }

        private static void PrintNote()
        {
            Console.Write("Введите имя файла для чтения заметки: ");
            string fileName = Console.ReadLine();

            Note note = ReadNoteFromFile(fileName);

            Console.WriteLine("Заголовок: " + note.Caption);
            Console.WriteLine("Тело: " + note.Body);
        }

        private static string ReadInput()
        {
            string input;
            while (true)
            {
                input = Console.ReadLine();
                if (input.Contains("|"))
                    Console.WriteLine("Символ | запрещен. Пожалуйста, введите текст без этого символа.");
                else
                    break;
            }
            return input;
        }

        static Note ReadNoteFromFile(string fileName)
        {
            string noteData = File.ReadAllText(fileName);
            string[] parts = noteData.Split('|');

            if (parts.Length != 2)
            {
                Console.WriteLine("Ошибка чтения заметки из файла.");
                return new Note();
            }

            return new Note { Caption = parts[0], Body = parts[1] };
        }
    }
}