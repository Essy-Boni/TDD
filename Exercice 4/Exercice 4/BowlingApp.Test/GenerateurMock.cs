using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingApp.Test
{
    internal class GenerateurMock : IGenerateur
    {
        private int _value;

        public GenerateurMock(int value)
        {
            _value = value;
        }

        public int RandomPin(int max)
        {
            return _value;
        }
    }
}
