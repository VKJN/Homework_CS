namespace PseudoText
{
    public class PseudoTextGenerator
    {
        private int _numVowels;
        private int _numConsonants;
        private int _maxWordLength;

        private char[] Vowels = { 'a', 'e', 'i', 'o', 'u' };
        private char[] Consonants =
        { 'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'y', 'z'};

        public PseudoTextGenerator(int numVowels, int numConsonants, int maxWordLength)
        {
            _numVowels = numVowels;
            _numConsonants = numConsonants;
            _maxWordLength = maxWordLength;
        }

        public string GenerateText()
        {
            Random random = new Random();
            int totalLetters = _numVowels + _numConsonants;

            List<char> lettes = new List<char>();

            int wordLength = Math.Min(_maxWordLength, totalLetters);

            while (wordLength > 0)
            {
                bool isVowels = random.Next(2) == 1;

                if (isVowels && _numVowels != 0)
                {
                    lettes.Add(Vowels[random.Next(Vowels.Length)]);
                    _numVowels--;
                    wordLength--;
                }

                else if (!isVowels && _numConsonants != 0)
                {
                    lettes.Add(Consonants[random.Next(Consonants.Length)]);
                    _numConsonants--;
                    wordLength--;
                }
            }

            string result = new string(lettes.ToArray());
            return result;
        }
    }
}