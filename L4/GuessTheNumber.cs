namespace GuessTheNumber
{
    public class Game
    {
        private int _min;
        private int _max;

        public Game(int min, int max)
        {
            _min = min;
            _max = max;
        }

        public void Play()
        {
            Console.WriteLine("Press any key when you're ready...");
            Console.ReadKey();

            int guess;
            bool correct = false;
            while (!correct)
            {
                guess = (_min + _max) / 2;
                Console.WriteLine($"Is your number {guess}?");
                Console.WriteLine("Enter 'h' if your number is higher, 'l' if your number is lower, or 'c' if the guess is correct.");

                switch (Console.ReadLine().ToLower())
                {
                    case "h": _min = guess + 1; break;

                    case "l": _max = guess - 1; break;

                    case "c":
                        Console.WriteLine("The computer guessed your number!");
                        correct = true;
                        break;

                    default: Console.WriteLine("Invalid input. Please enter 'h', 'l', or 'c'."); break;
                }
            }
        }
    }
}