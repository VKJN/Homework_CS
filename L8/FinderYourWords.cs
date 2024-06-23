namespace SearchProblem
{
    internal class FinderYourWords : ProblemFinder
    {
        private string[] _words;
        private Dictionary<string, int> wordsAndTheirNumber = new Dictionary<string, int>();

        public FinderYourWords(string text, string[] words) : base(text)
        {
            _words = words;
            foreach (var word in _words)
            {
                wordsAndTheirNumber.Add(word, 0);
            }
        }

        public override Dictionary<string, int> FindProblem()
        {
            string[] words = Text.Split(new char[] { ' ', '.', ',', '!', '?', ';', ':' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in words)
            {
                foreach (string badWord in _words)
                {
                    if (word.Equals(badWord, StringComparison.OrdinalIgnoreCase))
                    {
                        wordsAndTheirNumber[badWord] += 1;
                    }
                }
            }
            return wordsAndTheirNumber;
        }
    }
}