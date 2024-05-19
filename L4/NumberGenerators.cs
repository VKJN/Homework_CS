namespace NumberGenerators
{
    public class EvenNumberGenerator
    {
        private int _currentEven = 0;

        public int GenerateNext()
        {
            _currentEven += 2;
            return _currentEven;
        }
    }

    public class OddNumberGenerator
    {
        private int _currentOdd = -1;

        public int GenerateNext()
        {
            _currentOdd += 2;
            return _currentOdd;
        }
    }

    public class PrimeNumberGenerator
    {
        public bool IsPrime(int number)
        {
            if (number < 2)
                return false;

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }

        public int GeneratePrime()
        {
            Random random = new Random();
            int number;
            do
            {
                number = random.Next();
            } while (!IsPrime(number));

            return number;
        }
    }

    public class FibonacciNumberGenerator
    {
        public List<long> GenerateFibonacciSequence(int n)
        {
            List<long> sequence = new List<long>();

            long a = 0, b = 1;

            for (int i = 0; i < n; i++)
            {
                long temp = a;
                a = b;
                b = temp + b;
                sequence.Add(a);
            }

            return sequence;
        }
    }
}