using static System.Net.Mime.MediaTypeNames;

namespace SearchProblem
{
    internal class FinderForbiddenWords : ProblemFinder
    {
        private string[] _words = {"fuck", "fucking", "idiot", "nigger", "loser", "bitch" };

        public FinderForbiddenWords(string text) : base(text) { }

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