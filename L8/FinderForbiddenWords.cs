using static System.Net.Mime.MediaTypeNames;

namespace SearchProblem
{
    internal class FinderForbiddenWords : ProblemFinder
    {
        private string[] _words = {"fuck", "fucking", "idiot", "nigger", "loser", "bitch" };
        private Dictionary<string, int> wordsAndTheirNumber = new Dictionary<string, int>() 
        { 
            { "fuck", 0 }, 
            { "fucking", 0 },
            { "idiot", 0 },
            { "nigger", 0 },
            { "loser", 0 },
            { "bitch", 0 }
        };

        public FinderForbiddenWords(string text) : base(text) { }

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