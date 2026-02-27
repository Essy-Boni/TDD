using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingApp
{
    public interface IGenerateur
    {
        public int RandomPin(int max);
    }
}
