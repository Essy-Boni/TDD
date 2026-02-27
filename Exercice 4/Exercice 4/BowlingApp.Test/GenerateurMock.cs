using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingApp.Test
{
    internal class GenerateurMock : IGenerateur
    {
        private readonly int[] _values;
        private int _index;

        public GenerateurMock(params int[] values)
        {
            _values = values;
        }

        public int RandomPin(int max)
        {
            return _values[_index++];
        }
    }
}
