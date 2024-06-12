namespace SearchProblem
{
    internal class FinderYourWords : ProblemFinder
    {
        private string[] _words;

        public FinderYourWords(string text, string[] words) : base(text)
        {
            _words = words;
        }

        public override int FindProblem()
        {
            int count = 0;
            string[] words = Text.Split(new char[] { ' ', '.', ',', '!', '?', ';', ':' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in words)
            {
                foreach (string badWord in _words)
                {
                    if (word.Equals(badWord, StringComparison.OrdinalIgnoreCase))
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}