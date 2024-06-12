﻿namespace SearchProblem
{
    abstract class ProblemFinder
    {
        public string Text { get; }

        protected ProblemFinder(string text)
        {
            Text = text;
        }

        public abstract int FindProblem();
    }
}