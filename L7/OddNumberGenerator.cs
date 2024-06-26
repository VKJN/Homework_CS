﻿namespace NumberGenerators
{
    public sealed class OddNumberGenerator : NumberGenerator
    {
        private int _current;

        public OddNumberGenerator()
        {
            _current = 1;
        }

        public override int Next()
        {
            int current = _current;
            _current = current + 2;
            return current;
        }
    }
}